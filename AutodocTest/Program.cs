using AutodocTest.Dal;
using AutodocTest.Services;

using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 152428800;
});

builder.Services.AddTransient<IContentTypeProvider, FileExtensionContentTypeProvider>();

builder.Services
    .AddTestDbContext(builder.Configuration, "AutodocTest")
    .AddServices()
    ;

builder.WebHost.ConfigureKestrel(options
    => options.Limits.MaxRequestBodySize = 100 * 1024 * 1024);

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
