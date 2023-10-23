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

// config session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// add dependency injection
builder.Services.AddScoped<IArticlesRepository, ArticlesRepositoryImpl>();
builder.Services.AddScoped<IFieldsRepository, FieldsRepositoryImpl>();
builder.Services.AddScoped<IJournalRepository, JournalRepositoryImpl>();
builder.Services.AddScoped<IMajorRepository, MajorRepositoryImpl>();
builder.Services.AddScoped<IRoleRepository, RoleRepositoryImpl>();
builder.Services.AddScoped<IUserRepository, UserRepositoryImpl>();
builder.Services.AddScoped<IReviewResultRepository, ReviewResultRepositoryImpl>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

// add  data Role , Admin , Majors and journals
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var roleRepository = services.GetRequiredService<IRoleRepository>();
    var seedDataRole = new SeedDataRole(roleRepository);
    seedDataRole.Initialize();
    var userRepository = services.GetRequiredService<IUserRepository>();
    var seedDataAdmin = new SeedDataAdmin(userRepository, roleRepository);
    seedDataAdmin.Initialize();

    //add fields
    var fieldsRepository = services.GetRequiredService<IFieldsRepository>();
    var seedDataField = new SeedDataFields(fieldsRepository);
    seedDataField.Initialize();
    // add journals
    var journalsRepository = services.GetRequiredService<IJournalRepository>();
    var seedDataJournal = new SeedDataJournals(journalsRepository);
    seedDataJournal.Initialize();
    // add majors
    var majorRepository = services.GetRequiredService<IMajorRepository>();
    var seedDataMajors = new SeedDataMajors(majorRepository);
    seedDataMajors.Initialize();

}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
