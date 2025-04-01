using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProjectDocumentationGenerator.Models;

namespace ProjectDocumentationGenerator.Helpers
{
    internal static class DocmentationHelper
    {
        public static ClassDetails? GetClassDocumentation(ClassDeclarationSyntax classDeclaration, SemanticModel semanticModel)
        {
            if (semanticModel.GetDeclaredSymbol(classDeclaration) is not INamedTypeSymbol recordSymbol || recordSymbol.DeclaredAccessibility != Accessibility.Public)
            {
                return null;
            }

            // Parse the record's XML documentation.
            var docComment = XmlDocumentationHelper.GetDocumentationComment(classDeclaration.GetLeadingTrivia(), semanticModel);
            // Create a new RecordDetails object inline.
            var classDetails = new ClassDetails
            {
                Name = classDeclaration.Identifier.Text,
                SummaryFragments = docComment.SummaryFragments,
                SeeAlso = docComment.SeeAlso,
                TypeParameters = recordSymbol.TypeParameters.Select(t => t.Name).ToList(),
                IsAbstract = recordSymbol.IsAbstract,
            };

            // If the record inherits from a base type, store the simple base type name.
            if (classDeclaration.BaseList != null && classDeclaration.BaseList.Types.Any())
            {
                var fullBaseName = classDeclaration.BaseList.Types.First().Type.ToString();
                var simpleBaseName = fullBaseName.Split('.').Last().Trim();
                classDetails.BaseTypeName = simpleBaseName;
            }

            // Process each public property declared in this record.
            var propDeclarations = classDeclaration.Members.OfType<PropertyDeclarationSyntax>();
            var properties = GetProperties(recordSymbol, propDeclarations, semanticModel);
            classDetails.Properties = properties;

            var methodDeclarations = classDeclaration.Members.OfType<MethodDeclarationSyntax>();
            var methods = GetMethods(methodDeclarations, semanticModel);
            classDetails.Methods = methods;

            var constructorDeclarations = classDeclaration.Members.OfType<ConstructorDeclarationSyntax>();
            var constructors = GetConstructors(classDeclaration.Identifier.Text, constructorDeclarations, semanticModel);
            classDetails.Constructors = constructors;

            var operatorDeclarations = classDeclaration.Members.OfType<ConversionOperatorDeclarationSyntax>();
            var conversionOperators = GetConversionOperators(operatorDeclarations, semanticModel);
            classDetails.ConversionOperators = conversionOperators;

            return classDetails;
        }

        private static List<MethodDocumentation> GetConversionOperators(IEnumerable<ConversionOperatorDeclarationSyntax> operatorDeclarations, SemanticModel semanticModel)
        {
            var operators = new List<MethodDocumentation>();
            foreach (var operatorDeclaration in operatorDeclarations)
            {
                if (semanticModel.GetDeclaredSymbol(operatorDeclaration) is not IMethodSymbol operatorSymbol || operatorSymbol.DeclaredAccessibility != Accessibility.Public)
                {
                    continue;
                }

                var signature = $"{operatorSymbol.ReturnType.ToDisplayString()} {operatorSymbol.Name}{operatorDeclaration.ParameterList}";
                var simpleSignature = $"{operatorSymbol.Name}{operatorDeclaration.ParameterList}";
                var basicSignature = $"{operatorSymbol.Name}({string.Join(", ", operatorSymbol.Parameters.Select(p => p.Type.ToDisplayString()))})";

                var methodDocComment = XmlDocumentationHelper.GetDocumentationComment(operatorDeclaration.GetLeadingTrivia(), semanticModel);

                var memberDetails = new MemberDetails
                {
                    SummaryFragments = methodDocComment.SummaryFragments,
                    ReturnsFragments = methodDocComment.ReturnsFragments,
                    SeeAlso = methodDocComment.SeeAlso,
                    ReturnType = operatorSymbol.ReturnType.Name
                };

                foreach (var param in operatorSymbol.Parameters)
                {
                    var parameter = methodDocComment.ParameterDocumentation.Find(p => p.Name == param.Name);
                    memberDetails.Parameters.Add(new ParameterDetails
                    {
                        Name = param.Name,
                        DefaultValue = param.HasExplicitDefaultValue ? param.ExplicitDefaultValue?.ToString() ?? "null" : null,
                        DocumentationFragments = parameter?.DocumentationFragments ?? [],
                        IsOptional = param.IsOptional,
                        Type = param.Type.ToDisplayString(),
                    });
                }

                operators.Add(new MethodDocumentation
                {
                    Name = operatorSymbol.Name,
                    Signature = signature,
                    SimpleSignature = simpleSignature,
                    BasicSignature = basicSignature,
                    Documentation = memberDetails
                });
            }

            return operators;
        }

        public static List<ConstructorDetails> GetConstructors(string identifier, IEnumerable<ConstructorDeclarationSyntax> constructorDeclarations, SemanticModel semanticModel)
        {
            var constructorDetailsList = new List<ConstructorDetails>();

            foreach (var constructorDeclaration in constructorDeclarations)
            {
                if (semanticModel.GetDeclaredSymbol(constructorDeclaration) is not IMethodSymbol constructorSymbol || (constructorSymbol.DeclaredAccessibility != Accessibility.Public && constructorSymbol.DeclaredAccessibility != Accessibility.Protected))
                {
                    continue;
                }

                var signature = $"{identifier}{constructorDeclaration.ParameterList}";

                // Parse constructor documentation.
                var ctorDocComment = XmlDocumentationHelper.GetDocumentationComment(constructorDeclaration.GetLeadingTrivia(), semanticModel);
                var ctorDetails = new MemberDetails
                {
                    SummaryFragments = ctorDocComment.SummaryFragments,
                    ReturnsFragments = ctorDocComment.ReturnsFragments,
                    SeeAlso = ctorDocComment.SeeAlso,
                };

                foreach (var param in constructorSymbol.Parameters)
                {
                    var parameter = ctorDocComment.ParameterDocumentation.Find(p => p.Name == param.Name);
                    ctorDetails.Parameters.Add(new ParameterDetails
                    {
                        Name = param.Name,
                        DefaultValue = param.HasExplicitDefaultValue ? param.ExplicitDefaultValue?.ToString() ?? "null" : null,
                        DocumentationFragments = parameter?.DocumentationFragments ?? [],
                        IsOptional = param.IsOptional,
                        Type = param.Type.ToDisplayString(),
                    });
                }

                constructorDetailsList.Add(new ConstructorDetails
                {
                    Signature = signature,
                    Documentation = ctorDetails
                });
            }

            return constructorDetailsList;
        }

        public static EnumDocumentation? GetEnumDocumentation(EnumDeclarationSyntax enumDeclaration, SemanticModel semanticModel)
        {
            if (semanticModel.GetDeclaredSymbol(enumDeclaration) is not INamedTypeSymbol enumSymbol || enumSymbol.DeclaredAccessibility != Accessibility.Public)
            {
                return null;
            }

            var docCommentEnum = XmlDocumentationHelper.GetDocumentationComment(enumDeclaration.GetLeadingTrivia(), semanticModel);
            var enumDoc = new EnumDocumentation
            {
                Name = enumDeclaration.Identifier.Text,
                SummaryFragments = docCommentEnum.SummaryFragments
            };

            // Process each enum member.
            foreach (var member in enumDeclaration.Members)
            {
                var memberSymbol = semanticModel.GetDeclaredSymbol(member);
                if (memberSymbol == null || memberSymbol.DeclaredAccessibility != Accessibility.Public)
                {
                    continue;
                }

                var memberDocComment = XmlDocumentationHelper.GetDocumentationComment(member.GetLeadingTrivia(), semanticModel);
                var memberDoc = new EnumMemberDocumentation
                {
                    Name = member.Identifier.Text,
                    SummaryFragments = memberDocComment.SummaryFragments
                };

                // Extract JSON value from attributes if available.
                foreach (var attrList in member.AttributeLists)
                {
                    foreach (var attr in attrList.Attributes)
                    {
                        var attrName = attr.Name.ToString();
                        if (attrName.Contains("JsonStringEnumMemberName") && attr.ArgumentList?.Arguments.Count > 0)
                        {
                            var argExpr = attr.ArgumentList.Arguments.First().Expression;
                            if (argExpr is LiteralExpressionSyntax literal &&
                                literal.IsKind(SyntaxKind.StringLiteralExpression))
                            {
                                memberDoc.JsonValue = literal.Token.ValueText;
                            }
                        }
                    }
                }

                enumDoc.Members.Add(memberDoc);
            }

            return enumDoc;
        }

        public static List<MethodDocumentation> GetMethods(IEnumerable<MethodDeclarationSyntax> methodDeclarations, SemanticModel semanticModel)
        {
            var methods = new List<MethodDocumentation>();
            foreach (var methodDeclaration in methodDeclarations)
            {
                if (semanticModel.GetDeclaredSymbol(methodDeclaration) is not IMethodSymbol methodSymbol || methodSymbol.DeclaredAccessibility != Accessibility.Public)
                {
                    continue;
                }

                var signature = $"{methodSymbol.ReturnType.ToDisplayString()} {methodSymbol.Name}{methodDeclaration.ParameterList}";
                var simpleSignature = $"{methodSymbol.Name}{methodDeclaration.ParameterList}";
                var basicSignature = $"{methodSymbol.Name}({string.Join(", ", methodSymbol.Parameters.Select(p => p.Type.ToDisplayString()))})";

                var methodDocComment = XmlDocumentationHelper.GetDocumentationComment(methodDeclaration.GetLeadingTrivia(), semanticModel);

                var memberDetails = new MemberDetails
                {
                    SummaryFragments = methodDocComment.SummaryFragments,
                    ReturnsFragments = methodDocComment.ReturnsFragments,
                    SeeAlso = methodDocComment.SeeAlso,
                    ReturnType = methodSymbol.ReturnType.Name,
                    IsStatic = methodSymbol.IsStatic,
                    Exception = methodDocComment.Exception,
                };

                foreach (var param in methodSymbol.Parameters)
                {
                    var parameter = methodDocComment.ParameterDocumentation.Find(p => p.Name == param.Name);
                    memberDetails.Parameters.Add(new ParameterDetails
                    {
                        Name = param.Name,
                        DefaultValue = param.HasExplicitDefaultValue ? param.ExplicitDefaultValue?.ToString() ?? "null" : null,
                        DocumentationFragments = parameter?.DocumentationFragments ?? [],
                        IsOptional = param.IsOptional,
                        Type = param.Type.ToDisplayString(),
                    });
                }

                methods.Add(new MethodDocumentation
                {
                    Name = methodSymbol.Name,
                    Signature = signature,
                    SimpleSignature = simpleSignature,
                    BasicSignature = basicSignature,
                    Documentation = memberDetails
                });
            }

            return methods;
        }

        public static RecordDetails? GetRecordDocumentation(RecordDeclarationSyntax recordDeclaration, SemanticModel semanticModel)
        {
            if (semanticModel.GetDeclaredSymbol(recordDeclaration) is not INamedTypeSymbol recordSymbol || recordSymbol.DeclaredAccessibility != Accessibility.Public)
            {
                return null;
            }

            // Parse the record's XML documentation.
            var docComment = XmlDocumentationHelper.GetDocumentationComment(recordDeclaration.GetLeadingTrivia(), semanticModel);
            // Create a new RecordDetails object inline.
            var recordDetails = new RecordDetails
            {
                Name = recordDeclaration.Identifier.Text,
                SummaryFragments = docComment.SummaryFragments,
                SeeAlso = docComment.SeeAlso,
                TypeParameters = recordSymbol.TypeParameters.Select(t => t.Name).ToList(),
                IsAbstract = recordSymbol.IsAbstract,
            };

            // If the record inherits from a base type, store the simple base type name.
            if (recordDeclaration.BaseList != null && recordDeclaration.BaseList.Types.Any())
            {
                var fullBaseName = recordDeclaration.BaseList.Types.First().Type.ToString();
                var simpleBaseName = fullBaseName.Split('.').Last().Trim();
                recordDetails.BaseTypeName = simpleBaseName;
            }

            // Process each public property declared in this record.
            var propDeclarations = recordDeclaration.Members.OfType<PropertyDeclarationSyntax>();
            var properties = GetProperties(recordSymbol, propDeclarations, semanticModel);
            recordDetails.Properties = properties;

            var methodDeclarations = recordDeclaration.Members.OfType<MethodDeclarationSyntax>();
            var methods = GetMethods(methodDeclarations, semanticModel);
            recordDetails.Methods = methods;

            var constructorDeclarations = recordDeclaration.Members.OfType<ConstructorDeclarationSyntax>();
            var constructors = GetConstructors(recordDeclaration.Identifier.Text, constructorDeclarations, semanticModel);
            recordDetails.Constructors = constructors;

            return recordDetails;
        }

        private static List<PropertyDocumentation> GetProperties(INamedTypeSymbol typeSymbol, IEnumerable<PropertyDeclarationSyntax> propertyDeclarations, SemanticModel semanticModel)
        {
            var properties = new List<PropertyDocumentation>();
            foreach (var propertyDeclaration in propertyDeclarations)
            {
                if (semanticModel.GetDeclaredSymbol(propertyDeclaration) is not IPropertySymbol propSymbol || propSymbol.DeclaredAccessibility != Accessibility.Public)
                {
                    continue;
                }
                // Only include properties declared on this record.
                var isDeclaredHere = propSymbol.DeclaringSyntaxReferences.Any(r =>
                {
                    var syntax = r.GetSyntax();
                    return syntax.Parent is RecordDeclarationSyntax parentRecord &&
                           SymbolEqualityComparer.Default.Equals(semanticModel.GetDeclaredSymbol(parentRecord), typeSymbol) || syntax.Parent is ClassDeclarationSyntax parentClass &&
                           SymbolEqualityComparer.Default.Equals(semanticModel.GetDeclaredSymbol(parentClass), typeSymbol);
                });
                if (!isDeclaredHere)
                {
                    continue;
                }

                string? jsonPropertyName = null;
                var jsonAttr = propSymbol.GetAttributes().FirstOrDefault(a => a.AttributeClass?.Name == "JsonPropertyNameAttribute");
                if (jsonAttr != null && jsonAttr.ConstructorArguments.Length > 0)
                {
                    jsonPropertyName = jsonAttr.ConstructorArguments[0].Value as string;
                }

                var propDocComment = XmlDocumentationHelper.GetDocumentationComment(propertyDeclaration.GetLeadingTrivia(), semanticModel);
                var propDoc = new PropertyDocumentation
                {
                    Name = propertyDeclaration.Identifier.Text,
                    Type = propSymbol.Type.ToDisplayString(),
                    JsonPropertyName = jsonPropertyName,
                    SummaryFragments = propDocComment.SummaryFragments,
                    IsStatic = propSymbol.IsStatic,
                    SeeAlso = propDocComment.SeeAlso,
                };

                properties.Add(propDoc);
            }

            return properties;
        }
    }
}
