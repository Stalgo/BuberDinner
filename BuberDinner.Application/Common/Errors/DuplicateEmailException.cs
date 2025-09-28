using System.Net;

namespace BuberDinner.Application.Common.Errors
{
    public class DuplicateEmailException : Exception, IServiceException
    {
        public DuplicateEmailException(string message)
            : base(message) { }

        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        //vulnerability
        public string ErrorMessage => "Email already exists";
    }
}
