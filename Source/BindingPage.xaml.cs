using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Source;

/// <summary>
/// Interaction logic for BindingPage.xaml
/// </summary>
public partial class BindingPage : Page
{
    public BindingPage()
    {
        InitializeComponent();
        Loaded += BindingPage_Loaded;
    }

    private void BindingPage_Loaded(object sender, RoutedEventArgs e)
    {
        Window? window = Window.GetWindow(this);
        if (window is null)
        {
            return;
        }

        windowWidthTextBox.SetBinding(
            TextBox.TextProperty,
            new Binding(nameof(Width)) { Source = window }
        );

        windowHeightTextBox.SetBinding(
            TextBox.TextProperty,
            new Binding(nameof(Height)) { Source = window }
        );
    }
}
