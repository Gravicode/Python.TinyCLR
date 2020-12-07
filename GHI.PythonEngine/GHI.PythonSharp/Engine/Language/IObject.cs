namespace GHI.PythonSharp.Language
{
    using System;
    
    
    using System.Text;

    public interface IObject : IValues
    {
        object Invoke(string name, IContext context, IList<object> arguments, IDictionary<string, object> namedArguments);
    }
}
