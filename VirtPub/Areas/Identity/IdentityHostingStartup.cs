using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VirtPub.Areas.Identity.Data;

[assembly: HostingStartup(typeof(VirtPub.Areas.Identity.IdentityHostingStartup))]
namespace VirtPub.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            // builder.ConfigureServices((context, services) => {
            //     services.AddDbContext<VirtPubIdentityDbContext>(options =>
            //         options.UseSqlServer(
            //             context.Configuration.GetConnectionString("VirtPubIdentityDbContextConnection")));

            //     services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //         .AddEntityFrameworkStores<VirtPubIdentityDbContext>();
            // });
        }
    }
}
