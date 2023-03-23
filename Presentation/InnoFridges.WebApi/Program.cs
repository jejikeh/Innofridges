using InnoFridges.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.RegisterServiceMiddlewares();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// todo: move this to serviceMiddlewareExtension

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors("AllowAll");
app.InitializeServiceContextProvider();
app.Run();