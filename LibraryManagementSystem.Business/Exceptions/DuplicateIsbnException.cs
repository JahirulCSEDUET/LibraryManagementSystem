using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Business.Exceptions
{
    public class DuplicateIsbnException:Exception
    {
        public DuplicateIsbnException() { }
        public DuplicateIsbnException(string message) : base(message) { }
        public DuplicateIsbnException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
