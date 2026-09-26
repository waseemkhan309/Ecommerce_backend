using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi;

namespace Ecommerce_backend.Extensions
{
    public sealed class BearerSecuritySchemeTransformer : IOpenApiDocumentTransformer
    {
        //"Ek scheme banao, document ke glossary mein daalo, phir har single endpoint ko bol do ke usse yehi scheme chahiye."
        public Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
        {
            // 1. Define the global Bearer security scheme
            var scheme = new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                In = ParameterLocation.Header,
                BearerFormat = "JWT",
                Description = "Paste your JWT token value here."
            };

            document.Components ??= new OpenApiComponents();
            document.Components.SecuritySchemes ??= new Dictionary<string, IOpenApiSecurityScheme>();
            document.Components.SecuritySchemes.Add("Bearer", scheme);

            // 2. Create the reference object
            var securitySchemeReference = new OpenApiSecuritySchemeReference("Bearer", document);

            // 3. Apply it globally to all operations
            foreach (var path in document.Paths.Values)
            {
                foreach (var operation in path.Operations.Values)
                {
                    operation.Security = new List<OpenApiSecurityRequirement>
                    {
                        new() { [securitySchemeReference] = new List<string>() }
                    };
                }
            }

            return Task.CompletedTask;
        }
    }
}

//using Microsoft.AspNetCore.OpenApi;
//using Microsoft.OpenApi;

//namespace Ecommerce_backend.Extensions
//{
//    public sealed class BearerSecuritySchemeTransformer : IOpenApiDocumentTransformer
//    {
//        public Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
//        {
//            // 1. Define the global Bearer security scheme
//            var scheme = new OpenApiSecurityScheme
//            {
//                Type = SecuritySchemeType.Http,
//                Scheme = "bearer",
//                In = ParameterLocation.Header,
//                BearerFormat = "JWT",
//                Description = "Paste your JWT token value here."
//            };

//            document.Components ??= new OpenApiComponents();
//            document.Components.SecuritySchemes.Add("Bearer", scheme);

//            // 2. Create the reference object using the updated API
//            var securitySchemeReference = new OpenApiSecuritySchemeReference("Bearer", document);

//            // 3. Apply it globally to all operations
//            foreach (var path in document.Paths.Values)
//            {
//                foreach (var operation in path.Operations.Values)
//                {
//                    operation.Security = new List<OpenApiSecurityRequirement>
//                    {
//                        new() { [securitySchemeReference] = new List<string>() }
//                    };
//                }
//            }

//            return Task.CompletedTask;
//        }


//    }
//}
