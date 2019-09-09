using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BZM.SCRM.IdentityServer
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource> {
                new IdentityResources.OpenId(),//必须要添加，否则报无效的scope错误
                new IdentityResources.Profile()
            };
        }
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api1","车服云平台API")
            };
        }
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client{
                    ClientId="web_client",
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                    ClientSecrets=
                    {
                        new Secret("secret".Sha256())
                    },
                    AccessTokenLifetime=43200,
                    AllowedScopes={"api1", IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile},
                },
                new Client{
                    ClientId="wx_client",
                    AllowedGrantTypes={ "wx"},
                    ClientSecrets=
                    {
                        new Secret("secret".Sha256())
                    },
                    AccessTokenLifetime=43200,
                    AllowedScopes={"api1"},
                }
            };
        }
    }
}
