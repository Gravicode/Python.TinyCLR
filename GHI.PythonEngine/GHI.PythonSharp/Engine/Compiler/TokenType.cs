namespace GHI.PythonSharp.Compiler
{
    using System;
    
    
    using System.Text;

    public enum TokenType
    {
        Name,
        Integer,
        Real,
        Boolean,
        String,
        Operator,
        Separator,
        EndOfLine
    }
}
