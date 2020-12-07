namespace GHI.PythonSharp.Compiler
{
    using System;
    
    
    using System.Text;

    public class NameExpectedException : ParserException
    {
        public NameExpectedException()
            : base("A name was expected")
        {
        }
    }
}
