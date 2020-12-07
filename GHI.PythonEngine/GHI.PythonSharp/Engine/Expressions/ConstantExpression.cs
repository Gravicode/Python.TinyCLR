namespace GHI.PythonSharp.Expressions
{
    
    
    using System.Text;
    using GHI.PythonSharp.Language;

    public class ConstantExpression : IExpression
    {
        private object value;

        public ConstantExpression(object value)
        {
            this.value = value;
        }

        public object Value { get { return this.value; } }

        public object Evaluate(IContext context)
        {
            return this.value;
        }
    }
}
