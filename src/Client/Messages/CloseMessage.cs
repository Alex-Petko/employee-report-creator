namespace WpfTest
{
    /// <summary>
    /// Сообщение закрытия окна
    /// </summary>
    public class CloseMessage
    {
        public bool IsNeedReloadData { get; set; }

        public CloseMessage(bool isNeedReloadData)
        {
            IsNeedReloadData = isNeedReloadData;
        }
    }
}
