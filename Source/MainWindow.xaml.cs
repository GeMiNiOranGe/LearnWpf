using System.Windows;

namespace Source;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void MessageButton_Click(object sender, RoutedEventArgs e)
    {
        mainFrame.Content = new MessagePage();
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        mainFrame.Content = new LoginPage();
    }

    private void BindingButton_Click(object sender, RoutedEventArgs e)
    {
        mainFrame.Content = new BindingPage();
    }

    private void BasicItemsControlButton_Click(object sender, RoutedEventArgs e)
    {
        mainFrame.Content = new BasicItemsControlPage();
    }

    private void ListViewButton_Click(object sender, RoutedEventArgs e)
    {
        mainFrame.Content = new ListViewPage();
    }
}
