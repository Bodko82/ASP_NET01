using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();
var aboutMe = new AboutMe()
{
    LastName = "Богдан",
    FirstName = "Вишневський",
    Age = 40,
    Description = "NeDoDeveloper",
    Skilles = new() {"C", "C++", "ADO.NET Core", "SQL", "MSSQL", "MySQL", "PostgreSQL", "MongoDB", "JavaScript", "NodeJS", "Vue 2,3",
    "HTML", "CSS", "SCSS", "Python", "PHP", "Yii2 framework", "Sympfony", "Laravel"}
};
app.MapGet("/", () =>
{
    return Results.File("D:\\HW\\ASP.NET\\ASP_NET01\\WebApplication1\\wwwroot\\index.html", contentType: "text/html");
});
app.MapGet("/about-me", async context =>
{
    await context.Response.WriteAsJsonAsync(aboutMe);
});
app.MapGet("/about-me/skills", async context =>
{
    var query = context.Request.Query["q"].ToString(); 
    await context.Response.WriteAsJsonAsync(aboutMe.Skilles.Where(s => s.ToLower().Contains(query.ToLower())).ToList());
});

app.Run();
