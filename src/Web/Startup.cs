namespace MoviesApp.Web
{
    using System;
    using Data.Contracts;
    using MoviesApp.Data.Models;
    using MoviesApp.Data.Models.Categories;
    using MoviesApp.Data.Models.Movies;
    using Services.DataServices;
    using Services.DataServices.Contracts;
    using Services.Mapping;
    using ViewModels.Categories;
    using ViewModels.Movies;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Services.Seeders;
    using Data;
    using Helpers;
    using Helpers.Contracts;

    //Using=s
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AutoMapperConfig.RegisterMappings(
                typeof(CreateMovieViewModel).Assembly,
                typeof(Movie).Assembly,
                typeof(DetailsCategoryViewModel).Assembly,
                typeof(Category).Assembly,
                typeof(DetailsMovieViewModel).Assembly
            );
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<MoviesAppContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<MoviesAppUser, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 0;
                })
                .AddDefaultTokenProviders()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<MoviesAppContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddScoped<IActorsService, ActorsService>();
            services.AddScoped<IAnimesService, AnimesService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IMoviesService, MoviesService>();
            services.AddScoped<IMoviesActorsService, MoviesActorsService>();
            services.AddScoped<IMoviesCategoriesService, MoviesCategoriesService>();
            services.AddScoped<ISeriesService, SeriesService>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<ISeriesEntityService, SeriesEntityService>();
            services.AddScoped<IPagerService, PagerService>();
            services.AddScoped<IRenderService, RenderService>();
            services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public  void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            RolesSeederService.CreateRoles(serviceProvider, this.Configuration).Wait();
        }
    }
}
