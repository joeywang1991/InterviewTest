using InterviewTest.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

string connection = Environment.GetEnvironmentVariable("MS_LocalDB");
builder.Services.AddDbContext<PersonDbContext>(options =>
    options.UseSqlServer(connection));

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<InterceptorMiddleware>();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.MapGet("/Person", (PersonDbContext context) =>
{
    return context.Person.ToList();
})
.WithName("GetPersons")
.WithOpenApi();

app.MapPost("/Person", (Person person, PersonDbContext context) =>
{
    context.Add(person);
    context.SaveChanges();
})
.WithName("CreatePerson")
.WithOpenApi();

app.Run();
