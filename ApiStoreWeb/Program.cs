using ApiStoreWeb.Components;
using ApiStoreWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddScoped(o => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7084/"),
});

builder.Services.AddScoped<AuthServices>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CategoryServices>();
builder.Services.AddScoped<OrderDetailService>();
builder.Services.AddScoped<OrderServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
