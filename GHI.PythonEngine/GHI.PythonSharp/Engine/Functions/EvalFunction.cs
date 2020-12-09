namespace GHI.PythonSharp.Functions
{
    using System;
    using System.Collections;
    using System.Text;
    using GHI.PythonSharp.Compiler;
    using GHI.PythonSharp.Exceptions;
    using GHI.PythonSharp.Expressions;
    using GHI.PythonSharp.Language;

    public class EvalFunction : IFunction
    {
        //public object Apply(IContext context, IList<object> arguments, IDictionary<string, object> namedArguments)
        public object Apply(IContext context, ArrayList arguments, Hashtable namedArguments)
        {
            int nargs = arguments == null ? 0 : arguments.Count;

            if (nargs == 0)
                throw new TypeError("eval expected at least 1 arguments, got 0");

            // TODO implement bytes or code object
            if (!(arguments[0] is string))
                throw new TypeError("eval() arg 1 must be a string, bytes or code object");

            Parser parser = new Parser((string)arguments[0]);

            IExpression expression = parser.CompileExpression();

            if (expression == null)
                return null;

            return expression.Evaluate(context);
        }
    }
}
