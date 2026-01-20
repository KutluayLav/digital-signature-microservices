using SignatureService.Services;
using SignatureService.Services.Crypto;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Dependency Injection
builder.Services.AddScoped<IRsaSignatureService, RsaSignatureService>();
builder.Services.AddScoped<IDocumentService, DocumentService>();

var app = builder.Build();

app.UseRouting();

// Auth not working yet 
// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllers();
app.Run();
