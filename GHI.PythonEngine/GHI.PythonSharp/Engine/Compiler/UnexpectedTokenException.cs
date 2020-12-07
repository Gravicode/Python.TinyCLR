namespace GHI.PythonSharp.Compiler
{
    using System;
    
    using System.Globalization;
    
    using System.Text;
    using GHI.PythonSharp.Exceptions;

    public class UnexpectedTokenException : SyntaxError
    {
        public UnexpectedTokenException(Token token)
            : base(string.Format(CultureInfo.CurrentCulture, "Unexpected '{0}'", token.Value))
        {
        }

        public UnexpectedTokenException(string text)
            : base(string.Format(CultureInfo.CurrentCulture, "Unexpected '{0}'", text))
        {
        }
    }
}
