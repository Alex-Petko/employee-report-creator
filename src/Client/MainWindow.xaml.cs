using CommonServiceLocator;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System.Windows.Controls;
using WpfTest.ViewModel;

namespace WpfTest
{
    public partial class MainWindow : Window
    {
        private readonly Control _mainContent;
        private readonly DockPanel _dockPanel;
        private readonly Loading _loading;

        public MainWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<OpenDetailMessage>(this, OnOpenDetailMessage);
            Messenger.Default.Register<StartLoagingMessage>(this, OnStartLoagingMessage);
            Messenger.Default.Register<FinishLoadingMessage>(this, OnFinishLoagingMessage);

            _mainContent = (Control)FindName("Main");
            _dockPanel = (DockPanel)FindName("DockPanel");
            _loading = new Loading();
        }

        private void OnOpenDetailMessage(OpenDetailMessage msg)
        {
            var window = new DetailWindow();
            var model = ServiceLocator.Current.GetInstance<DetailViewModel>();

            window.DataContext = model;
            model.Load(msg.Employee);

            window.ShowDialog();
        }

        private void OnStartLoagingMessage(StartLoagingMessage msg)
        {
            _dockPanel.Children.Remove(_mainContent);
            _dockPanel.Children.Add(_loading);
        }

        private void OnFinishLoagingMessage(FinishLoadingMessage msg)
        {
            _dockPanel.Children.Remove(_loading);
            _dockPanel.Children.Add(_mainContent);
        }
    }
}
