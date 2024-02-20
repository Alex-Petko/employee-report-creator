using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace WpfTest.ViewModel
{
    /// <summary>
    /// Бизнес логика <see cref="MainWindow"/> 
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IQueryProvider _queryProvider;
        private readonly IPrintProvider _printProvider;

        public ICommand LoadCommand { get; }

        public ICommand PrintCommand { get; }

        public ICommand ExitCommand { get; }

        public ICommand DoubleClickCommand { get; }

        public string SearchText { get; set; }

        public string StatusBarLabel { get; set; }

        public IEnumerable<EmployeeVm> ItemsSource { get; set; }

        public EmployeeVm SelectedItem { get; set; }

        public bool IsGridEnable { get; set; } = true;

        public MainViewModel(
            ICommandProvider commandProvider,
            IQueryProvider queryProvider,
            IPrintProvider printProvider)
        {
            _queryProvider = queryProvider;
            _printProvider = printProvider;

            LoadCommand = new RelayCommand(OnLoad);
            PrintCommand = new RelayCommand(OnPrint);
            ExitCommand = new RelayCommand(OnExit);
            DoubleClickCommand = new RelayCommand(OnDoubleClick);

            UpdateStatusBarLabel();

            commandProvider.TryInit();
        }

        private void UpdateStatusBarLabel()
        {
            var count = ItemsSource?.Count() ?? 0;
            StatusBarLabel = count <= 0 ? "Записей нет" : $"Количество записей: {count}";
            RaisePropertyChanged(() => StatusBarLabel);
        }

        private void OnLoad()
        {
            IsGridEnable = false;
            RaisePropertyChanged(() => IsGridEnable);

            Messenger.Default.Send(new StartLoagingMessage());

            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += (sender, args) => 
            {
                ItemsSource = _queryProvider.GetEmployees(SearchText);

                // Имитация долгой загрузки
                Thread.Sleep(1000);
            };

            backgroundWorker.RunWorkerCompleted += (sender, args) => 
            {
                Messenger.Default.Send(new FinishLoadingMessage());

                RaisePropertyChanged(() => ItemsSource);
                UpdateStatusBarLabel();

                IsGridEnable = true;
                RaisePropertyChanged(() => IsGridEnable);
            };

            backgroundWorker.RunWorkerAsync();
        }

        private void OnPrint()
        {
            _printProvider.Print(ItemsSource.Select(x => new { x.Name, x.Subdivision, x.City, x.Position, x.Salary }));
        }

        private void OnExit()
        {
            Application.Current.Shutdown();
        }

        private void OnDoubleClick()
        {
            if (SelectedItem == null)
                return;

            var msg = new OpenDetailMessage(SelectedItem);

            Messenger.Default.Send(msg);

            if (msg.IsNeedReloadDataOut)
                OnLoad();

            SelectedItem = null;
        }
    }
}