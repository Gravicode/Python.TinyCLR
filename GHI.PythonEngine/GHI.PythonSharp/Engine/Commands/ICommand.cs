namespace GHI.PythonSharp.Commands
{
    using GHI.PythonSharp.Language;

    public interface ICommand
    {
        void Execute(IContext context);
    }
}
