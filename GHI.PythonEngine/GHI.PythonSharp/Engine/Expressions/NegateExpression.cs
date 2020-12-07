namespace GHI.PythonSharp.Expressions
{
    using System;
    
    
    using System.Text;
    using GHI.PythonSharp.Language;

    public class NegateExpression : IExpression
    {
        private IExpression expression;

        public NegateExpression(IExpression expression)
        {
            this.expression = expression;
        }

        public object Evaluate(IContext context)
        {
            return Numbers.Negate(this.expression.Evaluate(context));
        }
    }
}
