namespace GHI.PythonSharp.Exceptions
{
    using System;
    
    
    using System.Text;

    public class SyntaxError : Exception
    {
        public SyntaxError(string message)
            : base(message)
        {
        }
    }
}
