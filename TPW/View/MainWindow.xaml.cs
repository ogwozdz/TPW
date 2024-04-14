using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TPW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TextBlock block = new TextBlock();
            block.Text = "Programowanie współbieżne";
            block.HorizontalAlignment = HorizontalAlignment.Center;
            block.VerticalAlignment = VerticalAlignment.Center;
            block.FontSize = 30;
            block.FontFamily = new FontFamily("Century Gothic");
            block.Foreground = Brushes.Black;
            block.Background = Brushes.Pink;
            block.Padding = new Thickness(5, 10, 5, 10);
            this.Content = block;
            this.RegisterName("TextBlock1", block);
        }
    }
}