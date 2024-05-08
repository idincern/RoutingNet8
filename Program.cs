var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseRouting(); // Gelen rotayı ayrıştırma işlemi yapan Middleware

app.UseAuthorization();
//dev branch

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");

#pragma warning disable ASP0014 // Suggest using top level route registrations
var applicationBuilder = app.UseEndpoints(endpoints =>
{
    //Type 1(Default):
    endpoints.MapDefaultControllerRoute(); // {controller=Home}/{action=Index}/{id?} = Default Route
    // {}: Parameters. controller and action are pre-defined by the arhitecture. Other than these are custom parameters. Id is custom this case.
    // If route is /, /home
    //              /home/index
    // is triggered, Home/Index will be returned by default.

    // if the route is /personel/getir, then it will be triggered.
    // if the route is only /personel, then /personel/index will be triggered.

    //Type 2(MapControllerRoute):
    endpoints.MapControllerRoute("CustomRoute", "{controller=Person}/{action=Index}"); // We should add the default values because if the route is empty then, error will be occurred.
    // endpoints.MapControllerRoute("CustomRoute", "{action}/idincern/{controller}"); // custom route with static string
    // Enables us to create custom routes rather than default. It needs name and pattern
});

app.Run();
