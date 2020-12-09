namespace GHI.PythonSharp.Functions
{
    using System;
    using System.Collections;
    
    
    using System.Text;
    using GHI.PythonSharp.Exceptions;
    using GHI.PythonSharp.Language;

    public class LenFunction : IFunction
    {
        //public object Apply(IContext context, IList<object> arguments, IDictionary<string, object> namedArguments)
        public object Apply(IContext context, ArrayList arguments, Hashtable namedArguments)
        {
            int nargs = arguments == null ? 0 : arguments.Count;

            if (nargs != 1)
                throw new TypeError(string.Format("len() takes exactly one argument ({0} given)", nargs));

            object argument = arguments[0];

            if (argument is IList)
                return ((IList)argument).Count;

            if (argument is string)
                return ((string)argument).Length;

            if (argument is ICollection)
                return ((ICollection)argument).Count;

            throw new TypeError(string.Format("object of type '{0}' has no len()", Types.GetTypeName(argument)));
        }
    }
}
