using LibraryManagementSystem.Business.Modulos;
using LibraryManagementSystem.Infrastructure.Data;
using LibraryManagementSystem.Infrastructure.Repositories.Books;
using LibraryManagementSystem.Infrastructure.UnitOfWork;
using LibraryManagementSystem.Presentation.Modules.Books;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<LibraryManagementSystemDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBooksViewModelProvider, BooksViewModelProvider>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
var app = builder.Build();
app.UseStatusCodePagesWithReExecute("/Error/StatusCode", "?statusCode={0}");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/ServerError");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Book}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
