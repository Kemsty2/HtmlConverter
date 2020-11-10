using System;

namespace HtmlConverter.Exceptions
{
    public class NotGeneratedException : Exception
    {
        public NotGeneratedException(string message) : base(message)
        {
        }
    }
}