namespace GHI.PythonSharp.Commands
{
    using System;
    using System.Text;
    using GHI.PythonSharp.Expressions;
    using GHI.PythonSharp.Language;

    public class SetCommand : ICommand
    {
        private string target;
        private IExpression expression;

        public SetCommand(string target, IExpression expression)
        {
            if (target == null)
                throw new ArgumentNullException("target");

            if (expression == null)
                throw new ArgumentNullException("expression");

            this.target = target;
            this.expression = expression;
        }

        public string Target { get { return this.target; } }

        public IExpression Expression { get { return this.expression; } }

        public void Execute(IContext context)
        {
            context.SetValue(this.target, this.expression.Evaluate(context));
        }
    }
}
