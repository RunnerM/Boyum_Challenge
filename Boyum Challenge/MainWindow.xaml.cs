
using System.Windows;

using Boyum_Challenge.ViewModel;
using Microsoft.Win32;

namespace Boyum_Challenge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _model = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnBrowseBtn(object sender, RoutedEventArgs e)
        {
           OpenFileDialog dialog = new OpenFileDialog();
           if (dialog.ShowDialog()==true)
           {
               TbFileName.Text = dialog.FileName;
               _model.FileName = dialog.FileName;
           }
        }

        
        private void OnProcessBtn(object sender, RoutedEventArgs e)
        {
            _model.ProcessFile();
            // This should be done via data binding.  
            IdLabel.Content = _model.Order().Id;
            CustomerLabel.Content = _model.Order().Customer;
            DateLabel.Content = MainViewModel.FormatDate( _model.Order().Date);
            PriceAvgLabel.Content = MainViewModel.FormatDouble(_model.Order().AveragePrice());
            TotalLabel.Content = MainViewModel.FormatDouble(_model.Order().TotalPrice());
        }
    }
}