namespace Beke.AdminService
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using EFPostgresEngagement.Extensions;
    using EFPostgresEngagement.Abstract;
    using GraphQLDoorNet.Extensions;
    using Data;
    using Data.MiddleLayers;
    using Schema;
    
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
            services.AddControllers();
            
            services
                .UsePostgresSql<BekeAdminDbContext>(this.Configuration)
                .AddTransient<GraphQLDoorNet.Abstracts.IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbTracker>(provider => new ApplicationUserProvider());
            
            services.AddGraphQLServices<Query, Mutation>();
            
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UpdateDatabase<BekeAdminDbContext>();

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}