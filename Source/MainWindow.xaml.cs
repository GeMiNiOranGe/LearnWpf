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
}
