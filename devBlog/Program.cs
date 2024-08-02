using devBlog.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<devBlogContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("devBlogContext") ?? throw new InvalidOperationException("Connection string 'devBlogContext' not found.")));


builder.Services.Configure<IdentityOptions>(options =>
{
	// Password settings.
	options.Password.RequireDigit = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireNonAlphanumeric = true;
	options.Password.RequireUppercase = true;
	options.Password.RequiredLength = 8;
	options.Password.RequiredUniqueChars = 1;

	// Lockout settings.
	options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
	options.Lockout.MaxFailedAccessAttempts = 5;
	options.Lockout.AllowedForNewUsers = true;

	// User settings.
	options.User.AllowedUserNameCharacters =
	"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
	options.User.RequireUniqueEmail = false;
});

builder.Services.ConfigureApplicationCookie(options =>
{
	// Cookie settings
	options.Cookie.HttpOnly = true;
	options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

	options.LoginPath = "/Identity/Account/Login";
	options.AccessDeniedPath = "/Identity/Account/AccessDenied";
	options.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
}
else
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

using(var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
	var roles = new List<string> { "Admin", "Blogger" };

    foreach (var role in roles)
    {
        if(! await roleManager.RoleExistsAsync(role))
			await roleManager.CreateAsync(new IdentityRole(role));
    }
}

using (var scope = app.Services.CreateScope())
{
	var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

	string adminEmail = "admin@admin.com";
	string adminPassword = "Dada@asp123";	

    if (await userManager.FindByEmailAsync(adminEmail) == null)
    {
        var user = new IdentityUser { UserName = adminEmail, Email = adminEmail };
		await userManager.CreateAsync(user, adminPassword);
		await userManager.AddToRoleAsync(user, "Admin");
    }
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<devBlogContext>();

    if (!await dbContext.Tag.AnyAsync())
    {
        var tags = new List<Tag>
        {
            new Tag { TagID = Guid.NewGuid(), Name = "Development" },
            new Tag { TagID = Guid.NewGuid(), Name = "Web Development" },
            new Tag { TagID = Guid.NewGuid(), Name = "CSS" },
            new Tag { TagID = Guid.NewGuid(), Name = "JavaScript" },
            new Tag { TagID = Guid.NewGuid(), Name = "Angular" },
            new Tag { TagID = Guid.NewGuid(), Name = "PHP" },
            new Tag { TagID = Guid.NewGuid(), Name = "HTML" },
            new Tag { TagID = Guid.NewGuid(), Name = "React" },
            new Tag { TagID = Guid.NewGuid(), Name = "Data Science" },
            new Tag { TagID = Guid.NewGuid(), Name = "Mobile Development" },
            new Tag { TagID = Guid.NewGuid(), Name = "Programming Language" },
            new Tag { TagID = Guid.NewGuid(), Name = "Software Testing" },
            new Tag { TagID = Guid.NewGuid(), Name = "Software Engineering" },
            new Tag { TagID = Guid.NewGuid(), Name = "Software Development Tools" },
            new Tag { TagID = Guid.NewGuid(), Name = "Cybersecurity" },
            new Tag { TagID = Guid.NewGuid(), Name = "Network Security" },
            new Tag { TagID = Guid.NewGuid(), Name = "Application Security" },
            new Tag { TagID = Guid.NewGuid(), Name = "Data Privacy" },
            new Tag { TagID = Guid.NewGuid(), Name = "Incident Response" },
            new Tag { TagID = Guid.NewGuid(), Name = "Security Tools" },
            new Tag { TagID = Guid.NewGuid(), Name = "AI / ML" },
            new Tag { TagID = Guid.NewGuid(), Name = "Machine Learning Algorithms" },
            new Tag { TagID = Guid.NewGuid(), Name = "Deep Learning" },
            new Tag { TagID = Guid.NewGuid(), Name = "AI Applications" },
            new Tag { TagID = Guid.NewGuid(), Name = "Ethics in AI" },
            new Tag { TagID = Guid.NewGuid(), Name = "Cloud Computing" },
            new Tag { TagID = Guid.NewGuid(), Name = "Tech Industry News" }
        };

        await dbContext.Tag.AddRangeAsync(tags);
        await dbContext.SaveChangesAsync();
    }
}

app.Run();
