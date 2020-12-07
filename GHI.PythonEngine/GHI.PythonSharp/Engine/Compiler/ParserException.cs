namespace GHI.PythonSharp.Compiler
{
    using System;
    
    
    using System.Text;

    [Serializable]
    public abstract class ParserException : Exception
    {
        protected ParserException(string msg)
            : base(msg)
        {
        }
    }
}
