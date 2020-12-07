namespace GHI.PythonSharp.Commands
{
    using System;
    using System.Text;
    using GHI.PythonSharp.Expressions;
    using GHI.PythonSharp.Language;

    public class ReturnCommand : ICommand
    {
        private IExpression expression;

        public ReturnCommand(IExpression expression)
        {
            this.expression = expression;
        }

        public IExpression Expression { get { return this.expression; } }

        public void Execute(IContext context)
        {
            BindingEnvironment environment = (BindingEnvironment)context;

            if (this.expression == null)
                environment.SetReturnValue(null);
            else
                environment.SetReturnValue(this.expression.Evaluate(environment));
        }
    }
}
