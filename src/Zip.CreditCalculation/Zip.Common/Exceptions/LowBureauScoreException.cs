using System;

namespace Zip.Common.Exceptions
{
    public class LowBureauScoreException : Exception
    {
        public LowBureauScoreException() : base("Low Bureau Score (not allowed to use Zip)")
        {
        }
    }
}
