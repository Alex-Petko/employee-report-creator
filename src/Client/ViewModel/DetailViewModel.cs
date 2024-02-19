using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace WpfTest.ViewModel
{
    /// <summary>
    /// Бизнес логика <see cref="DetailWindow"/>
    /// </summary>
    public class DetailViewModel : ViewModelBase
    {
        private readonly IQueryProvider _queryProvider;
        private readonly ICommandProvider _commandProvider;
        private EmployeeVm _employee;

        public ICommand SaveCommand { get; }

        public ICommand CancelCommand { get; }

        public string Name { get; set; }

        public List<SubdivisionVm> Subdivisions { get; set; }
        public SubdivisionVm SelectedSubdivision { get; set; }

        public List<PositionVm> Positions { get; set; }
        public PositionVm SelectedPosition { get; set; }

        public int Salary { get; set; }

        public DetailViewModel(IQueryProvider queryProvider, ICommandProvider commandProvider)
        {
            _queryProvider = queryProvider;
            _commandProvider = commandProvider;
            SaveCommand = new RelayCommand(OnSave);
            CancelCommand = new RelayCommand(OnCancel);
        }

        public void Load(EmployeeVm employee)
        {
            _employee = employee;

            Name = employee.Name;

            Subdivisions = _queryProvider.GetSubdivisions().ToList();
            SelectedSubdivision = Subdivisions.First(x => x.SubdivisionId == employee.SubdivisionId);

            Positions = _queryProvider.GetPositions().ToList();
            SelectedPosition = Positions.First(x => x.PositionId == employee.PositionId);

            Salary = employee.Salary;
        }

        private void OnSave()
        {
            var isNeedUpdate = false;

            if (Name != _employee.Name && !string.IsNullOrWhiteSpace(Name))
            {
                _employee.Name = Name;
                isNeedUpdate = true;
            }

            if (SelectedSubdivision.SubdivisionId != _employee.SubdivisionId)
            {
                _employee.SubdivisionId = SelectedSubdivision.SubdivisionId;
                isNeedUpdate = true;
            }

            if (SelectedPosition.PositionId != _employee.PositionId)
            {
                _employee.PositionId = SelectedPosition.PositionId;
                isNeedUpdate = true;
            }

            if (Salary != _employee.Salary)
            {
                _employee.Salary = Salary;
                isNeedUpdate = true;
            }

            if (isNeedUpdate)
            {
                _commandProvider.Update(_employee);
            }

            Messenger.Default.Send(new CloseMessage(isNeedUpdate));
        }

        private void OnCancel()
        {
            Messenger.Default.Send(new CloseMessage(false));
        }
    }
}