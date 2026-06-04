using System.Windows;
using System.Windows.Controls;

namespace Source;

/// <summary>
/// Interaction logic for ButtonPage.xaml
/// </summary>
public partial class LoginPage : Page
{
    public LoginPage()
    {
        InitializeComponent();

        Button otherButton = new() { Content = "Other content" };
        otherButton.Click += Button_Click;
        mainStackPanel.Children.Add(otherButton);
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        string username = usernameTextBox.Text;
        string password = passwordBox.Password;

        if (
            string.IsNullOrWhiteSpace(username)
            || string.IsNullOrWhiteSpace(password)
        )
        {
            return;
        }

        MessageBox.Show(
            $"""
            Username: {username}
            Password: {password}
            """
        );
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Clicked");
    }
}
