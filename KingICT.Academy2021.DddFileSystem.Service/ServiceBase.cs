using KingICT.Academy2021.DddFileSystem.Infrastructure;
using KingICT.Academy2021.DddFileSystem.Messaging;

namespace KingICT.Academy2021.DddFileSystem.Service
{
    public abstract class ServiceBase
    {
        private static readonly Rule _contentNotFound = new Rule("204", "Content not found.");
        private static readonly Rule _resourceNotFound = new Rule("404", "Resource not found.");
        private static readonly Rule _genericException = new Rule("500", "Internal server error.");

        protected TResponse ContentNotFound<TRequest, TResponse>(TResponse response)
            where TRequest : RequestBase
            where TResponse : ResponseBase<TRequest>
        {
            return FromRule<TRequest, TResponse>(response, _contentNotFound);
        }

        protected TResponse ResourceNotFound<TRequest, TResponse>(TResponse response)
            where TRequest : RequestBase
            where TResponse : ResponseBase<TRequest>
        {
            return FromRule<TRequest, TResponse>(response, _resourceNotFound);
        }

        protected TResponse GenericException<TRequest, TResponse>(TResponse response)
            where TRequest : RequestBase
            where TResponse : ResponseBase<TRequest>
        {
            response = FromRule<TRequest, TResponse>(response, _genericException);
            return response;
        }

        protected TResponse FromRule<TRequest, TResponse>(TResponse response, Rule rule)
            where TRequest : RequestBase
            where TResponse : ResponseBase<TRequest>
        {
            if (rule != null)
            {
                response.Message = rule.Message;
                response.Statuses.Add
                    (
                        new ResponseStatus
                        {
                            Code = rule.Code,
                            Message = rule.Message
                        }
                    );
            }
            else
            {
                response.Message = string.Empty;
            }

            response.Success = false;

            return response;
        }
    }
}
