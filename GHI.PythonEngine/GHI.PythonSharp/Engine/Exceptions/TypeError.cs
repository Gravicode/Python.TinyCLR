namespace GHI.PythonSharp.Exceptions
{
    using System;
    
    
    using System.Text;

    public class TypeError : Exception
    {
        public TypeError(string message)
            : base(message)
        {
        }
    }
}
