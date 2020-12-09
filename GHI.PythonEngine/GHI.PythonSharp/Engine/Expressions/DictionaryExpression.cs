namespace GHI.PythonSharp.Expressions
{
    using System.Collections;
    
    
    using System.Text;
    using GHI.PythonSharp.Language;

    public class DictionaryExpression : IExpression
    {
        //private List<IExpression> keyExpressions = new List<IExpression>();
        private ArrayList keyExpressions = new ArrayList();
        private ArrayList valueExpressions = new ArrayList();

        public DictionaryExpression()
        {
        }

        //public List<IExpression> KeyExpressions { get { return this.keyExpressions; } }
        public ArrayList KeyExpressions { get { return this.keyExpressions; } }

        //public List<IExpression> ValueExpressions { get { return this.valueExpressions; } }
        public ArrayList ValueExpressions { get { return this.valueExpressions; } }

        public void Add(IExpression keyExpression, IExpression valueExpression)
        {
            this.keyExpressions.Add(keyExpression);
            this.valueExpressions.Add(valueExpression);
        }

        public object Evaluate(IContext context)
        {
            IDictionary dictionary = new Hashtable();

            int n = 0;

            foreach (IExpression keyExpression in this.keyExpressions)
            {
                object key = keyExpression.Evaluate(context);
                object value = (this.valueExpressions[n] as IExpression).Evaluate(context);
                dictionary[key] = value;
                n++;
            }

            return dictionary;
        }
    }
}
