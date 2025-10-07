using ErrorOr;
using FluentValidation;
using MediatR;

namespace BuberDinner.Application.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehavior(IValidator<TRequest>? validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken
        )
        {
            if (_validator is null)
            {
                return await next(cancellationToken);
            }

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (validationResult.IsValid)
            {
                return await next(cancellationToken);
            }
            var errors = validationResult
                .Errors.ConvertAll(static validationFailure =>
                    Error.Validation(validationFailure.PropertyName, validationFailure.ErrorMessage)
                )
                .ToList();

            //generaly not recommended to use dynamic
            return (dynamic)errors;
        }
    }
}
