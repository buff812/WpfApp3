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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as FrameworkElement).Style = (Style)Resources["LargeTextBoxStyle"];
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            (sender as FrameworkElement).Style = (Style)Resources["SmallTextBoxStyle"];
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is not TextBox)
            {
                foreach (var child in LogicalTreeHelper.GetChildren((DependencyObject)sender))
                {
                    if (child is StackPanel stackPanel)
                    {
                        foreach (var stackChild in stackPanel.Children)
                        {
                            if (stackChild is TextBox textBox)
                            {
                                textBox.Style = (Style)Resources["SmallTextBoxStyle"];
                            }
                        }
                    }
                }
            }
        }
    }
}
    
