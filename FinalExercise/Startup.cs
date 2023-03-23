using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using FinalExercise.Data;
using FinalExercise.Domain.Interfaces;
using FinalExercise.Repositories;
using AutoMapper;
using FinalExercise.DTOs;
using FinalExercise.Services;

namespace FinalExercise
{
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
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ITravelPackageRepository, TravelPackageRepository>();
            services.AddTransient<ICommissionRepository, CommissionRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICommissionService, CommissionService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FinalExercise", Version = "v1" });
            });

            services.AddDbContext<FinalExerciseContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("FinalExerciseContext")));

            // Auto Mapper Configurations
            
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddMvc();

            string databaseName = Configuration.GetSection("CosmosDb").GetSection("DatabaseName").Value;
            string clientContainer = Configuration.GetSection("CosmosDb").GetSection("ClientContainerName").Value;
            string configurationContainer = Configuration.GetSection("CosmosDb").GetSection("ConfigurationContainerName").Value;
            string account = Configuration.GetSection("CosmosDb").GetSection("Account").Value;
            string key = Configuration.GetSection("CosmosDb").GetSection("Key").Value;
            Microsoft.Azure.Cosmos.CosmosClient client = new Microsoft.Azure.Cosmos.CosmosClient(account, key);
            
            CosmosDbClientService cosmosDbClientService = new CosmosDbClientService(client, databaseName, clientContainer);
            CosmosDbConfigurationService cosmosDbConfigurationService = new CosmosDbConfigurationService(client, databaseName, configurationContainer);

            CreateDatabase(client, databaseName, configurationContainer, clientContainer);
                        
            services.AddSingleton(cosmosDbClientService);
            services.AddSingleton(cosmosDbConfigurationService);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinalExercise v1"));
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("MyPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Client}/{action=Index}/{id?}");
            });
        }

        private static async void CreateDatabase(Microsoft.Azure.Cosmos.CosmosClient client, string databaseName, string configurationContainer, string clientContainer)
        {
            Microsoft.Azure.Cosmos.DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
            await database.Database.CreateContainerIfNotExistsAsync(clientContainer, "/id");
            await database.Database.CreateContainerIfNotExistsAsync(configurationContainer, "/id");
        }
    }
}
