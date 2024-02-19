using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;

namespace WpfTest
{
    /// <inheritdoc />
    internal class OracleQueryProvider : IQueryProvider
    {
        private const string EmployeeIdOut = "employee_id";
        private const string NameOut = "name";
        private const string SubdivisionOut = "subdivision";
        private const string SubdivisionIdOut = "subdivision_id";
        private const string CityOut = "city";
        private const string PositionOut = "position";
        private const string PositionIdOut = "position_id";
        private const string SalaryOut = "salary";

        private const string SearchTextParamName = ":searchText";
        private const int SearchTextParamSize = 50;

        private readonly IConfigurations _configurations;

        private string GetEmployeesCommandText =>
$@"SELECT e.employee_id {EmployeeIdOut}, e.name {NameOut}, s.name {SubdivisionOut}, s.subdivision_id {SubdivisionIdOut}, c.name {CityOut}, p.name {PositionOut}, p.position_id {PositionIdOut}, e.salary {SalaryOut} FROM Employees e
JOIN Positions p on p.position_id = e.position_id
JOIN Subdivisions s ON s.subdivision_id = e.subdivision_id
JOIN Cities c ON c.city_id = s.city_id
WHERE e.name={SearchTextParamName} OR s.name={SearchTextParamName} OR c.name={SearchTextParamName} OR {SearchTextParamName} IS NULL";

        private string GetSubdivisionsCommandText => $"SELECT {SubdivisionIdOut}, {NameOut} FROM Subdivisions";

        private string GetPositionsCommandText => $"SELECT {PositionIdOut}, {NameOut} FROM Positions";

        public OracleQueryProvider(IConfigurations configurations)
        {
            _configurations = configurations;
        }

        public IEnumerable<EmployeeVm> GetEmployees(string searchText)
        {
            using (var con = new OracleConnection(_configurations.ConnectionString))
            {
                con.Open();
                var cmd = con.CreateCommand();

                cmd.CommandText = GetEmployeesCommandText;

                searchText = string.IsNullOrWhiteSpace(searchText) ? null : searchText;
                cmd.Parameters.Add(SearchTextParamName, OracleDbType.Varchar2, SearchTextParamSize).Value = searchText;

                var dataTable = new DataTable();
                var dataAdapter = new OracleDataAdapter(cmd);

                dataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    yield return new EmployeeVm
                    {
                        EmployeeId = (int)(decimal)row[EmployeeIdOut],
                        Name = (string)row[NameOut],
                        Subdivision = (string)row[SubdivisionOut],
                        SubdivisionId = (int)(decimal)row[SubdivisionIdOut],
                        City = (string)row[CityOut],
                        Position = (string)row[PositionOut],
                        PositionId = (int)(decimal)row[PositionIdOut],
                        Salary = (int)(decimal)row[SalaryOut],
                    };
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SubdivisionVm> GetSubdivisions()
        {
            using (var con = new OracleConnection(_configurations.ConnectionString))
            {
                con.Open();
                var cmd = con.CreateCommand();

                cmd.CommandText = GetSubdivisionsCommandText;

                var dataTable = new DataTable();
                var dataAdapter = new OracleDataAdapter(cmd);

                dataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    yield return new SubdivisionVm
                    {
                        SubdivisionId = (int)(decimal)row[SubdivisionIdOut],
                        Name = (string)row[NameOut]
                    };
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PositionVm> GetPositions()
        {
            using (var con = new OracleConnection(_configurations.ConnectionString))
            {
                con.Open();
                var cmd = con.CreateCommand();

                cmd.CommandText = GetPositionsCommandText;

                var dataTable = new DataTable();
                var dataAdapter = new OracleDataAdapter(cmd);

                dataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    yield return new PositionVm
                    {
                        PositionId = (int)(decimal)row[PositionIdOut],
                        Name = (string)row[NameOut]
                    };
                };
            }
        }
    }
}
