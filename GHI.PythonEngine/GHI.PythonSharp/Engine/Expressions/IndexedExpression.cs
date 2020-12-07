namespace GHI.PythonSharp.Expressions
{
    using System.Collections;
    
    
    using System.Text;
    using GHI.PythonSharp.Language;
    using GHI.PythonSharp.Utilities;

    public class IndexedExpression : IExpression
    {
        private IExpression targetExpression;
        private IExpression sliceExpression;

        public IndexedExpression(IExpression targetExpression, IExpression sliceExpression)
        {
            this.targetExpression = targetExpression;
            this.sliceExpression = sliceExpression;
        }

        public IExpression TargetExpression { get { return this.targetExpression; } }

        public IExpression IndexExpression { get { return this.sliceExpression; } }

        public object Evaluate(IContext context)
        {
            object target = this.targetExpression.Evaluate(context);
            object index = this.sliceExpression.Evaluate(context);

            if (target is string)
                return ((string)target)[(int)index].ToString();

            return ObjectUtilities.GetIndexedValue(target, new object[] { index });
        }
    }
}
