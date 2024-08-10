using GoodHamburger.Api;
using GoodHamburger.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.AddConfiguration();
builder.AddDataContexts();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();
if (app.Environment.IsDevelopment())
    app.ConfigureDevEnvironment();

app.UseHttpsRedirection();
app.UseCors(ApiConfiguration.CorsPolicyName);
app.UseAuthorization();

app.MapControllers();

app.Run();
