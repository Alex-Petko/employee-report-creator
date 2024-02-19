namespace WpfTest
{
    /// <summary>
    /// Конфигурация приложения
    /// </summary>
    public interface IConfigurations
    {
        /// <summary>
        /// Строка подключения к базе данных
        /// </summary>
        string ConnectionString { get; }

        /// <summary>
        /// Путь вывода ecxel таблицы
        /// </summary>
        string ExcelOutputPath { get; }

        /// <summary>
        /// Имя файла ecxel таблицы
        /// </summary>
        string ExcelOutputFileName { get; }
    }
}
