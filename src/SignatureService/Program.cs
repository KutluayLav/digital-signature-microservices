using SignatureService.Security;
using SignatureService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// DI
builder.Services.AddScoped<IHashService, HashService>();
builder.Services.AddScoped<IDocumentService, DocumentService>();

var app = builder.Build();

app.UseRouting();

// AUTH NOT WORKING YET
// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();

app.Run();
