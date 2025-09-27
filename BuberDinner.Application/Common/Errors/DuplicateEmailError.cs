using FluentResults;

namespace BuberDinner.Application.Common.Errors
{
    public class DuplicateEmailError : Error
    {
        public List<Error> Reasons => throw new NotImplementedException();
        public string Message => throw new NotImplementedException();
        public Dictionary<string, object> Metadata => throw new NotImplementedException();
    }
}
