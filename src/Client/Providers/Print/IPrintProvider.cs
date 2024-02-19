using System.Collections.Generic;

namespace WpfTest
{
    /// <summary>
    /// Поставщик для вывода отчета
    /// </summary>
    public interface IPrintProvider
    {
        /// <summary>
        /// Сделать отчет
        /// </summary>
        /// <typeparam name="T">Тип сущностей для вывода</typeparam>
        /// <param name="items">Сущности для вывода</param>
        void Print<T>(IEnumerable<T> items);
    }
}
