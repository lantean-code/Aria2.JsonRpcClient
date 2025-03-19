using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Registry;

namespace Aria2.JsonRpcClient
{
    /// <summary>
    /// Extension methods for configuring the <see cref="IServiceCollection"/> for the <see cref="Aria2Client"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="Aria2Client"/> to the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configure">Allows configuring of the options.</param>
        /// <returns></returns>
        public static IServiceCollection AddAria2Client(this IServiceCollection services, Action<Aria2ClientOptions>? configure = null)
        {
            if (configure is not null)
            {
                services.Configure(configure);
            }

            services.AddHttpClient();

            services.AddSingleton<WebSocketConnectionManager>();
            services.AddSingleton<HttpGetRequestHandler>();

            services.AddSingleton<IAria2Client, Aria2Client>();
            services.AddSingleton<IRequestHandler>(sp =>
            {
                var options = sp.GetRequiredService<IOptions<Aria2ClientOptions>>();
                if (options.Value.ConnectionType == ConnectionType.WebSocket)
                {
                    return sp.GetRequiredService<WebSocketConnectionManager>();
                }
                else
                {
                    return sp.GetRequiredService<HttpGetRequestHandler>();
                }
            });

            services.AddSingleton<INotificationHandler>(sp =>
            {
                var options = sp.GetRequiredService<IOptions<Aria2ClientOptions>>();
                if (options.Value.ConnectionType == ConnectionType.WebSocket && options.Value.ReceiveNotifications)
                {
                    return sp.GetRequiredService<WebSocketConnectionManager>();
                }
                else
                {
                    return new NoOpNotificationHandler();
                }
            });

            services.Configure<PolicyRegistryOptions>(options =>
            {
                options.Policies["WebSocketPolicy"] = Policy.NoOpAsync();

                options.Policies["HttpGetPolicy"] = Policy.NoOpAsync();
            });

            // Register the PolicyRegistry itself.
            services.AddSingleton<IReadOnlyPolicyRegistry<string>>(sp =>
            {
                var options = sp.GetRequiredService<IOptions<PolicyRegistryOptions>>().Value;
                var registry = new PolicyRegistry();
                foreach (var policy in options.Policies)
                {
                    registry.Add(policy.Key, policy.Value);
                }
                return registry;
            });

            return services;
        }

        private class PolicyRegistryOptions
        {
            public Dictionary<string, IAsyncPolicy> Policies { get; } = new();
        }

        /// <summary>
        /// Adds a retry policy for WebSocket connections.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="policy"></param>
        /// <returns></returns>
        public static IServiceCollection AddWebSocketRetryPolicy(this IServiceCollection services, IAsyncPolicy policy)
        {
            services.Configure<PolicyRegistryOptions>(options =>
            {
                options.Policies["WebSocketPolicy"] = policy;
            });

            return services;
        }

        /// <summary>
        /// Adds a retry policy for HTTP GET requests.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="policy"></param>
        /// <returns></returns>
        public static IServiceCollection AddHttpGetRetryPolicy(this IServiceCollection services, IAsyncPolicy policy)
        {
            services.Configure<PolicyRegistryOptions>(options =>
            {
                options.Policies["HttpGetPolicy"] = policy;
            });

            return services;
        }
    }
}
