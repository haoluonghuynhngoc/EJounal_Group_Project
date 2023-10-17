using BussinessObject.Data;
using DataAccess.Data;
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
builder.Services.AddScoped<IArticlesRepository, ArticlesRepositoryImpl>();
builder.Services.AddScoped<IFieldsRepository, FieldsRepositoryImpl>();
builder.Services.AddScoped<IJournalRepository, JournalRepositoryImpl>();
builder.Services.AddScoped<IMajorRepository, MajorRepositoryImpl>();
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

// add first database Role and Admin
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleRepository = services.GetRequiredService<IRoleRepository>();
    var seedDataRole = new SeedDataRole(roleRepository);
    seedDataRole.Initialize();
    var userRepository = services.GetRequiredService<IUserRepository>();
    var seedDataAdmin = new SeedDataAdmin(userRepository, roleRepository);
    seedDataAdmin.Initialize();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
