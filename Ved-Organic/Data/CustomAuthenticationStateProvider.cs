using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace Ved_Organic.Data
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {


        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
                var identity = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, "rpneha11@gmail.com"),
                new Claim(ClaimTypes.Role,"Admin")
        }, "apiauth_type");

            var user = new ClaimsPrincipal(identity);

            return Task.FromResult(new AuthenticationState(user));
        } 
    }
}
