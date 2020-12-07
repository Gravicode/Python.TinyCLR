namespace GHI.PythonSharp.Language
{
    using System;
    
    
    using System.Text;

    // TODO add IValues, see StringType, then review DefinedClass iterations over bases
    public interface IType : IValues
    {
        string Name { get; }

        IFunction GetMethod(string name);

        bool HasMethod(string name);
    }
}
