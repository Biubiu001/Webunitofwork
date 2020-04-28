using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Infrastructure.Interfaces.Extensions
{
   public static class ApplicationBuilderExensions
    {
        public static IApplicationBuilder UseDefaultServices( this IApplicationBuilder app) {

            app.UseSwagger()
            .UseSwaggerUI(opts => {

                opts.SwaggerEndpoint($"/swagger/V1/swagger.json", "API V1");
                opts.RoutePrefix = string.Empty;
                opts.DefaultModelRendering(ModelRendering.Example);
            
            });
            app.UseRouting();
            //app.UseMiddleware<>
            app.UseEndpoints(opts => {
                opts.MapControllers();
                opts.MapHealthChecks("/health");
            
            });
            return app;
        }
    }
}
