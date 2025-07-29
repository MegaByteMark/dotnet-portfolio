using FluentValidation.Results;

namespace PortfolioDotNetApi.Domain.Exceptions;

public class DomainValidationException : Exception
{
    public IReadOnlyList<string> ValidationErrors { get; }
    
    public DomainValidationException(string message, IEnumerable<string> errors) 
        : base(message)
    {
        ValidationErrors = [.. errors];
    }
    
    public DomainValidationException(ValidationResult result) 
        : this("Domain validation failed", result.Errors.Select(e => e.ErrorMessage))
    {
    }
}