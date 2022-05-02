using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public class ServiceResult<T>
    {
        private List<string> _errorMessages;

        public ServiceResult()
        {
            _errorMessages = new List<string>();
        }

        public bool HasErrors { get; private set; }
        public T Data { get; set; }
        public IEnumerable<string> ErrorMessages { get => _errorMessages; }

        public void AddError(string error)
        {
            HasErrors = true;
            _errorMessages.Add(error);
        }

        public void AddErrors(IEnumerable<string> errors)
        {
            HasErrors = true;
            _errorMessages.AddRange(errors);
        }
    }

    public class ServiceResult : ServiceResult<object>
    {

    }
}
