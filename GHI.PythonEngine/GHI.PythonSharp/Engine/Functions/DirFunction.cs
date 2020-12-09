namespace GHI.PythonSharp.Functions
{
    using System;
    using System.Collections;
    using System.Text;
    using GHI.PythonSharp.Compiler;
    using GHI.PythonSharp.Exceptions;
    using GHI.PythonSharp.Expressions;
    using GHI.PythonSharp.Helper;
    using GHI.PythonSharp.Language;
    using GHI.PythonSharp.Utilities;

    public class DirFunction : IFunction
    {
        //public object Apply(IContext context, IList<object> arguments, IDictionary<string, object> namedArguments)
        public object Apply(IContext context, ArrayList arguments, Hashtable namedArguments)
        {
            int nargs = arguments == null ? 0 : arguments.Count;

            if (nargs > 1)
                throw new TypeError(string.Format("dir expected at most 1 arguments, got {0}", nargs));

            IValues values = nargs == 0 ? context : arguments[0] as IValues;

            if (nargs == 0 || values != null)
            {
                //return values.GetNames().OrderBy(s => s).ToList();
                var obj =  SortExtensions.SortStringAsc(values.GetNames());
                return obj;
            }

            return ObjectUtilities.GetNames(arguments[0]);
        }
    }
}
