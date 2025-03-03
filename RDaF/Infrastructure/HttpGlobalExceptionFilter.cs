using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RDaF.Shared.Exceptions;

namespace RDaF.Api.Infrastructure
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        //private readonly ILoggerManager _loggerError;

        public HttpGlobalExceptionFilter(IWebHostEnvironment env, IMapper mapper/*, ILoggerManager loggerError*/)
        {
            _env = env ?? throw new ArgumentNullException(nameof(env));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            //_loggerError = loggerError;
        }

        public IWebHostEnvironment Env => _env;

        public IMapper Mapper => _mapper;

        //public ILogger<HttpGlobalExceptionFilter> Logger => _logger;

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            var requestId = context.HttpContext.Connection.Id;
            var exceptionType = exception.GetType();
            var message = $"| RequestId : {requestId} | Message : {context.Exception.ToString()} | Header :  {context.HttpContext.Request.Headers}";
            //_loggerError.LogError(message);

            var developerException = _env.IsProduction() ? null : _mapper.Map<DeveloperException>(exception);



            switch (exceptionType)
            {
                case var _ when exceptionType == typeof(UnauthorizedAccessException):
                    {

                        var json = new JsonErrorResponse(nameof(UnauthorizedAccessException), exception.Message, requestId, developerException);

                        context.Result = new Microsoft.AspNetCore.Mvc.UnauthorizedObjectResult(json);
                        context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                        break;
                    }
                case var _ when exceptionType == typeof(DomainException):
                    {
                        var json = new JsonErrorResponse(nameof(DomainException), exception.Message, requestId, developerException);

                        context.Result = new BadRequestObjectResult(json);
                        context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                        break;
                    }

                case var _ when exceptionType == typeof(ValidationException):
                    {
                        var json = new JsonValidationErrorResponse(nameof(ValidationException), exception.Message, requestId, developerException);

                        context.Result = new BadRequestObjectResult(json);
                        context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                        break;
                    }

                default:
                    {
                        var json = new JsonErrorResponse(nameof(Exception), "An error occured. Please contact administrator", requestId, developerException);

                        context.Result = new InternalServerErrorObjectResult(json);
                        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                    }

            }

            context.ExceptionHandled = true;
        }

    }
}
