using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Source;

enum Gender
{
    Male,
    Female,
}

class User(string? fullName, int age, Gender gender, string? email)
{
    public string? FullName { get; set; } = fullName;

    public int Age { get; set; } = age;

    public Gender Gender { get; set; } = gender;

    public string AgeGroup => Age >= 18 ? "Adult" : "Minor";

    public string? Email { get; set; } = email;
}

/// <summary>
/// Interaction logic for ListViewPage.xaml
/// </summary>
public partial class ListViewPage : Page
{
    private const string DEFAULT_GROUP_STATUS_TEXT = "No grouping";
    private const string DEFAULT_SORT_STATUS_TEXT = "No sorting";

    public ListViewPage()
    {
        InitializeComponent();
        groupStatusTextBlock.Text = DEFAULT_GROUP_STATUS_TEXT;
        sortStatusTextBlock.Text = DEFAULT_SORT_STATUS_TEXT;

        List<User> users =
        [
            new User("Charlie Brown", 35, Gender.Male, "charlie@example.com"),
            new User("Alice Smith", 30, Gender.Female, "alice@example.com"),
            new User("David Wilson", 15, Gender.Male, "david@example.com"),
            new User("Frank Miller", 40, Gender.Male, "frank@example.com"),
            new User("Grace Lee", 28, Gender.Female, "grace@example.com"),
            new User("Bob Johnson", 25, Gender.Male, "bob@example.com"),
            new User("Eve Davis", 15, Gender.Female, "eve@example.com"),
        ];
        usersListView.ItemsSource = users;

        CollectionView view = (CollectionView)
            CollectionViewSource.GetDefaultView(usersListView.ItemsSource);
        view.Filter = IsShowUserByFullName;
    }

    private bool IsShowUserByFullName(object item)
    {
        if (!string.IsNullOrEmpty(filterByTextBox.Text))
        {
            string? str = ((User)item).FullName;
            return str != null
                && str.Contains(
                    filterByTextBox.Text,
                    StringComparison.OrdinalIgnoreCase
                );
        }

        return true;
    }

    private void FilterByTextBox_TextChanged(
        object sender,
        TextChangedEventArgs e
    )
    {
        CollectionViewSource
            .GetDefaultView(usersListView.ItemsSource)
            .Refresh();
    }

    private void GroupByComboBox_SelectionChanged(
        object sender,
        SelectionChangedEventArgs e
    )
    {
        if (sender is not ComboBox comboBox)
        {
            return;
        }

        if (comboBox.SelectedItem is not ComboBoxItem selectedItem)
        {
            return;
        }

        if (usersListView.ItemsSource is null)
        {
            return;
        }

        CollectionView view = (CollectionView)
            CollectionViewSource.GetDefaultView(usersListView.ItemsSource);

        view.GroupDescriptions.Clear();

        string? groupBy = selectedItem.Content.ToString();
        view.GroupDescriptions.Add(new PropertyGroupDescription(groupBy));
        groupStatusTextBlock.Text = $"Grouped by: {groupBy}";
    }

    private void ResetGroupButton_Click(object sender, RoutedEventArgs e)
    {
        if (usersListView.ItemsSource is null)
        {
            return;
        }

        CollectionView view = (CollectionView)
            CollectionViewSource.GetDefaultView(usersListView.ItemsSource);

        view.GroupDescriptions.Clear();

        groupByComboBox.SelectedIndex = -1;
        groupStatusTextBlock.Text = DEFAULT_GROUP_STATUS_TEXT;
    }

    private void GridViewColumnHeader_Click(object sender, RoutedEventArgs e)
    {
        if (sender is not GridViewColumnHeader header)
        {
            return;
        }

        CollectionView view = (CollectionView)
            CollectionViewSource.GetDefaultView(usersListView.ItemsSource);
        string sortBy = header.Tag.ToString()!;
        ListSortDirection direction = ListSortDirection.Ascending;

        if (view.SortDescriptions.Count > 0)
        {
            SortDescription currentSort = view.SortDescriptions[0];
            if (currentSort.PropertyName == sortBy)
            {
                direction =
                    currentSort.Direction == ListSortDirection.Ascending
                        ? ListSortDirection.Descending
                        : ListSortDirection.Ascending;
            }
            view.SortDescriptions.Clear();
        }

        view.SortDescriptions.Add(new SortDescription(sortBy, direction));
        sortStatusTextBlock.Text = $"Sorted by: {sortBy} ({direction})";
    }
}
