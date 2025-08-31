using System.Diagnostics;
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

    private void MessageTextBlock_MouseDown(
        object sender,
        MouseButtonEventArgs e
    )
    {
        TextBlock textBlock = (TextBlock)sender;
        textBlock.Background = Brushes.LightGray;
    }

    private void MessageTextBlock_MouseUp(object sender, MouseButtonEventArgs e)
    {
        TextBlock textBlock = (TextBlock)sender;
        textBlock.Background = Brushes.Gray;
    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        messageTextBlock.Text = "I'm Mike";
    }

    private void Border_MouseUp(object sender, MouseButtonEventArgs e)
    {
        messageTextBlock.Text = "Hello world again!!!";
    }

    private void Hyperlink_RequestNavigate(
        object sender,
        RequestNavigateEventArgs e
    )
    {
        ProcessStartInfo psi = new()
        {
            FileName = e.Uri.AbsoluteUri,
            UseShellExecute = true,
        };
        Process.Start(psi);

        e.Handled = true;
    }
}
