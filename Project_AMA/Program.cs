using Microsoft.EntityFrameworkCore;
using Project_AMA.DB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen(opt => opt.EnableAnnotations());
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder of database
builder.Services.AddDbContext<ApplicationDbContext>(options => 
	options.UseSqlServer(builder.Configuration.GetConnectionString("AmaDbConection")));

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope()) {
	var services = serviceScope.ServiceProvider;
	var context = services.GetRequiredService<ApplicationDbContext>();
	context.Database.EnsureCreated();
	// await context.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary) {
	public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}