using Microsoft.EntityFrameworkCore;
using Infrastructure.Layer;
using Infrastructure.ServiceExtension;
using Infrastructure.Repositories;
using Application.Interfaces;
using PersonApi;
using PersonApi.Middlewares;
using PersonApi.Filters;
using AutoMapper;
using Application.Mapper;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<DataContext>(options =>
//        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddInfrastructureLayer();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>c.UseAllOfToExtendReferenceSchemas() 
);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICityInterface, CityRepository>();
builder.Services.AddScoped<IPersonInterface, PersonRepository>();
builder.Services.AddScoped<IConnectedPersonInterface, ConnectedPersonRepository>();
builder.Services.AddScoped<IPhoneInterface, PhoneRepository>();
builder.Services.AddScoped<ISharedPhoneInterface, SharedPhoneRepository>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
});
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<AutoProfile>();
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddLocalization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseMiddleware<LocalizationMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
