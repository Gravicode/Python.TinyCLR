﻿namespace GHI.PythonSharp.Expressions
{
    using System.Collections;
    
    
    using System.Text;
    using GHI.PythonSharp.Language;

    public class SlicedExpression : IExpression
    {
        private IExpression targetExpression;
        private SliceExpression sliceExpression;

        public SlicedExpression(IExpression targetExpression, SliceExpression sliceExpression)
        {
            this.targetExpression = targetExpression;
            this.sliceExpression = sliceExpression;
        }

        public IExpression TargetExpression { get { return this.targetExpression; } }

        public SliceExpression SliceExpression { get { return this.sliceExpression; } }

        public object Evaluate(IContext context)
        {
            object target = this.targetExpression.Evaluate(context);
            Slice slice = (Slice)this.sliceExpression.Evaluate(context);
            int begin = slice.Begin ?? 0;
            int end;

            if (target is string)
            {
                string text = (string)target;
                end = slice.End ?? text.Length;
                if (end > text.Length)
                    end = text.Length;
                return text.Substring(begin, end - begin);
            }

            IList list = (IList)target;
            end = slice.End ?? list.Count;
            if (end > list.Count)
                end = list.Count;

            //IList result = new List<object>();
            IList result = new ArrayList();

            for (int k = begin; k < end && k < list.Count; k++)
                result.Add(list[k]);

            return result;
        }
    }
}
