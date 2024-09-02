//using System.Net;
//using System.Threading.Tasks;
//using System.IO;

//namespace uab.server.webapp.Middlewares
//{
//    public class JsonExceptionMiddleware
//    {
//        private readonly RequestDelegate _next;

//        public JsonExceptionMiddleware(RequestDelegate next)
//        {
//            _next = next;
//        }
//        public async Task Invoke(HttpContext context)
//        {
//            try
//            {
//                await _next(context);
//            }
//            catch (Exception ex)
//            {
//                await HandleExceptionAsync(context, ex);
//            }
//        }

//        //private Task HandleExceptionAsync(HttpContext context, Exception exception)
//        //{
//        //    context.Response.ContentType = "application/json";
//        //    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

//        //    return context.Response.WriteAsync(JObject.FromObject(new
//        //    {
//        //        Status = context.Response.StatusCode,
//        //        Message = exception.Message,
//        //    }).ToString());
//        //}
//    }
//}
