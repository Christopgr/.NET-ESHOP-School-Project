using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ncs2019_team_TBD.Data;
using ncs2019_team_TBD.Models;

[assembly: HostingStartup(typeof(ncs2019_team_TBD.Areas.Identity.IdentityHostingStartup))]
namespace ncs2019_team_TBD.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}