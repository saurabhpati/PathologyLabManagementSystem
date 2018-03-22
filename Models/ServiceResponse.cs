using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class ServiceResponse
    {
        private string _errorMessage;
        public StatusType Status { get; set; }
        public Exception Error { get; set; }
        public String ErrorMessage
        {
            get
            {
                if (string.IsNullOrEmpty(_errorMessage) && (Error != null))
                { 
                if (string.IsNullOrEmpty(Error.Message))
                {
                    return Error.Message;
                }
                    
                    return Error.GetBaseException().GetType().Name;
                }
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
            }
        }
    }

    public class ServiceResponse<T> : ServiceResponse
    {
        public T Data { get; set; }
    }

    public enum StatusType
    {
        Failure = 0,
        Success = 1
    }
}