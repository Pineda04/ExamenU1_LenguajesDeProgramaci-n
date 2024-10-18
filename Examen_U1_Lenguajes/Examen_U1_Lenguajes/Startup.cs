using System.Text;
using Examen_U1_Lenguajes.Database;
using Examen_U1_Lenguajes.Helpers;
using Examen_U1_Lenguajes.Services;
using Examen_U1_Lenguajes.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Examen_U1_Lenguajes
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHttpContextAccessor(); // Validar

            var name = Configuration.GetConnectionString("DefaultConnection");

            // Add DbContext
            services.AddDbContext<ExamenContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Add custom services
            services.AddTransient<IDepartmentsService, DepartmentsService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IJobTitlesService, JobTitlesService>();
            services.AddTransient<IAuditService, AuditService>();
            services.AddTransient<IPermissionTypesService, PermissionTypesService>();
            services.AddTransient<IRequestsService, RequestsService>();

            // Add Identity
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
            }).AddEntityFrameworkStores<ExamenContext>()
              .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });

            // Add AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile));

            // CORS Configuration
            // services.AddCors(opt =>
            // {
            //     var allowURLS = Configuration.GetSection("AllowURLS").Get<string[]>();

            //     opt.AddPolicy("CorsPolicy", builder => builder
            //     .WithOrigins(allowURLS)
            //     .AllowAnyMethod()
            //     .AllowAnyHeader()
            //     .AllowCredentials());
            // });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}