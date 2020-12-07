namespace GHI.PythonSharp.Language
{
    using System;
    
    
    using System.Text;

    public interface IValues
    {
        object GetValue(string name);

        void SetValue(string name, object value);

        bool HasValue(string name);

        ICollection<string> GetNames();
    }
}
