using Education.Extensions.Bcl;

namespace Education.Applications.Main.Model.Exceptions;

public class NotMatchException : ModelException
{
    public NotMatchException(string sourceName, object sourceId, string objectName, object objectId)
        : base($"{sourceName.WithUpperFirstLetter()} с идентификатором {sourceId} не содержит {objectName} с идентификатором {objectId}")
    {
    }
}