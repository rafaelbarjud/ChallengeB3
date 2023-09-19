

using ChallengeB3.Services;
using ChallengeB3.Domain.Interfaces.Services;




var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddSingleton<ITaxService, TaxService>();
builder.Services.AddSingleton<ICdbService, CdbService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string CORSOpenPolicy = "OpenCORSPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(
      name: CORSOpenPolicy,
      builder => {
          builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
      });
});

var app = builder.Build();

app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value))
    {
        context.Request.Path = "/index.html";
        await next();
    }
});
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseCors(CORSOpenPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
