using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Source;

public static class MyCommand
{
    public static readonly RoutedUICommand ShowMessageBox = new(
        "ShowMessageBox",
        "ShowMessageBox",
        typeof(MyCommand),
        [new KeyGesture(Key.M, ModifierKeys.Control | ModifierKeys.Shift)]
    );
}

/// <summary>
/// Interaction logic for CommandPage.xaml
/// </summary>
public partial class CommandPage : Page
{
    public CommandPage()
    {
        InitializeComponent();
    }

    private void NewCommand_CanExecute(
        object sender,
        CanExecuteRoutedEventArgs e
    )
    {
        e.CanExecute = true;
    }

    private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        MessageBox.Show("The new command was invoked");
    }

    private void ShowMessageBoxCommand_CanExecute(
        object sender,
        CanExecuteRoutedEventArgs e
    )
    {
        e.CanExecute = true;
    }

    private void ShowMessageBoxCommand_Executed(
        object sender,
        ExecutedRoutedEventArgs e
    )
    {
        MessageBox.Show("The ShowMessageBox command was invoked");
    }

    /*
    private void CutCommand_CanExecute(
        object sender,
        CanExecuteRoutedEventArgs e
    )
    {
        e.CanExecute =
            (editorTextBox1 != null) && editorTextBox1.SelectionLength > 0;
    }

    private void CutCommand_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        editorTextBox1.Cut();
    }

    private void CopyCommand_CanExecute(
        object sender,
        CanExecuteRoutedEventArgs e
    )
    {
        e.CanExecute =
            (editorTextBox1 != null) && editorTextBox1.SelectionLength > 0;
    }

    private void CopyCommand_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        editorTextBox1.Copy();
    }

    private void PasteCommand_CanExecute(
        object sender,
        CanExecuteRoutedEventArgs e
    )
    {
        e.CanExecute = Clipboard.ContainsText();
    }

    private void PasteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        editorTextBox1.Paste();
    }
    */
}
