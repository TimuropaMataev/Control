using Control.Data;
using Control.Objects;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace Control;

public partial class MainWindow : Window
{
    ApplicationContext context = new();

    public MainWindow()
    {
        InitializeComponent();
        Loaded += MainWindow_Loaded;
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        context.Database.EnsureCreated();
        context.Users.Load();

        DataContext = context.Users.Local.ToObservableCollection();
    }

    private void AddClick(object sender, RoutedEventArgs e)
    {
        UserWindow window = new(new User());

        if (window.ShowDialog() == true)
        {
            User user = window.User;
            context.Users.Add(user);
            context.SaveChanges();
        }
    }

    private void ChangeClick(object sender, RoutedEventArgs e)
    {
        User? user = LB1.SelectedItem as User;

        if (user is null) return;

        UserWindow window = new(new User
        {
            Name = user.Name,
            Age = user.Age,
            Id = user.Id
        });

        if (window.ShowDialog() == true)
        {
            user = context.Users.Find(window.User.Id);

            if (user != null)
            {
                user.Name = window.User.Name;
                user.Age = window.User.Age;
                context.SaveChanges();
                LB1.Items.Refresh();
            }
        }
    }

    private void DeleteClick(object sender, RoutedEventArgs e)
    {
        User? user = LB1.SelectedItems as User;

        if (user is null) return;

        context.Users.Remove(user);
        context.SaveChanges();
    }

    private void MenuItem_Click(object sender, RoutedEventArgs e) => Close();

    private void MenuItem_Click_1(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Дизайн: Тимур Матаев\nРазработка: Тимур Матаев\n\n\n" +
            "Выпуск: 06.06.2024");
    }
}