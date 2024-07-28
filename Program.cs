using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
    options.ReturnHttpNotAcceptable = true
 ).AddXmlDataContractSerializerFormatters();
 
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();


// app.UseEndpoints(endpoints => {
//     endpoints.MapControllers();
// });

// app.Run(async (context) =>
//     {
//         await context.Response.WriteAsync("Hello World!");
//     });

app.Run();