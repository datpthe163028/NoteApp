using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NoteApp.App.Database.Data;
using NoteApp.App.DesignPatterns.Repository;
using NoteApp.App.DesignPatterns.UnitOfWork;
using NoteApp.Module.Account.Request;
using NoteApp.Module.Account.Service;
using NoteApp.Module.Account.Validations;
using NoteApp.Module.Majors.Services;
using NoteApp.Module.Semesters.Service;
using System;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var connect = builder.Configuration.GetConnectionString("ShopConnect");

builder.Services.AddDbContext<noteappContext>(options =>
{
    options.UseMySql(connect, ServerVersion.AutoDetect(connect));
});
builder.Services.AddTransient<noteappContext, noteappContext>();

#region registerServiceForController

builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<IMajorService, MajorService>();
builder.Services.AddTransient<ISemesterService, SemesterService>();
#endregion

#region registerServiceForRepo
builder.Services.AddScoped<UnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IRepository<Filenote>, Repository<Filenote>>();
builder.Services.AddScoped<IRepository<Foldernote>, Repository<Foldernote>>();
builder.Services.AddScoped<IRepository<Grade>, Repository<Grade>>();
builder.Services.AddScoped<IRepository<Major>, Repository<Major>>();
builder.Services.AddScoped<IRepository<Permission>, Repository<Permission>>();
builder.Services.AddScoped<IRepository<Role>, Repository<Role>>();
builder.Services.AddScoped<IRepository<Semester>, Repository<Semester>>();
builder.Services.AddScoped<IRepository<SimpleNote>, Repository<SimpleNote>>();
builder.Services.AddScoped<IRepository<Subject>, Repository<Subject>>();
builder.Services.AddScoped<IRepository<SubjectTypeScore>, Repository<SubjectTypeScore>>();
builder.Services.AddScoped<IRepository<ToDoListNote>, Repository<ToDoListNote>>();
builder.Services.AddScoped<IRepository<TypeScore>, Repository<TypeScore>>();
builder.Services.AddScoped<IRepository<University>, Repository<University>>();
builder.Services.AddScoped<IRepository<UniversityMajor>, Repository<UniversityMajor>>();
builder.Services.AddScoped<IRepository<UniversityMajorSemester>, Repository<UniversityMajorSemester>>();
builder.Services.AddScoped<IRepository<User>, Repository<User>>();
#endregion

#region AddAuthentication, AddJwtBearer
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
string secretKey = jwtSettings["SecretKey"];
string issuer = jwtSettings["Issuer"];
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = issuer,
        ValidAudience = issuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});
#endregion
builder.Services.AddControllersWithViews().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AccountRequestValidate>());


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
