﻿namespace GHI.PythonSharp.Language
{
    using System;
    
    
    using System.Text;
    using GHI.PythonSharp.Exceptions;

    public class DynamicObject : IObject
    {
        private IType klass;
        private IDictionary<string, object> values = new Dictionary<string, object>();

        public DynamicObject(IType klass)
        {
            this.klass = klass;
        }

        public IType Class { get { return this.klass; } }

        public object GetValue(string name)
        {
            if (this.values.ContainsKey(name))
                return this.values[name];

            return this.klass.GetValue(name);
        }

        public void SetValue(string name, object value)
        {
            this.values[name] = value;
        }

        public bool HasValue(string name)
        {
            if (this.values.ContainsKey(name))
                return true;

            if (this.klass != null)
                return this.klass.HasValue(name);

            return false;
        }

        public object Invoke(string name, IContext context, IList<object> arguments, IDictionary<string, object> namedArguments)
        {
            var value = this.GetValue(name);
            IFunction method = value as IFunction;

            if (method == null)
                throw new TypeError(string.Format("'{0}' object is not callable", Types.GetTypeName(value)));

            IList<object> args = new List<object>() { this };

            if (arguments != null && arguments.Count > 0)
                foreach (var arg in arguments)
                    args.Add(arg);

            return method.Apply(context, args, namedArguments);
        }

        public ICollection<string> GetNames()
        {
            return this.values.Keys.ToList();
        }
    }
}
