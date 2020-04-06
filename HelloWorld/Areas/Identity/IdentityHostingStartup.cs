using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcAgenda.Areas.Identity.Data;
using MvcAgenda.Data;

[assembly: HostingStartup(typeof(MvcAgenda.Areas.Identity.IdentityHostingStartup))]
namespace MvcAgenda.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MvcAgendaDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MvcAgendaDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                        .AddEntityFrameworkStores<MvcAgendaDbContext>();
            });
        }
    }
}