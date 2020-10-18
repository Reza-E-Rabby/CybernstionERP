using CSERP.DATA.Infrastructure;
using CSERP.DATA.Infrastructure.HRM.CommandHandlers;
using CSERP.DATA.Infrastructure.HRM.Commands;
using CSERP.DATA.Infrastructure.HRM.Queries;
using CSERP.DATA.Infrastructure.HRM.QueryHandlers;
using CSERP.MODELS.Models.HRM;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace CSERP.WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            RepoDb.SqlServerBootstrap.Initialize();

            services.AddScoped<ICommandHandler<CreateHRMCompanyCommand>, CreateHRMCompanyCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateHRMCompanyCommand>, UpdateHRMCompanyCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteHRMCompanyCommand>, DeleteHRMCompanyCommandHandler>();
            services.AddScoped<IQueryHandler<GetAllHRMCompanyQuery, IEnumerable<HRMCompanyInfo>>, GetAllHRMCompanyQueryHandler>();
            services.AddScoped<IQueryHandler<GetSingleHRMCompanyQuery, HRMCompanyInfo>, GetSingleHRMCompanyQueryHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
