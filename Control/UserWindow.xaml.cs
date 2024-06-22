using Control.Objects;
using System.Windows;

namespace Control;

public partial class UserWindow : Window
{
    public User User { get; private set; }

    public UserWindow(User user)
    {
        InitializeComponent();
        User = user;
        DataContext = User;
    }

    private void Button_Click(object sender, RoutedEventArgs e) =>
        DialogResult = true;
}