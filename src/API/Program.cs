using API.Extension;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGraphQLServices(builder.Configuration, builder.Environment);
builder.Services.AddJWTAuthentication(builder.Configuration);
builder.Services.AddAuthorization();
builder.Services.RegisterOpenTelemetry(builder.Configuration, builder.Environment);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseWebSockets();

app.MapGraphQL();

await app.EnsureDatabaseCreatedAsync(app.Environment);
await app.SeedDataAsync();

app.Run();
