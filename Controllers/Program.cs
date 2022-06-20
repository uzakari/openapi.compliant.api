using Application.DI;
using Controllers.Middlewares;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
        {

            setupAction.SwaggerDoc("Compliantapi", new()
            {
                Title = "OpenApi Compliant",
                Version = "1",
                Description = "This a wrapper service to sovtech technical task apis",
                Contact = new() { Email = "uzakari2@gmail.com", Name = "uzakari", Url = new Uri("https://twitter.com/uzakari_2") }
            });

            var xmlPath = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, xmlPath);

            setupAction.IncludeXmlComments(path);

        } );

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();

app.UseSwaggerUI(setupAction =>
{
    setupAction.SwaggerEndpoint("/swagger/Compliantapi/swagger.json", "Compliantapi");
});

app.UseCustomExceptionHandler();

app.UseHttpsRedirection();

app.UseCors("Open");

app.UseAuthorization();

app.MapControllers();

app.Run();
