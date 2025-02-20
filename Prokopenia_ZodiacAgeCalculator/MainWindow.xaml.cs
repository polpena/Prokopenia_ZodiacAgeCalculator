using System.Windows;
using Prokopenia_ZodiacAgeCalculator.ViewModels;

namespace Prokopenia_ZodiacAgeCalculator.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}


