using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;

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

    #region Enum Extensions
    /// <summary>
    /// <para>
    /// Gets the value of the Display attribute on an enum's value.
    /// Or <see cref="string.Empty"/> if the attribute is not present.
    /// </para>
    /// </summary>
    /// <param name="enumValue">Enum value to target.</param>
    /// <returns>String content of <paramref name="enumValue"/> or <see cref="string.Empty"/>.</returns>
    public static string GetDisplayName(this Enum enumValue)
    {
        return enumValue.GetType()?
                        .GetMember(enumValue.ToString())?
                        .First()?
                        .GetCustomAttribute<DisplayAttribute>()?
                        .GetName() ?? string.Empty;
    }

    /// <summary>
    /// Determines whether the enum value contains a specific value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="request">The request.</param>
    /// <returns>
    ///     <c>true</c> if value contains the specified value; otherwise, <c>false</c>.
    /// </returns>
    public static bool Contains<T>(this Enum value, T request)
    {
        int valueAsInt = Convert.ToInt32(value, CultureInfo.InvariantCulture);
        int requestAsInt = Convert.ToInt32(request, CultureInfo.InvariantCulture);

        if (requestAsInt == (valueAsInt & requestAsInt))
            return true;

        return false;
    }

    /// <summary>
    /// Gets all items for an enum value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    public static IEnumerable<T> GetAllItems<T>(this Enum _)
    {
        foreach (object item in Enum.GetValues(typeof(T)))
        {
            yield return (T)item;
        }
    }
    #endregion
}
