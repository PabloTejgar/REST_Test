using Microsoft.EntityFrameworkCore;
using REST_Test.Data.Data;

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

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
