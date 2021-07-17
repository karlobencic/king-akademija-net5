using System;
using System.Linq;
using KingICT.Academy2021.DddFileSystem.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KingICT.Academy2021.DddFileSystem.API.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        protected virtual Guid RequestToken => Guid.NewGuid();

        protected TRequest CreateServiceRequest<TRequest>()
            where TRequest : RequestBase, new()
        {
            return new TRequest()
            {
                RequestToken = this.RequestToken,
            };
        }

        /// <summary>
        /// Converts service response into HTTP response with correct status code
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        protected ObjectResult BadResponse<TRequest>(ResponseBase<TRequest> response)
            where TRequest : RequestBase, new()
        {
            return response.Statuses.FirstOrDefault()?.Code switch
            {
                "204" => StatusCode(StatusCodes.Status204NoContent, response.Message),
                "404" => StatusCode(StatusCodes.Status404NotFound, response.Message),
                "500" => StatusCode(StatusCodes.Status500InternalServerError, response.Message),
                _ => BadRequest(response.Statuses)
            };
        }
    }
}
