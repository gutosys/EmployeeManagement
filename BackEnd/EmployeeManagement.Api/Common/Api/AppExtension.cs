namespace EmployeeManagement.Api.Common.Api
{
    public static class AppExtension
    {
        public static void ConfigureDevEnvironment(this WebApplication app)
        {
            app.MapOpenApi();
            //                .RequireAuthorization();

            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/openapi/v1.json", "OpenApi V1");
            });
        }

        public static void UseSecurity(this WebApplication app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}