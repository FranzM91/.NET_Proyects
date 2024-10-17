var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// enable allowAnyOrigin, allowAnyMethod, allowAnyHeader
builder.Services.AddCors(options =>
{
    // TODO: FM implementar esta configuracion
    options.AddPolicy("AllowAnyOrigin", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
    //options.AddDefaultPolicy(builder =>
    //{
    //    builder.AllowAnyOrigin()
    //        .AllowAnyMethod()
    //        .AllowAnyHeader();
    //});
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// TODO: FM implementar esta configuracion
app.UseCors("AllowAnyOrigin");
app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
