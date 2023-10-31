﻿using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        //private readonly ILogger _logger;

        //public UnhandledExceptionBehaviour(ILogger logger)
        //{
        //    _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        //}

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;

                //_logger.LogError(ex, "Application Request: Unhandled exception for request {Name} {@Request}", requestName, request);

                throw;
            }
        }
    }
}