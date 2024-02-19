using System.Configuration;

namespace WpfTest
{
    /// <inheritdoc />
    internal class Configurations : IConfigurations
    {
        public string ConnectionString => ConfigurationManager.AppSettings["ConnectionString"];

        public string ExcelOutputPath => ConfigurationManager.AppSettings["ExcelOutputPath"];

        public string ExcelOutputFileName => ConfigurationManager.AppSettings["ExcelOutputFileName"];
    }
}
