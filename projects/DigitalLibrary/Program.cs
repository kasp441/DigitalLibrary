
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repo;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Check if the environment variable is specified and use it if available
var envConnectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
if (!string.IsNullOrWhiteSpace(envConnectionString))
{
    connectionString = envConnectionString;
}

Console.WriteLine($"Using connection string: {connectionString}");

// Register DbContextFactory
builder.Services.AddDbContext<LibraryContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<ILibraryRepo, LibraryRepo>();
builder.Services.AddScoped<ILibraryService, LibraryService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var userGroup = app.MapGroup("/User");
var bookGroup = app.MapGroup("/Book");
var loanGroup = app.MapGroup("/Loan");

userGroup.MapPost("/AddUser", async (ILibraryService service, User user) =>
{
    return await service.AddUser(user);
});

userGroup.MapGet("/GetUser", async (ILibraryService service, string ssn) =>
{
    return await service.GetUser(ssn);
});

userGroup.MapPost("/UpdateUser", async (ILibraryService service, User user) =>
{
    return await service.UpdateUser(user);
});

userGroup.MapDelete("/DeleteUser", async (ILibraryService service, string ssn) =>
{
    await service.DeleteUser(ssn);
});

bookGroup.MapPost("/AddBook", async (ILibraryService service, Book book) =>
{
    return await service.AddBook(book);
});

bookGroup.MapGet("/GetBooks", async (ILibraryService service) =>
{
    return await service.GetBooks();
});

bookGroup.MapGet("/getBook", async (ILibraryService service, int id) =>
{
    return await service.getBook(id);
});

bookGroup.MapDelete("/removeBook", async (ILibraryService service, int id) =>
{
    await service.removeBook(id);
});

loanGroup.MapPost("/AddLoan", async (ILibraryService service, int userID, List<int> bookIDs) =>
{
    return await service.AddLoan(userID, bookIDs);
});

loanGroup.MapPost("/ReturnBook", async (ILibraryService service, int loanID, int bookID) =>
{
    return await service.ReturnBook(loanID, bookID);
});

loanGroup.MapGet("/GetLoans", async (ILibraryService service, int userID) =>
{
    return await service.GetLoans(userID);
});

loanGroup.MapDelete("/ReturnAllBooks", async (ILibraryService service, int loanID) =>
{
    await service.ReturnAllBooks(loanID);
});

app.Run();