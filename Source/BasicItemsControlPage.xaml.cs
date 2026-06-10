using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Source;

/// <summary>
/// Interaction logic for BasicItemsControlPage.xaml
/// </summary>
public partial class BasicItemsControlPage : Page
{
    public BasicItemsControlPage()
    {
        InitializeComponent();
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        colorsComboBox.ItemsSource = typeof(Colors).GetProperties();
    }
}
