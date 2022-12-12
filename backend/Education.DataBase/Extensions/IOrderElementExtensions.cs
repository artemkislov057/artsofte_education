using Education.DataBase.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Education.DataBase.Extensions;

public static class IOrderElementExtensions
{
    public static T[] OrderElements<T>(this T[] source, int startOrder = 0)
        where T : IOrderElement
    {
        for (var i = 0; i < source.Length; ++i)
        {
            source[i].Order = i + startOrder;
        }

        return source;
    }

    public static async Task<int[]> GetOrders(this IQueryable<IOrderElement> source)
    {
        return await source.Select(w => w.Order).ToArrayAsync();
    }
}