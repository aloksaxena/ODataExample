using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.OpenApi.Models;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.Configure<JsonSerializerOptions>(options =>
{
	options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
	options.Converters.Add(new JsonStringEnumConverter());
	options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen(setupAction =>
//{
//	setupAction.SwaggerDoc("Coles-PoC", new OpenApiInfo { Title = "PoC - Alok", Version = "v1" });
//	setupAction.DescribeAllParametersInCamelCase();
//	//setupAction.EnableAnnotations();
//	setupAction.IgnoreObsoleteProperties();

//});

var app = builder.Build();
app.UseDeveloperExceptionPage();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	//app.UseSwaggerUI(options =>
	//{
	//	options.SwaggerEndpoint("/swagger/v1/swagger.json", "Coles.PoC");

	//});
}

app.UseHttpsRedirection();

app.UseAuthorization();
//app.UseResponseCompression();
app.MapControllers();

app.Run();
