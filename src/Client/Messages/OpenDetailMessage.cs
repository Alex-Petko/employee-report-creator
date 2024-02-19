namespace WpfTest
{
    /// <summary>
    /// Сообщение открытия окна <see cref="DetailWindow"/>
    /// </summary>
    public class OpenDetailMessage
    {
        public EmployeeVm Employee { get; }

        /// <summary>
        /// Результат обработки сообщения
        /// </summary>
        public bool IsNeedReloadDataOut { get; set; }

        public OpenDetailMessage(EmployeeVm employee)
        {
            Employee = employee;
        }
    }
}
