namespace GHI.PythonSharp.Exceptions
{
    using System;
    
    
    using System.Text;

    public class ImportError : Exception
    {
        public ImportError(string message)
            : base(message)
        {
        }
    }
}
