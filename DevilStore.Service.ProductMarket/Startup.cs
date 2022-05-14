using DevilStore.ProductMarket.Flow;
using DevilStore.ProductMarket.Flow.Data;
using DevilStore.Service.ProductMarket;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace DevilStore.Service.IdentityServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            Configuration = configuration;
            HostEnvironment = hostEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiVersioning();
            //services.AddCors();

            services.AddControllers();
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DevilStore", Version = "v1" });
            });

            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DevilDBContext>(options =>
                options.UseSqlServer(connection));

            services.AddMarketProductFlow(Configuration);


            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                    .SetIsOriginAllowed(x => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("Content-Disposition")
                    .AllowCredentials();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseCors("CorsPolicy");
            app.UseStaticFiles();
            if (HostEnvironment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevilStore v1"));
            }

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseRouting();

            // security - Order Matters !!!
            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();//.RequireAuthorization();
            });

        }

        public IConfiguration Configuration { get; }
        public IHostEnvironment HostEnvironment { get; }
    }
}
