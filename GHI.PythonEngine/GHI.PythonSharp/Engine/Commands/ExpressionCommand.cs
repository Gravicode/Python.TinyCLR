namespace GHI.PythonSharp.Commands
{
    using System.Text;

    using GHI.PythonSharp.Expressions;
    using GHI.PythonSharp.Language;

    public class ExpressionCommand : ICommand
    {
        private IExpression expression;

        public ExpressionCommand(IExpression expression)
        {
            this.expression = expression;
        }

        public IExpression Expression { get { return this.expression; } }

        public void Execute(IContext context)
        {
            this.expression.Evaluate(context);
        }
    }
}
