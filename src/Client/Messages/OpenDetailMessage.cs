namespace WpfTest
{
    /// <summary>
    /// Сообщение открытия окна <see cref="DetailWindow"/>
    /// </summary>
    public class OpenDetailMessage
    {
        public EmployeeVm Employee { get; }

        public OpenDetailMessage(EmployeeVm employee)
        {
            Employee = employee;
        }
    }
}
