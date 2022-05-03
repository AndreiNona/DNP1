using Application.DAO;
using Application.Logic;
using Contracts;
using EfcData;
//using FileData;


using (UserContext ctx = new())
{
    ctx.Seed();
}


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserServiceImpl>();
builder.Services.AddScoped<IPostService, PostServiceImpl>();
//builder.Services.AddScoped<IUserDAO, UserFileDAO>();
//builder.Services.AddScoped<UserFileContext>();
builder.Services.AddScoped<IUserDAO, UserSqliteDAO>();
builder.Services.AddScoped<UserContext>();
builder.Services.AddScoped<IPostDAO, PostSqliteDAO>();
//builder.Services.AddScoped<IPostDAO, PostFileDAO>();
//builder.Services.AddScoped<PostFileContext>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();