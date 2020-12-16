using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorAppWithAuthentication
{
    public class AuthTokenHandler : DelegatingHandler
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthTokenHandler(AuthenticationStateProvider authenticationStateProvider)
        {
            _authenticationStateProvider = authenticationStateProvider ?? throw new ArgumentNullException(nameof(authenticationStateProvider));
            _authenticationStateProvider = authenticationStateProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request));
            var token = await _authenticationStateProvider.GetAuthenticationStateAsync();
            //just as example
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer",
                                                                          token.ToString());

            return await base.SendAsync(request,
                                        cancellationToken)
                             .ConfigureAwait(false);
        }
    }
}
