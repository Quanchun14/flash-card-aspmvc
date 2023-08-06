using Microsoft.EntityFrameworkCore;
using flash_card.Data;
using flash_card.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<FlashCardContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FlashCardContext") ?? throw new InvalidOperationException("Connection string 'FlashCardContext' not found.")));

    
builder.Services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<FlashCardContext>()
                .AddDefaultTokenProviders();



builder.Services.Configure<IdentityOptions>(options=>{
     options.Password.RequireDigit = false; 
    options.Password.RequireLowercase = false; 
    options.Password.RequireNonAlphanumeric = false; 
    options.Password.RequireUppercase = false; 
    options.Password.RequiredLength = 5; 
    options.Password.RequiredUniqueChars = 1; 

    // Cấu hình Lockout - khóa user
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes (5); 
    options.Lockout.MaxFailedAccessAttempts = 8;
    options.Lockout.AllowedForNewUsers = true;

    // Cấu hình về User.
    options.User.AllowedUserNameCharacters = 
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;  

    // Cấu hình đăng nhập.
    options.SignIn.RequireConfirmedEmail = false;            
    options.SignIn.RequireConfirmedPhoneNumber = false; 
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseAuthentication();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

//Identity/Account/Login