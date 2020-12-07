namespace GHI.PythonSharp.Exceptions
{
    using System;
    
    
    using System.Text;

    public class AttributeError : Exception
    {
        public AttributeError(string message)
            : base(message)
        {
        }
    }
}
