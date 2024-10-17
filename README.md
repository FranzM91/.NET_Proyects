# .NET_Free
 All Basic Proyects
## Error CORS
# .NET Framework
> Install-Package Microsoft.Owin.Cors
# .NET Core
> Install-Package Microsoft.AspNetCore.Cors

## .NET Framework Agregar estas configuraciones en App_Start > WebApiConfig:
// Web API configuration and services
config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

## .NET CORE Agregar estas configuraciones en Program:
 # OPTIONS
 options.AddPolicy("AllowAnyOrigin", builder =>
 {
     builder.AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader();
 });

# APP
app.UseCors("AllowAnyOrigin");
app.UseRouting();