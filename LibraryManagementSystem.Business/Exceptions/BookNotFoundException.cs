using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.Business.Exceptions
{
    public class BookNotFoundException:Exception
    {
        public BookNotFoundException() { }
        public BookNotFoundException(string message) : base(message) { }
        public BookNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
