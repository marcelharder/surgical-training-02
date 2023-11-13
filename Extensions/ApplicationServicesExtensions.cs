
using api.Helpers;

namespace api.Extensions;

public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            var _connectionString = config.GetConnectionString("SQLConnection");

               services.AddDbContext<dataContext>(
                options => options.UseMySql(
                    _connectionString,
                    ServerVersion.AutoDetect(_connectionString),
                    options => options.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: System.TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null
                    )
                ) 
            );  
            services.AddTransient<MySqlConnection>(_ => new MySqlConnection(config["ConnectionStrings:SQLConnection"]));

            services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
            services.Configure<ComSettings>(config.GetSection("ComSettings"));



            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IEpaService, EpaService>();
            services.AddScoped<SpecialMaps>();
            services.AddScoped<Dropdownlists>();
            services.AddSingleton<DapperContext>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IProcedureService, ProcedureService>();
            services.AddScoped<IDapperCourseService, DapperCourseService>();
          

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            return services;
        }
    }
