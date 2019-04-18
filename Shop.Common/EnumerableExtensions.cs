namespace Shop.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Extensions for enumerations
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Run action for each item in enumeration
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <param name="source">Source collection</param>
        /// <param name="action">Action to run</param>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="action"/> is <see langword="null" />.</exception>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            foreach (var item in source)
            {
                action(item);
            }
        }
    }
}