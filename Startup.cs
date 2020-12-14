using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorDesktopDemo.Data;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.EntityFrameworkCore;
using Toolbelt.Blazor.Extensions.DependencyInjection;

namespace BlazorDesktopDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IFilesService,FilesService>();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite("Data source = ToDoItems.db");
            });

            services.AddHeadElementHelper();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
            Task.Run(async () => await Electron.WindowManager.CreateWindowAsync(new BrowserWindowOptions
            {
                Width = 840,
                Height = 640,

            }));
            // if (HybridSupport.IsElectronActive)
            // {
            //     ElcatronBootstrap();
            // }
        }
        void ElcatronBootstrap()
        {
            Task.Run(async () => await Electron.WindowManager.CreateWindowAsync(
                new BrowserWindowOptions
                {
                    Width = 800,
                    Height = 640,                   

                }
                ));
            
            var menu = new MenuItem[]
            {
                new MenuItem
                {
                    Label = "File",
                    Type = MenuType.submenu,
                    Submenu = new MenuItem[]
                    {
                        new MenuItem
                        {
                            Label = "New",
                            Click = async () =>await Electron.Dialog.ShowMessageBoxAsync("New menu clicked"),


                        },
                        new MenuItem
                        {

                            Type = MenuType.separator,
                        },
                        new MenuItem
                        {
                            Label = "Exit",
                            Role = MenuRole.close

                        }

                    }
                },
                new MenuItem
                {
                    Label = "Edit",
                    Submenu = new MenuItem[]
                    {
                        new MenuItem
                        {
                            Label = "Test",
                            Click = async () => await Electron.Dialog.ShowMessageBoxAsync("Test Menu Clicked"),
                            Accelerator = "CmdOrCtrl+T"
                        }

                    }

                }
                
            };
            Electron.Menu.SetApplicationMenu(menu);
            //Electron.WindowManager.CreateWindowAsync(new BrowserWindowOptions
            //{
            //    Width = 1152,
            //    Height = 940,
            //    Show = false
            //}); 
            
        }
    }
}
