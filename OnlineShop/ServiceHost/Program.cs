using _0_Framework.Application.ZarinPal;
using _0_FrameWork.Application;
using _0_FrameWork.Application.ZarinPal;
using BlogManagment.Infrastructure.Configuration;
using CommentManagement.Infrastructure.Configuration;
using DiscountManagement.Configuration;
using InventoryManagement.Infrastructure.Configurations;
using InventoryManagement.Presentation.API;
using ServiceHost;
using ShopManagement.Configuration;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionstring = builder.Configuration.GetConnectionString("LampshadeDb");
ShopManagementBootstrapper.Configure(builder.Services, connectionstring);
DiscountManagementBootstraper.Configure(builder.Services, connectionstring);
InventoryManagmentBootstrapper.Configure(builder.Services, connectionstring);
BlogManagmentBootstrapper.Configure(builder.Services, connectionstring);
CommentManagementBootstrapper.Configure(builder.Services, connectionstring);
builder.Services.AddTransient<IZarinPalFactory,ZarinPalFactory>();
builder.Services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
builder.Services.AddTransient<IFileUploader, FileUploader>();
builder.Services.AddCors(options => options.AddPolicy("MyPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyMethod()));
builder.Services.AddRazorPages()
    .AddApplicationPart(typeof(InventoryController).Assembly)
    .AddNewtonsoftJson();
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseRouting();
app.UseAuthorization();
app.UseCors("MyPolicy");
app.MapRazorPages();
app.UseEndpoints(endpoints => { 
    endpoints.MapRazorPages();
    endpoints.MapDefaultControllerRoute();
});
app.Run();
