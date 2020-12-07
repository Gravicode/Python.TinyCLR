namespace GHI.PythonSharp.Expressions
{
    using System;
    
    
    using System.Text;
    using GHI.PythonSharp.Exceptions;
    using GHI.PythonSharp.Language;

    public class NameExpression : IExpression
    {
        private string name;

        public NameExpression(string name)
        {
            this.name = name;
        }

        public string Name { get { return this.name; } }

        public object Evaluate(IContext context)
        {
            object value = context.GetValue(this.name);

            if (value != null)
                return value;

            if (context.HasValue(this.name))
                return value;

            throw new NameError(string.Format("name '{0}' is not defined", this.name));
        }
    }
}
