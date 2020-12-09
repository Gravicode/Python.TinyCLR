﻿namespace GHI.PythonSharp.Functions
{
    using System;
    using System.Collections;
    
    
    using System.Text;
    using GHI.PythonSharp.Exceptions;
    using GHI.PythonSharp.Language;

    public class ContextFunction : IFunction
    {
        private string name;
        private bool isglobal;

        public ContextFunction(string name, bool isglobal)
        {
            this.isglobal = isglobal;
            this.name = name;
        }

        public bool IsGlobal { get { return this.isglobal; } }

        public string Name { get { return this.name; } }

        //public object Apply(IContext context, IList<object> arguments, IDictionary<string, object> namedArguments)
        public object Apply(IContext context, ArrayList arguments, Hashtable namedArguments)
        {
            int nargs = arguments == null ? 0 : arguments.Count;

            if (nargs != 0)
                throw new TypeError(string.Format("{0}() takes no arguments ({1} given)", this.name, nargs));

            if (this.isglobal)
                return context.GlobalContext;

            return context;
        }
    }
}
