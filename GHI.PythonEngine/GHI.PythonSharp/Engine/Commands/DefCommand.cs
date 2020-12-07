namespace GHI.PythonSharp.Commands
{
    using System;
    using System.Collections;
    using System.Text;
    using GHI.PythonSharp.Exceptions;
    using GHI.PythonSharp.Expressions;
    using GHI.PythonSharp.Language;
    using GHI.PythonSharp.Utilities;

    public class DefCommand : ICommand
    {
        private string name;
        //private IList<ParameterExpression> parameterExpressions;
        private ArrayList parameterExpressions;
        private ICommand body;
        private string doc;

        public DefCommand(string name, ArrayList parameterExpressions, ICommand body)
        {
            this.name = name;
            this.parameterExpressions = parameterExpressions;
            this.body = body;
            this.doc = CommandUtilities.GetDocString(this.body);

            if (this.parameterExpressions != null)
            {
                bool hasdefault = false;

                foreach (ParameterExpression parexpr in this.parameterExpressions)
                    if (parexpr.DefaultExpression != null)
                        hasdefault = true;
                    else if (hasdefault)
                        throw new SyntaxError("non-default argument follows default argument");
            }
        }

        public string Name { get { return this.name; } }

        public ArrayList ParameterExpressions { get { return this.parameterExpressions; } }

        public ICommand Body { get { return this.body; } }

        public void Execute(IContext context)
        {
            //IList<Parameter> parameters = null;
            ArrayList parameters = null;

            if (this.parameterExpressions != null && this.parameterExpressions.Count > 0)
            {
                parameters = new ArrayList();
                foreach (ParameterExpression parexpr in this.parameterExpressions)
                    parameters.Add((Parameter)parexpr.Evaluate(context));
            }

            DefinedFunction function = new DefinedFunction(this.name, parameters, this.body, context);

            function.SetValue("__doc__", this.doc);

            context.SetValue(this.name, function);
        }
    }
}
