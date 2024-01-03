using DataLayer.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RS-ERP", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme.",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
             new OpenApiSecurityScheme
               {
                  Reference = new OpenApiReference
                  {
                    Type = ReferenceType.SecurityScheme,
                     Id = "Bearer"
                   }
               },
         new string[] {}
        }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(C =>
{
    var Key = Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JsonWebTokenKeys:IssuerSigningKey").Value);
    C.SaveToken = true;
    C.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JsonWebTokenKeys:IssuerSigningKey").Value)),
        ValidIssuer = builder.Configuration.GetSection("JsonWebTokenKeys:ValidIssuer").Value,
        ValidAudience = builder.Configuration.GetSection("JsonWebTokenKeys:ValidAudience").Value,
        ClockSkew = TimeSpan.FromMinutes(Convert.ToInt32(builder.Configuration.GetSection("JsonWebTokenKeys:TokenExpiryMin").Value)),
    };
    C.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
                context.Response.Headers.Add("IS-TOKEN-EXPIRED", "true");
            }
            return Task.CompletedTask;
        }
    };
});

builder.Services.DIScope();
builder.Services.AddDbContext<DBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("EntitiesConnection")
    ));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.DefaultModelsExpandDepth(-1);
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
