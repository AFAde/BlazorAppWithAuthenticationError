using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorAppWithAuthentication
{
    public class AuthenticationInfoService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthenticationInfoService(AuthenticationStateProvider authenticationStateProvider)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<AuthenticationState> Test()
        {
            await Task.Delay(100).ConfigureAwait(false);
            return await _authenticationStateProvider.GetAuthenticationStateAsync();
        }
    }
}
