using FinalDemo.Data;
using FinalDemo.Mapping;
using FinalDemo.Repos.Implemention;
using FinalDemo.Repos.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Maperr));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContextt>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("DafoultConnection")));
builder.Services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
builder.Services.AddScoped<IUnitOffWork, UnitOffwork>();
builder.Services.AddAutoMapper(typeof(Maperr));
builder.Services.AddScoped<IProudactRepo, ProudactRepo>();
builder.Services.AddScoped<IOrderrepo, Orderrepo>();
builder.Services.AddAuthentication("Bearer").AddJwtBearer(op =>
{
    op.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issure"],
        ValidAudience = builder.Configuration["Jwt:Audiense"],

        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secretkey"]))

    };
});
var app = builder.Build();
app.UseAuthentication();
app.UseAuthentication();

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
