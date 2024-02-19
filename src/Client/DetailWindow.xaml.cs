using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace WpfTest
{
    public partial class DetailWindow : Window
    {
        public DetailWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<CloseMessage>(this, OnCloseMessage);
        }

        private void OnCloseMessage(CloseMessage msg)
        {
            Messenger.Default.Unregister<CloseMessage>(this, OnCloseMessage);
            DialogResult = true;
        }
    }
}
