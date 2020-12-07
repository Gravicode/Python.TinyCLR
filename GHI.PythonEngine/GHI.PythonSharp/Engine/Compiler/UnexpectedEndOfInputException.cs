namespace GHI.PythonSharp.Compiler
{
    using System;
    
    using System.Globalization;
    
    using System.Text;
    using GHI.PythonSharp.Exceptions;

    public class UnexpectedEndOfInputException : SyntaxError
    {
        public UnexpectedEndOfInputException()
            : base("Unexpected End of Input")
        {
        }
    }
}
