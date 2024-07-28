using Alaiala_API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.HandleGlobalExceptions();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
