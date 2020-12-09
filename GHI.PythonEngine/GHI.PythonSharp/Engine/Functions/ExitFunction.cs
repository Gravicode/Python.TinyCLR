namespace GHI.PythonSharp.Functions
{
    using System;
    using System.Collections;
    
    
    using System.Text;
    using GHI.PythonSharp.Exceptions;
    using GHI.PythonSharp.Language;

    public class ExitFunction : IFunction
    {
        //public object Apply(IContext context, IList<object> arguments, IDictionary<string, object> namedArguments)
        public object Apply(IContext context, ArrayList arguments, Hashtable namedArguments)
        {
            int nargs = arguments == null ? 0 : arguments.Count;

            if (nargs > 1)
                throw new TypeError(string.Format("range expected at most 1 arguments, got {0}", nargs));

            int value = 0;

            if (nargs > 0)
                value = Numbers.ToInteger(arguments[0]);

            //do nothing, or reset interpreter
            //System.Environment.Exit(value);

            return null;
        }
    }
}
