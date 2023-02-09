using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorAppWithAuthentication
{
    public class AuthTokenHandler : DelegatingHandler
    {
        private readonly BlazorServiceAccessor _blazorServiceAccessor;

        public AuthTokenHandler(BlazorServiceAccessor accessor, IServiceProvider services)
        {
            _blazorServiceAccessor = accessor ?? throw new ArgumentNullException(nameof(accessor));
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request));

            var authService = _blazorServiceAccessor.Services
                                                    .GetRequiredService<AuthenticationStateProvider>();
            var token = await authService.GetAuthenticationStateAsync();
            //just as example
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer",
                                                                          token.ToString());

            return await base.SendAsync(request,
                                        cancellationToken)
                             .ConfigureAwait(false);
        }
    }
}
