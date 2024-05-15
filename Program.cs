using Microsoft.EntityFrameworkCore;
using SatrancUygulamasi.Data;
using SatrancUygulamasi.Data.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

// InMemory DB Configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("ChessDB"));

builder.Services.AddControllersWithViews();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    if (!dbContext.Parents.Any())
    {
        InitializeData(dbContext);

        // Seed verilerini burada yükleyin veya kontrol edin
        Console.WriteLine("No data present, seeding data.");
        // Seed data methodunuzun çaðrýsý
    }
    else
    {
        Console.WriteLine("Data already present.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


void InitializeData(AppDbContext context)
{
    if (!context.Parents.Any())
    {
        context.Parents.AddRange(
            new Parent { Id = 1, Name = "Ayþe Yýlmaz", Email = "ayse@example.com", Password = "securepassword1" },
                new Parent { Id = 2, Name = "Mehmet Demir", Email = "mehmet@example.com", Password = "securepassword2" },
                new Parent { Id = 3, Name = "Fatma Korkmaz", Email = "fatma@example.com", Password = "securepassword3" },
                new Parent { Id = 4, Name = "Ahmet Can", Email = "ahmet@example.com", Password = "securepassword4" },
                new Parent { Id = 5, Name = "Esra Bilgiç", Email = "esra@example.com", Password = "securepassword5" }
            );
        context.Students.AddRange(
            new Student { Id = 1, Name = "Deniz Yýlmaz", Age = 14, ParentId = 1, Email = "deniz@example.com", Password = "password123" },
                new Student { Id = 2, Name = "Derya Yýlmaz", Age = 12, ParentId = 1, Email = "derya@example.com", Password = "password123" },
                new Student { Id = 3, Name = "Emre Demir", Age = 15, ParentId = 2, Email = "emre@example.com", Password = "password456" },
                new Student { Id = 4, Name = "Büþra Demir", Age = 10, ParentId = 2, Email = "busra@example.com", Password = "password456" },
                new Student { Id = 5, Name = "Can Korkmaz", Age = 13, ParentId = 3, Email = "can@example.com", Password = "password789" },
                new Student { Id = 6, Name = "Ýrem Korkmaz", Age = 11, ParentId = 3, Email = "irem@example.com", Password = "password789" },
                new Student { Id = 7, Name = "Ali Can", Age = 9, ParentId = 4, Email = "ali@example.com", Password = "password101" },
                new Student { Id = 8, Name = "Zeynep Can", Age = 12, ParentId = 4, Email = "zeynep@example.com", Password = "password101" },
                new Student { Id = 9, Name = "Merve Bilgiç", Age = 14, ParentId = 5, Email = "merve@example.com", Password = "password202" },
                new Student { Id = 10, Name = "Murat Bilgiç", Age = 16, ParentId = 5, Email = "murat@example.com", Password = "password202" }
            );
        context.SaveChanges();
    }
}

app.Run();
