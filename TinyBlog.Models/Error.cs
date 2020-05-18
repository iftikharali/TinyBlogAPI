using System;
using System.Collections.Generic;
using System.Text;

namespace TinyBlog.Models
{
    public enum ErrorCode
    {
        InvalidCredentials = 100,
        AccountIsLocked,

    }
    public enum ErrorType
    {
        Error = 1,
        Warning = 2,
        Bug = 3
    }
    public class Error
    {
        public int ErrorKey { get; set; }
        public Guid ErrorGuid { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public int Severity { get; set; }
        public int Type { get; set; }

        public DateTime CreatedAt { get; set; }
        public User CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User UpdatedBy { get; set; }
        
        public Error getError(ErrorCode errorCode)
        {
            switch (errorCode)
            {
                case ErrorCode.AccountIsLocked:
                    return new Error()
                    {
                        ErrorKey = 1,
                        Code = (int)errorCode,
                        Message = "Your account is temporarily Locked.",
                        Severity = 1,
                        Type = (int)ErrorType.Error
                    };
            }
            return null;
        }

        public Error()
        {
        }

        private List<Error> errors = new List<Error>();

    }
}
