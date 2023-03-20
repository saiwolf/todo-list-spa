using System.Linq;

namespace TodoListSPA.Helpers;

public static class ExtensionMethods
{
    /// <summary>
    /// <para>Adds an item to the collection, if it is not already in the collection.</para>
    /// </summary>
    /// <typeparam name="T"><see cref="object"/></typeparam>
    /// <param name="list">The list/collection to add to.</param>
    /// <param name="value">The object to add to the collection.</param>
    /// <returns><see cref="IEnumerable{T}"/> if <typeparamref name="T"/> was not already in collection.</returns>
    public static IEnumerable<T> AddDistinct<T>(this IEnumerable<T> list, T value)
    {
        if (!list.Contains(value))
            return list.Append(value);
        return list;
    }

    /// <summary>
    /// <para>Adds a range of items to a collection, if said range is not already in collection.</para>
    /// </summary>
    /// <typeparam name="T"><see cref="object"/></typeparam>
    /// <param name="list">The list/collection to add to.</param>
    /// <param name="values">The values to add.</param>
    /// <returns><see cref="IEnumerable{T}"/> containing values in <paramref name="values"/>, if they were not already in collection.</returns>
    public static IEnumerable<T> AddRangeDistinct<T>(this IEnumerable<T> list, IEnumerable<T> values)
    {
        if (values is null || values.Any()) return list;
        foreach (T item in values)
        {
            if (!list.Contains(item))
                list = list.Append(item);
            else
                continue;
        }
        return list;
    }
}
