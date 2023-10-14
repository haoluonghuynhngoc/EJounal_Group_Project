using BussinessObject.Data;
using DataAccess.Repository;
using DataAccess.Repository.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// add appsetting.json 
builder.Services.AddDbContext<ApplicationContext>(options =>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("RazorPageAppContext"))
                                             .UseLazyLoadingProxies()
                                             .EnableSensitiveDataLogging()
                                              );
// add dependency
builder.Services.AddScoped<IArticlesRatingRepository, ArticlesRatingRepositoryImpl>();
builder.Services.AddScoped<IArticlesRepository, ArticlesRepositoryImpl>();
builder.Services.AddScoped<IFieldsRepository, CategoryRepositoryImpl>();
builder.Services.AddScoped<IJournalRepository, JournalRepositoryImpl>();
builder.Services.AddScoped<IJournalRepository, JournalRepositoryImpl>();
builder.Services.AddScoped<IMajorRepository, ReviewRepositoryImpl>();
builder.Services.AddScoped<IRoleRepository, RoleRepositoryImpl>();
builder.Services.AddScoped<IUserRepository, UserRepositoryImpl>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
