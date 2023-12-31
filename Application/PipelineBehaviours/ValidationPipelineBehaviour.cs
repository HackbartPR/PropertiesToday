﻿using Application.Exceptions;
using FluentValidation;
using MediatR;
using System.Diagnostics.Contracts;

namespace Application.PipelineBehaviours;

public class ValidationPipelineBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipelineBehaviour(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults
                .SelectMany(r => r.Errors).Where(f => f != null).ToList();

            List<string> errors = new();
            if (failures.Any())
            {
                failures.ForEach(f => { 
                    errors.Add(f.ErrorMessage);
                });

                throw new CustomValidationException(errors, "Uma ou mais validações falharam.");
            }
        }

        return await next();
    }
}
