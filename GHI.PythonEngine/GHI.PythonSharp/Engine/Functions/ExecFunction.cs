namespace GHI.PythonSharp.Functions
{
    using System;
    using System.Collections;
    using System.Text;
    using GHI.PythonSharp.Commands;
    using GHI.PythonSharp.Compiler;
    using GHI.PythonSharp.Exceptions;
    using GHI.PythonSharp.Expressions;
    using GHI.PythonSharp.Language;

    public class ExecFunction : IFunction
    {
        //public object Apply(IContext context, IList<object> arguments, IDictionary<string, object> namedArguments)
        public object Apply(IContext context, ArrayList arguments, Hashtable namedArguments)
        {
            int nargs = arguments == null ? 0 : arguments.Count;

            if (nargs == 0)
                throw new TypeError("exec expected at least 1 arguments, got 0");

            // TODO implement bytes or code object
            if (!(arguments[0] is string))
                throw new TypeError("exec() arg 1 must be a string, bytes or code object");

            Parser parser = new Parser((string)arguments[0]);

            ICommand command = parser.CompileCommandList();

            if (command == null)
                return null;

            command.Execute(context);

            return null;
        }
    }
}
