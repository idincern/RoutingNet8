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
    // // Type 1(Default):
    // endpoints.MapDefaultControllerRoute(); // {controller=Home}/{action=Index}/{id?} = Default Route
    // // {}: Parameters. controller and action are pre-defined by the arhitecture. Other than these are custom parameters. Id is custom in this case.
    // // If route is /, /home, /home/index => Home/Index will be returned by default.
    // // If the route is /person/get, then it will also be triggered, but if the route is only /person, then /person/index will be triggered.

    // // Type 2(MapControllerRoute):
    // endpoints.MapControllerRoute("CustomRoute", "{controller=Person}/{action=Index}"); // We should add the default values because if the route is empty then, error will be occurred.
    // // endpoints.MapControllerRoute("CustomRoute", "{action}/idincern/{controller}"); // custom route with static string
    // // Enables us to create custom routes rather than default. It needs name and pattern

    // // Type 3(MapControllerRoute overload):
    // endpoints.MapControllerRoute("MoreSpecializedCustomRoute", "Mainpage", new{controller="Home", action="Index"});// when /mainpage is triggered, Home/Index will be returned by default

    // // Type 4(CustomParameters):
    // endpoints.MapControllerRoute("CustomParameters", "{controller=Home}/{action=Index}/{id:int?}/{x:alpha:length(11)?}/{y?}"); // id is integer only, x and y can be null but string is preffered. x's length is 11 chars and its alphabetic(a-Z).
    // //types can be int, alpha(A-z), bool, datetime, decimal, double, float, guid
    // //length(11), maxlength(11), minlength(11), range(min,max), min(minvalue), max(maxvalue) are other constraints of the route parameters.

    // Type 5
    // Attribute Routing =>>> Writing routes inside the controller files using Route[(...)]
    endpoints.MapControllers(); // For Attribute Routing, enable only this one
});

app.Run();
