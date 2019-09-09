using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BZM.SCRM.IdentityServer
{
    public class ProfileService: IProfileService
    {
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            try
            {
                var cliams = context.Subject.Claims.ToList();

                context.IssuedClaims = cliams.ToList();
            }
            catch (Exception ex)
            {

               
            }
        }
        public async Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
        }
    }
}
