namespace GHI.PythonSharp.Language
{
    using System;
    
    
    using System.Text;

    public interface IContext : IValues
    {
        IContext GlobalContext { get; }
    }
}
