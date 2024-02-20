using System.Collections.Generic;

namespace WpfTest
{
    /// <summary>
    /// Поставщик для запросов только для чтения
    /// </summary>
    public interface IQueryProvider
    {
        /// <summary>
        /// Получить информацию о всех сотрудниках
        /// </summary>
        /// <param name="searchText">Параметр полнотекстового поиска по фамилии, названию подразделению и городу (Case-Insentive).
        /// Если параметр пустой или равен null, происходит полная фильтрация</param>
        /// <returns></returns>
        IEnumerable<EmployeeVm> GetEmployees(string searchText);

        /// <summary>
        /// Получить информацию о всех подразделениях
        /// </summary>
        /// <returns></returns>
        IEnumerable<SubdivisionVm> GetSubdivisions();

        /// <summary>
        /// Получить информацию о всех должностях
        /// </summary>
        /// <returns></returns>
        IEnumerable<PositionVm> GetPositions();
    }
}
