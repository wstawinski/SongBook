using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SongBook.Domain.Interfaces.Manager;
using SongBook.Domain.Interfaces.Repository;
using SongBook.Domain.Managers;
using SongBook.Repo;
using SongBook.Repo.Repositories;

namespace SongBook.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                });

            services.AddDbContext<SongBookDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnectionString")));

            services.AddScoped<IPerformerRepository, PerformerRepository>();
            services.AddScoped<ISongRepository, SongRepository>();
            services.AddScoped<IChordRepository, ChordRepository>();

            services.AddScoped<IPerformerManager, PerformerManager>();
            services.AddScoped<ISongManager, SongManager>();
            services.AddScoped<IChordManager, ChordManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
