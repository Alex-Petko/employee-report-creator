using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System.Windows.Controls;

namespace WpfTest
{
    public partial class DetailWindow : Window
    {
        private string SalaryTextBoxPrev;
        public DetailWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<CloseMessage>(this, OnCloseMessage);
            SalaryTextBoxPrev = SalaryTextBox.Text;
        }

        private void OnCloseMessage(CloseMessage msg)
        {
            Messenger.Default.Unregister<CloseMessage>(this, OnCloseMessage);

            DialogResult = msg.IsNeedReloadData;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs args)
        {
            int result = 0;
            if (string.IsNullOrWhiteSpace(SalaryTextBox.Text) || int.TryParse(SalaryTextBox.Text, out result))
                SalaryTextBox.Text = (result >= 0 ? result : -result).ToString();
            else 
                SalaryTextBox.Text = SalaryTextBoxPrev;

            SalaryTextBoxPrev = SalaryTextBox.Text;
        }
    }
}
