using System;
using System.Collections;
using System.Text;
using System.Threading;

namespace GHI.PythonSharp.Helper
{
    public sealed class InvalidDataException : SystemException
    {
        public InvalidDataException()
            : base("Data Invalid")
        {
        }

        public InvalidDataException(string message)
            : base(message)
        {
        }

        public InvalidDataException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }
}
