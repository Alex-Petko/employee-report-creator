using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace WpfTest.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public DetailViewModel Detail => ServiceLocator.Current.GetInstance<DetailViewModel>();

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<DetailViewModel>();

            SimpleIoc.Default.Register<ICommandProvider , OracleCommandProvider>();
            SimpleIoc.Default.Register<IQueryProvider, OracleQueryProvider>();
            SimpleIoc.Default.Register<IPrintProvider, ExcelPrintProvider>();

            SimpleIoc.Default.Register<IConfigurations, Configurations>();
        }
    }
}