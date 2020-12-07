namespace GHI.PythonSharp.Exceptions
{
    using System;
    
    
    using System.Text;

    public class NameError : Exception
    {
        public NameError(string message)
            : base(message)
        {
        }
    }
}
