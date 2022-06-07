using System.Text;
using Beetsoft_Management_System.Data;
using Beetsoft_Management_System.Data.Entities;
using Beetsoft_Management_System.Interface;
using Beetsoft_Management_System.Option;
using Beetsoft_Management_System.Repository;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using SeedDatas;
using SeedDatas.Depart;
using SeedDatas.Lv;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//1. Setup entity framework

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", opt =>
    {
<<<<<<< HEAD
        opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:4200");
    });
});
=======
        opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:4200").WithExposedHeaders("X-Pagination");
    });
});

//builder.Services.AddCors();

>>>>>>> origin/khaivm_loginGG
//2. Setup idetntity
var key = Encoding.UTF8.GetBytes(builder.Configuration["Authentication:Jwt:Secret"].ToString());

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = false; 
    options.Password.RequireLowercase = false; 
    options.Password.RequireNonAlphanumeric = false; 
    options.Password.RequireUppercase = false; 
    options.Password.RequiredLength = 3; 
    options.Password.RequiredUniqueChars = 1; 
})
.AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

// Add Options
var authenOptions = builder.Configuration.GetSection("Authentication");

builder.Services.Configure<Authentication>(authenOptions);

//Add Service DI
builder.Services.AddTransient<IGoogleRepository, GoogleRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

// Add Service JwtBearer
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>{
    opt.RequireHttpsMetadata = false;
    opt.SaveToken = false;
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
}).AddGoogle(opt =>{
     opt.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    opt.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

<<<<<<< HEAD

=======
//using( var scope = app.Services.CreateScope())
//{
//    SeedRoles.InitializeSeedRoles(scope.ServiceProvider);
//}
>>>>>>> origin/khaivm_loginGG
using( var scope = app.Services.CreateScope())
{
   SeedDepartment.InitializeSeedDepartment(scope.ServiceProvider);
}
using( var scope = app.Services.CreateScope())
{
   SeedLevel.InitializeSeedSeedLevel(scope.ServiceProvider);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
     app.UseDeveloperExceptionPage();
}
app.UseRouting();

app.UseCors("CorsPolicy");

<<<<<<< HEAD
app.UseHttpsRedirection();

app.UseStaticFiles();
=======
//app.UseCors(builder => builder.WithOrigins("http://localhost:4200")
//                                       .AllowAnyHeader()
//                                       .AllowAnyMethod());

app.UseHttpsRedirection();

//app.UseStaticFiles();
>>>>>>> origin/khaivm_loginGG
app.UseStaticFiles( new StaticFileOptions () {
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Uploads")
    ),
    RequestPath = "/contents"
});

app.UseAuthentication();

app.UseAuthorization();

<<<<<<< HEAD
 app.UseRouting();
app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
=======
app.MapControllers();
>>>>>>> origin/khaivm_loginGG

app.Run();
