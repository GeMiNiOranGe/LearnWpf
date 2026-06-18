using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Data;

namespace Source;

/// <summary>
/// Interaction logic for ObservablePage.xaml
/// </summary>
public partial class ObservablePage : Page, INotifyPropertyChanged
{
    private string _dataValue;

    public ObservablePage()
    {
        InitializeComponent();

        _dataValue = "This is a message";

        DataContext = this;
    }

    public string DataValue
    {
        get => _dataValue;
        set
        {
            _dataValue = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    // use CallerMemberName to automatically get the property name of the caller
    protected void OnPropertyChanged(
        [CallerMemberName] string? propertyName = null
    )
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(propertyName)
        );
    }
}

public class AgeConverter : IValueConverter
{
    public object Convert(
        object value,
        Type targetType,
        object parameter,
        CultureInfo culture
    )
    {
        if (value is not DateTime selectedDateTime)
        {
            return Binding.DoNothing;
        }

        // Calculate age using Man Nenrei - age increases only on birthday
        // Or
        // Calculate age using the Western age system (age increases only on
        // birthday)
        int age = DateTime.Today.Year - selectedDateTime.Year;

        if (DateTime.Today < selectedDateTime.AddYears(age))
        {
            age--;
        }

        if (age < 0)
        {
            age = 0;
        }

        return age;
    }

    public object ConvertBack(
        object value,
        Type targetType,
        object parameter,
        CultureInfo culture
    )
    {
        throw new NotImplementedException();
    }
}
