namespace GHI.PythonSharp.Compiler
{
    using System;
    
    using System.Globalization;
    
    using System.Text;

    public class ExpectedTokenException : ParserException
    {
        public ExpectedTokenException(string token)
            : base(string.Format(CultureInfo.CurrentCulture, "Expected '{0}'", token))
        {
        }
    }
}
