using Generic.Categories;
using Generic.Shared;
using Generic.Users.Application;
using Generic.Users.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSharedModule();
builder.Services.AddUsersModuleInfrastructure();
builder.Services.AddUsersModuleApplication();
builder.Services.AddCategoriesModule();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
