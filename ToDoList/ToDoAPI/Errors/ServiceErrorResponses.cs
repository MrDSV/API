using Client.Models.Errors;
using System;
using System.Net;

namespace ToDoAPI.Errors
{
    public class ServiceErrorResponses
    {
        public static ServiceErrorResponse ToDoNotFound(string todoId)
        {
            if (todoId == null)
            {
                throw new ArgumentNullException(nameof(todoId));
            }

            var error = new ServiceErrorResponse
            {
                StatusCode = HttpStatusCode.NotFound,
                Error = new ServiceError
                {
                    Code = ServiceErrorCodes.NotFound,
                    Message = $"A ToDo with {todoId} not found.",
                    Target = "todo"
                }
            };

            return error;
        }

        public static ServiceErrorResponse BodyIsMissingOrUncorrect(string target)
        {
            var error = new ServiceErrorResponse
            {
                StatusCode = HttpStatusCode.BadRequest,
                Error = new ServiceError
                {
                    Code = ServiceErrorCodes.BadRequest,
                    Message = "Request body is empty or uncorrect.",
                    Target = target
                }
            };

            return error;
        }

        public static ServiceErrorResponse AuthIsNotConfirmed(string target)
        {
            var error = new ServiceErrorResponse
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Error = new ServiceError
                {
                    Code = ServiceErrorCodes.Forbidden,
                    Message = "Authorization forbidden",
                    Target = target
                }
            };

            return error;
        }

        public static ServiceErrorResponse ToDoAlreadyExists(string target)
        {
            var error = new ServiceErrorResponse
            {
                StatusCode = HttpStatusCode.BadRequest ,
                Error = new ServiceError
                {
                    Code = ServiceErrorCodes.Forbidden,
                    Message = "ToDo already exists.",
                    Target = target
                }
            };

            return error;
        }

    }
}
