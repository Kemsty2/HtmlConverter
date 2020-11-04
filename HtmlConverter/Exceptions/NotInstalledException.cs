using System;

namespace HtmlConverter.Exceptions
{
    public class NotInstalledException : Exception
    {
        public NotInstalledException(string msg) : base(msg)
        {
        }
    }
}