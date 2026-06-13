using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Venus.Presentation.Client.Core.DynamicRoutes;

namespace Venus.Presentation.Client.Core.Extensions
{

    public static class VenusEndpointRouteBuilderExtension
    {
        /// <summary>
        /// Uygulamaya gelen tüm URL'leri yakalayarak,
        /// controller ve action bilgisinin çalışma anında
        /// VenusDynamicRouteValueTransformer tarafından belirlenmesini sağlar.
        /// </summary>
        /// <param name="routeBuilder">
        /// Dinamik system ve özel route yapıları birlikte kullanılabilmesi için UseEndpoints ile uygulanır.
        /// </param>
        /// <example>
        ///     <code>
        ///     app.UseEndpoints(route =>
        ///        {
        ///            //Dinamik url, sıralama olarak üstte olmalı, özel route tanımlamaları ezmemeli.
        ///            route.VenusDynamicRoute(); 
        ///            
        ///            //Diğer özel tanımlamalar.
        ///            route.MapControllerRoute(
        ///                name: "default",
        ///                pattern: "{controller=Home}/{action=Index}/{id?}");
        ///
        ///        });
        ///     </code>
        /// </example>
        public static void VenusDynamicRoute(this IEndpointRouteBuilder routeBuilder)
        {
            routeBuilder.MapDynamicControllerRoute<VenusDynamicRouteValueTransformer>("{**slug}");
        } 
    }
}
