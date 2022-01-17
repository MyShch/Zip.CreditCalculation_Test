using System;

namespace Zip.Common.Exceptions
{
    public class YoungAgeException : Exception
    {
        public YoungAgeException() : base("Consumers can apply for credit starting at age 18")
        {

        }
    }
}
