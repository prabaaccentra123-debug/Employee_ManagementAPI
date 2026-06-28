namespace EmployeeManagement.Exception_Middleware
{
    public class GlobalException
    {
        private readonly RequestDelegate _requestDelegate;

        public GlobalException(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(

                    new
                    {
                        message = ex.Message
                    }
                    );

            }
        }

    }
}


