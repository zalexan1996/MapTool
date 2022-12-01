using MapTool.Core.Services;
using MapTool.Infrastructure;
using System.Threading;
using System.Windows;

namespace MapTool.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DatabaseManagementService _dbService;
        public MainWindow(DatabaseManagementService service)
        {
            InitializeComponent();
            _dbService = service;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await _dbService.CreateDatabase("Test", CancellationToken.None);
        }
    }
}
