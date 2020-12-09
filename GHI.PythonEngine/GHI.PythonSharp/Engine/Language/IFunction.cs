namespace GHI.PythonSharp.Language
{
    using System;
    using System.Collections;
    using System.Text;

    public interface IFunction
    {
        //object Apply(IContext context, IList<object> arguments, IDictionary<string, object> namedArguments);
        object Apply(IContext context, ArrayList arguments, Hashtable namedArguments);
    }
}