namespace GHI.PythonSharp.Language
{
    using System;
    
    
    using System.Text;

    public interface IFunction
    {
        object Apply(IContext context, IList<object> arguments, IDictionary<string, object> namedArguments);
    }
}