using DesignPattern.Model.ApiVersion;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerGenOption => {
            typeof(ApiVersion).GetEnumNames().ToList().ForEach(v =>
                {
                    swaggerGenOption.SwaggerDoc(v, new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "Demo", Version = v });
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    swaggerGenOption.IncludeXmlComments(xmlPath);
                }
            );
        }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(swaggerUIOption =>
    {
        typeof(ApiVersion).GetEnumNames().ToList().ForEach(version =>
        {
            swaggerUIOption.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"Demo({version})");
        });
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
