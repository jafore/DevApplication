using System.Text;
using DevApplication.Connection;
using DevApplication.Repository.IRepository;
using DevApplication.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DatabaseConnection")
));


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
            .AddJwtBearer(options =>
            {

                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {

                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        corsPolicyBuilder => {
            corsPolicyBuilder.WithOrigins("*"
                                               // "http://localhost",
                                               // "http://localhost:5258/",
                                               // "http://localhost:200"
                                               )

                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .SetIsOriginAllowedToAllowWildcardSubdomains();
                      });


});

builder.Services.AddControllers();





// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();





builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description =
            "JWT Authorization . Write Bearer[Space][Token] . \n\r\n",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer"
    });


    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference= new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme, 
                    Id="Bearer"
                },
                Scheme="oath2",
                Name="Bearer",
                In=ParameterLocation.Header,
                
            },
            new List<string>()
        }
    });

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1.0",
        Title = "Hospital Api",
        Description ="Product Api is build with JWT Token",
        TermsOfService = new Uri("https://example.com/api"),
        Contact = new OpenApiContact
        {
            Name = "This is By Taohid Imdad",
            Url = new Uri("https://example.com/api")
        },
        License = new OpenApiLicense
        {
            Name = "this license is for Test Use",
            Url = new Uri("https://example.com/api")
        }

    });

});



// builder.Services.AddApiVersioning(options =>
// {
//     options.AssumeDefaultVersionWhenUnspecified = true;
//     options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
//     //report api version
//     options.ReportApiVersions = true;
// });













var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{


    app.UseSwagger();
    app.UseSwaggerUI();




//}



app.UseStaticFiles();// For the wwwroot folder

app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);



app.UseHttpsRedirection();

app.UseAuthentication();
//app.UseSession();
app.UseAuthorization();

app.MapControllers();

app.Run();




