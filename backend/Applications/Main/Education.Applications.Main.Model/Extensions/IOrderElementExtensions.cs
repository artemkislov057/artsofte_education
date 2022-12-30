using Education.Applications.Main.Model.Exceptions;
using Education.DataBase.Interfaces;

namespace Education.Applications.Main.Model.Extensions;

public static class IOrderElementExtensions
{
    public static void ChangeOrder<TOrderEntity, T>(this TOrderEntity[] source, T[] orderIds)
        where TOrderEntity : class, IOrderEntity<T>
        where T : notnull
    {
        var availableIds = source
            .Select(m => m.Id)
            .ToHashSet();

        if (source.Length != orderIds.Length)
        {
            throw new OrderingException(
                $"Переданный массив идентификаторов имеет некорректную длину (Длина переданного массива: {orderIds.Length}, должна быть: {source.Length})");
        }

        var orderByIdDictionary = new Dictionary<T, int>();
        for (var i = 0; i < orderIds.Length; ++i)
        {
            if (!availableIds.Contains(orderIds[i]) || orderByIdDictionary.ContainsKey(orderIds[i]))
            {
                throw new OrderingException(
                    $"Переданный массив идентификаторов содержит некорректный идентификатор {orderIds[i]}");
            }

            orderByIdDictionary[orderIds[i]] = i;
        }

        foreach (var module in source)
        {
            module.Order = orderByIdDictionary[module.Id];
        }
    }
}