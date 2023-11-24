using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Mail;
using Project.Mapper;
using Project.Services;
using Project.Services.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add Connect Sql Server Service
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
// Add Identity Service
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = $"/Admin/Account/Login";
    options.LogoutPath = $"/Admin/Account/Logout";
    options.AccessDeniedPath = $"/Admin/Account/AccessDenied";
});
// Add Mapper Service
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
// Add Mail Service 
builder.Services.AddOptions();
var mailSettings = builder.Configuration.GetSection("MailStrings");
builder.Services.Configure<MailSettings>(mailSettings);
builder.Services.AddTransient<IEmailSender, SendMailService>();
// Add Dependencies Injection
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Add Seesion 
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Client}/{controller=Home}/{action=Index}/{id?}");

app.Run();
