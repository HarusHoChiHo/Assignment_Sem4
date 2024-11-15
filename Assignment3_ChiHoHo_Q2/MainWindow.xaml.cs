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

namespace Assignment3_ChiHoHo_Q2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string username = "chihoho";
    private string password = "chihoho1234";
    
    public MainWindow()
    {
        InitializeComponent();
        
        Username.DataContext = this;
        Password.DataContext = this;

        Username.Text = username;
        Password.Text = password;
    }
}