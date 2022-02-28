using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace PointOfSaleMicroservices.Identity.Core.Core
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
           new List<IdentityResource>
           {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Phone(),
                new IdentityResources.Address(),
                new(Constants.StandardScopes.Roles, new List<string> {"role"})
           };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope> 
            { 
                new(Constants.StandardScopes.PosApi) 
            };

        public static IList<ApiResource> ApiResources =>
            new List<ApiResource>
            {
                new(Constants.StandardScopes.PosApi)
                {
                    Scopes = 
                    {
                        Constants.StandardScopes.PosApi 
                    }
                }
            };

        public static IEnumerable<Client> Clients =>
        new List<Client>
        {
            new()
            {
                ClientId = "posapicode",
                ClientName = "Point Of Sale Customer Microservices API Code",
                AllowedGrantTypes = GrantTypes.Code,
                AlwaysIncludeUserClaimsInIdToken = false,
                RequirePkce = true,
                RequireClientSecret = false,
                RequireConsent = false,
                AllowRememberConsent = true,
                RedirectUris = new []
                {
                    "https://localhost:7017/signin-oidc",
                    "https://localhost:7017/swagger/signin-oidc",
                    "https://localhost:7017/LunchGeneralApi/swagger/oauth2-redirect.html"
                },
                PostLogoutRedirectUris = new []
                {
                    "https://localhost:7017/signout-callback-oidc",
                    "https://localhost:7017/swagger/signout-callback-oidc"
                },
                AllowedCorsOrigins = new []
                {
                    "https://localhost:7017"
                },
                AllowedScopes = {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    Constants.StandardScopes.PosApi
                }
            }
        };
    }
}
