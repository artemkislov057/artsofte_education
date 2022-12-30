using Education.Extensions.Bcl;

namespace Education.DataBase.Exceptions;

public sealed class NotMatchException : Exception
{
    public NotMatchException(string sourceName, object sourceId, string objectName, object objectId)
        : base($"{sourceName.WithUpperFirstLetter()} с идентификатором {sourceId} не содержит {objectName} с идентификатором {objectId}")
    {
    }
}