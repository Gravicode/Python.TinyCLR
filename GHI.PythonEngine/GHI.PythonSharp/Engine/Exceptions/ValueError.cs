namespace GHI.PythonSharp.Exceptions
{
    using System;
    
    
    using System.Text;

    public class ValueError : Exception
    {
        public ValueError(string message)
            : base(message)
        {
        }
    }
}
