using Ganss.Xss;
using MediatR;

namespace TMCars.Application.Behaviors;

public class SanitizationBehavior<TRequest, TResponse>(HtmlSanitizer sanitizer)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
    {
        // Find all string properties that are writable
        var stringProps = typeof(TRequest).GetProperties()
            .Where(p => p.PropertyType == typeof(string) && p.CanWrite);

        foreach (var prop in stringProps)
        {
            var value = prop.GetValue(request) as string;
            if (!string.IsNullOrEmpty(value))
            {
                // Sanitize the HTML to prevent XSS attacks
                prop.SetValue(request, sanitizer.Sanitize(value));
            }
        }

        return await next();
    }
}