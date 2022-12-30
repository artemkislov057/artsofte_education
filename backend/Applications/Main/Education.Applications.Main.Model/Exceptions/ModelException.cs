namespace Education.Applications.Main.Model.Exceptions;

public abstract class ModelException : Exception
{
    protected ModelException(string message) : base(message)
    {
    }
}