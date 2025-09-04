using Microsoft.EntityFrameworkCore;
using DockerLabb1.Data;

var builder = WebApplication.CreateBuilder(args);


var cs = builder.Configuration.GetConnectionString("DefaultConnection")
         ?? Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")
         ?? "Server=localhost;Database=LabDb;User Id=sa;Password=Your_strong@Passw0rd;TrustServerCertificate=True;Encrypt=False";

builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(o =>
    o.UseSqlServer(cs, sql => sql.EnableRetryOnFailure())
);

var app = builder.Build();

// Kör migreringar vid uppstart (tål att DB startar lite segt)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    for (int i = 0; i < 10; i++)
    {
        try { db.Database.Migrate(); break; }
        catch { await Task.Delay(5000); }
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.Run();
