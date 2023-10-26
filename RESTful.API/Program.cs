using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RESTful.API.Business.MappingConfigurations;
using RESTful.API.Business.Services;
using RESTful.API.Data;
using RESTful.API.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// AutoMapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new GeneralMappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services
builder.Services.AddTransient<IUserTypeService, UserTypeService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IBaseService, BaseService>();


// add AddDbContext with connection string from appsettings.json
builder.Services.AddDbContext<DatabaseContext>(
    optionsAction => optionsAction
        .UseSqlServer(builder.Configuration.GetConnectionString("Default"))
        //.EnableSensitiveDataLogging()
);

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
