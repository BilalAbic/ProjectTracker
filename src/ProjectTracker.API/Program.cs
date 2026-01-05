using Microsoft.EntityFrameworkCore;
using ProjectTracker.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS - Web sitesinden erişim için
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Database - Sadece Invitations için basit DbContext
builder.Services.AddDbContext<InvitationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Veritabanı tablosunu otomatik oluştur (hata olursa devam et)
try
{
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<InvitationDbContext>();
        db.Database.EnsureCreated();
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Database initialization failed: {ex.Message}");
    // Uygulama yine de başlasın, DB endpoint'leri hata verir ama ping çalışır
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.MapControllers();

// Root endpoint
app.MapGet("/", () => Results.Ok(new { 
    message = "ProjectTracker Invitation API", 
    version = "1.0",
    endpoints = new[] {
        "GET /api/invitations/validate?token=xxx",
        "POST /api/invitations/create",
        "POST /api/invitations/accept",
        "POST /api/invitations/decline",
        "GET /api/invitations/health"
    }
}));

// Simple ping endpoint (no DB required)
app.MapGet("/ping", () => Results.Ok(new { status = "OK", timestamp = DateTime.Now }));

app.Run();
