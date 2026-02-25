using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Business.Exceptions
{
    public class InvalidPublicationYearException:Exception
    {
        public InvalidPublicationYearException() { }
        public InvalidPublicationYearException(string message) : base(message) { }
        public InvalidPublicationYearException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
