using Oo.Ddd.Bank.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

var bankApiBaseUrl = builder.Configuration["BankApiSettings:BaseUrl"];
if (string.IsNullOrEmpty(bankApiBaseUrl))
    throw new InvalidOperationException("BankApiSettings:BaseUrl não configurada em appsettings.json.");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<BankApiClient>(client =>
{ 
    client.BaseAddress = new Uri(bankApiBaseUrl); 
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
