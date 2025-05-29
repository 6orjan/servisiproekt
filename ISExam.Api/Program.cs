using AutoMapper;
using ISExam.Api.Infrastructure;
using ISExam.Data;
using ISExam.Data.Interfaces;
using ISExam.Data.Repositories;
using ISExam.Service.Interfaces;
using ISExam.Service.Profiles;
using ISExam.Service.Services;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static IConfiguration Configuration { get; set; }
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory
            .GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        Configuration = configuration;

        builder.Services.Configure<ConnectionStrings>(Configuration
            .GetSection("ConnectionStrings")
        );

        builder.Services.AddDbContextPool<MainContext>((ServiceProvider, options) =>
        {
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly("ISExam.Data")
            );
        });

        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new ClientProfile());
            mc.AddProfile(new MovieProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();

        builder.Services.AddSingleton(mapper);

        builder.Services.AddScoped<IClientRepository, ClientRepository>();
        builder.Services.AddScoped<IMovieRepository, MovieRepository>();

        builder.Services.AddScoped<IClientService, ClientService>();
        builder.Services.AddScoped<IMovieService, MovieService>();

        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

    }
}

