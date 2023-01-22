using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

var app = builder.Build();
builder.Services.AddControllersWithViews();
builder.Services.AddConnections();
SqlConnectionStringBuilder connectionStringBuilder = new();
connectionStringBuilder.DataSource = "";
connectionStringBuilder.InitialCatalog = "";
var connec = connectionStringBuilder.ConnectionString;

using (SqlConnection connection = new SqlConnection(connec))
{
    connection.Open();
    SqlCommand command = connection.CreateCommand();
    var reader = command.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine(reader.GetString(1));
    }
    reader.Close();

}
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
