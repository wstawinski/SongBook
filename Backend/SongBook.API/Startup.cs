using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SongBook.Domain.Interfaces;
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

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options => 
                    options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter()));

            services.AddDbContext<SongBookDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnectionString")));

            services.AddScoped<IChordRepository, ChordRepository>();
            services.AddScoped<IChordManager, ChordManager>();
            services.AddScoped<ISongRepository, SongRepository>();
            services.AddScoped<ISongManager, SongManager>();
            services.AddScoped<ISongFileRepository, SongFileRepository>();
            services.AddScoped<ISongFileManager, SongFileManager>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IIdeaRepository, IdeaRepository>();
            services.AddScoped<IIdeaManager, IdeaManager>();
        }

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
