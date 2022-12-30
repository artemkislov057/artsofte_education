using Education.Extensions.Bcl;

namespace Education.Applications.Main.Model.Exceptions;

public sealed class NotFoundException : ModelException
{
    public NotFoundException(string objectName, object objectId)
        : base($"{objectName.WithUpperFirstLetter()} с идентификатором {objectId} не сущетвует")
    {
    }
}