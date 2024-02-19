namespace WpfTest
{
    /// <summary>
    /// Поставщик для запросов только для модификации
    /// </summary>
    public interface ICommandProvider
    {
        /// <summary>
        /// Сделать базу данных, если ее еще нет
        /// </summary>
        void TryInit();

        /// <summary>
        /// Обновить сущность
        /// </summary>
        /// <param name="employee">Сущность для обновления</param>
        void Update(EmployeeVm employee);
    }
}
