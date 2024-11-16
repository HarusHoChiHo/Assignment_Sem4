using System.Windows;
using System.Windows.Controls;

namespace Assignment3_ChiHoHo_Q2;

public partial class LoginUserControl : UserControl
{
    public static readonly DependencyProperty UsernameProperty =
        DependencyProperty.Register("Username", typeof(string), typeof(LoginUserControl), new PropertyMetadata(""));

    public static readonly DependencyProperty PasswordProperty =
        DependencyProperty.Register("Password", typeof(string), typeof(LoginUserControl), new PropertyMetadata(""));

    public String Username
    {
        get => (String)GetValue(UsernameProperty);
        set => SetValue(UsernameProperty, value);
    }

    public String Password
    {
        get => (String)GetValue(PasswordProperty);
        set => SetValue(PasswordProperty, value);
    }

    public LoginUserControl()
    {
        DataContext = this;
        InitializeComponent();
    }
}