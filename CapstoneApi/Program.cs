using CapstoneApi.Context;
using CapstoneApi.Contracts;
using CapstoneApi.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Need AddSingleton and Add scope for dapper to work with your repo
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IRepo, Repo>();
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    //for debug we let any cross origins connect, in real life we want this limited
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("corsapp");

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
