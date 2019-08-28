using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public static class IdentitySeedData
    {
        private const string adminUsr = "Admin";
        private const string adminPwd = "Secret123$";

        public static async void EnsurePopulated( IApplicationBuilder app)
        {
            UserManager<IdentityUser> userManager = app.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser user = await userManager.FindByIdAsync( adminUsr );
            if ( user != null )
            {
                user = new IdentityUser( "Admin" );
                await userManager.CreateAsync( user, adminPwd );
            }
        }
    }
}
