using Microsoft.EntityFrameworkCore;
using REST_Test.Business.Mappings;
using REST_Test.Business.Services;
using REST_Test.Business.Services.Interface;
using REST_Test.Data.Data;
using REST_Test.Model.Repositories;

/// <summary>
/// Startup class.
/// </summary>
public class Startup
{
    /// <summary>
    /// Initialization of startup class.
    /// </summary>
    /// <param name="configuration">Configuration instance.</param>
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    /// <summary>
    /// Configuration property.
    /// </summary>
    public IConfiguration Configuration { get; }

    /// <summary>
    /// Configure services.
    /// </summary>
    /// <param name="services">service collection dependency injection.</param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

        services.AddDbContext<RESTTestContext>(options =>
        {
            options.UseNpgsql(Configuration.GetConnectionString("RESTTestContext"));
        });

        services.AddSwaggerGen();

        //// AutoMapper Configuration
        services.AddAutoMapper(typeof(MappingProfile));

        //// Generic Repository
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        //// Generic Services
        services.AddScoped(typeof(IReadServiceAsync<,>), typeof(ReadServiceAsync<,>));
        services.AddScoped(typeof(IGenericServiceAsync<,>), typeof(GenericServiceAsync<,>));


        services.AddMvc();
    }

    /// <summary>
    /// Configure override method.
    /// </summary>
    /// <param name="app">App builder</param>
    /// <param name="environment">Host env.</param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
    {
        if (environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseSwagger();
        app.UseSwaggerUI();


        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

    }
}
