using Microsoft.EntityFrameworkCore;
using SalesReport.Infrastructure;
using SalesReport.Domain.interfaces;
using SalesReport.Infrastructure.Repositories;
using SalesReport.Application.Service;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API SALES REPORT", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    c.EnableAnnotations();
});

builder.Services.AddDbContext<AdvWorksDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        opt => opt.MigrationsAssembly(typeof(AdvWorksDbContext).Assembly.FullName));   
});

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.Listen(IPAddress.Any, 7229, listenOptions =>
    {
        listenOptions.UseHttps();
    });
    options.Listen(IPAddress.Any, 8080);
});

builder.Services.AddTransient<ISalesODetailRepository, SaleODetailRepository>();
builder.Services.AddTransient<ISalesODetailService, SalesODetailService>();
builder.Services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddTransient<IProductCategoryService, ProductCategoryService>();
builder.Services.AddTransient<ISalesOHeaderRepository, SalesOHeaderRepository>();
builder.Services.AddTransient<ISalesOHeaderService, SalesOHeaderService>();
builder.Services.AddTransient<ISalesPersonNameRepository, SalesPersonNameRepository>();
builder.Services.AddTransient<ISalesPersonNameService, SalesPersonNameService>();
builder.Services.AddTransient<ICustomerNameRepository, CustomerNameRepository>();
builder.Services.AddTransient<ICustomerNameService, CustomerNameService>();

builder.Configuration.AddJsonFile("appsettings.json");
var secretKey = builder.Configuration.GetSection("settings").GetSection("secretKey").ToString();
var keyBytes = Encoding.UTF8.GetBytes(secretKey);

builder.Services.AddAuthentication(config => {

    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config => {
    config.RequireHttpsMetadata = false;
    config.SaveToken = false;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:3357")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

/*builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 7229;
});*/

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API SALES REPORT v1"));
}

app.UseHttpsRedirection();
app.UseCors("MyCorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
