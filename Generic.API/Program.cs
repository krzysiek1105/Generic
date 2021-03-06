using Generic.Categories.Application;
using Generic.Categories.Infrastructure;
using Generic.Shared;
using Generic.Users.Application;
using Generic.Users.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy => policy
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin()));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSharedModule();
builder.Services.AddUsersModuleInfrastructure();
builder.Services.AddUsersModuleApplication();
builder.Services.AddCategoriesModuleInfrastructure();
builder.Services.AddCategoriesModuleApplication();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();
app.Run();
