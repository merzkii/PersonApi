using System.Globalization;

namespace PersonApi.Middlewares
{
    public class LocalizationMiddleware
    {
        private readonly RequestDelegate _next;

        public LocalizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var acceptLanguage = context.Request.Headers["Accept-Language"].ToString();
            if (!string.IsNullOrEmpty(acceptLanguage))
            {
                var culture = acceptLanguage.Split(',').FirstOrDefault();
                if (!string.IsNullOrEmpty(culture))
                {
                    var cultureInfo = new CultureInfo(culture);
                    CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
                    CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
                }
            }

            await _next(context);
        }
    }
}
