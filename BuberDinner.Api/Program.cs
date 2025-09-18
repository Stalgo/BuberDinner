using BuberDinner.Application.Services.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
