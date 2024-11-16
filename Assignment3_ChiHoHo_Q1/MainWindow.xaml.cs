using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Assignment3_ChiHoHo;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        InitializeMenuItems();
        DataContext = this;

        BeverageComboBox.SelectionChanged   += ComboBox_SelectionChanged;
        AppetizerComboBox.SelectionChanged  += ComboBox_SelectionChanged;
        MainCourseComboBox.SelectionChanged += ComboBox_SelectionChanged;
        DessertComboBox.SelectionChanged    += ComboBox_SelectionChanged;

        BeverageQuantity.TextChanged   += TextBox_TextChanged;
        AppetizerQuantity.TextChanged  += TextBox_TextChanged;
        MainCourseQuantity.TextChanged += TextBox_TextChanged;
        DessertQuantity.TextChanged    += TextBox_TextChanged;

        ClearBillButton.Click += ClearBillButton_Click;
        GenerateInvoiceButton.Click += GenerateInvoiceButton_Click;
        
    }

    public ObservableCollection<MenuItem> BillItems { get; set; }

    private void InitializeMenuItems()
    {
        List<MenuItem> menuItems = LoadCSV();

        BeverageComboBox.ItemsSource = new ObservableCollection<MenuItem>(
                                                                          menuItems
                                                                              .Where(i => i.Category == "Beverage")
                                                                              .Prepend(MenuItem.EmptySelection));
        AppetizerComboBox.ItemsSource = new ObservableCollection<MenuItem>(
                                                                           menuItems
                                                                               .Where(i => i.Category == "Appetizer")
                                                                               .Prepend(MenuItem.EmptySelection));
        MainCourseComboBox.ItemsSource = new ObservableCollection<MenuItem>(
                                                                            menuItems
                                                                                .Where(i => i.Category == "MainCourse")
                                                                                .Prepend(MenuItem.EmptySelection));
        DessertComboBox.ItemsSource = new ObservableCollection<MenuItem>(
                                                                         menuItems
                                                                             .Where(i => i.Category == "Dessert")
                                                                             .Prepend(MenuItem.EmptySelection));

        BeverageComboBox.SelectedItem   = MenuItem.EmptySelection;
        AppetizerComboBox.SelectedItem  = MenuItem.EmptySelection;
        MainCourseComboBox.SelectedItem = MenuItem.EmptySelection;
        DessertComboBox.SelectedItem    = MenuItem.EmptySelection;
        BillItems                       = new ObservableCollection<MenuItem>();
        //BillDataGrid.ItemsSource        = BillItems;
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var comboBox = sender as ComboBox;
        if (comboBox.SelectedItem is MenuItem selectedItem)
        {
            var quantityTextBox = GetAssociatedQuantityTextBox(comboBox);

            if (selectedItem.Name.Equals("Select an item"))
            {
                quantityTextBox.IsEnabled = false;
                return;
            }

            quantityTextBox.IsEnabled = true;

            if (int.TryParse(quantityTextBox.Text, out var quantity))
            {
                if (quantity != 1)
                {
                    quantityTextBox.Text = "1";
                }
                else
                {
                    UpdateBillItem(selectedItem, quantity);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid quantity.");
                quantityTextBox.Text = "1";
            }
        }
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        var textBox = sender as TextBox;

        if (string.IsNullOrEmpty(textBox.Text))
        {
            return;
        }

        var comboBox = GetAssociatedCombotBox(textBox);

        if (comboBox.Name.Equals("Select an item"))
        {
            return;
        }

        if (int.TryParse(textBox.Text, out var quantity))
        {
            if (comboBox.SelectedItem is MenuItem selectedItem)
            {
                if (quantity == 0)
                {
                    BillItems.Remove(BillItems.First(item => item.Name == selectedItem.Name));
                }
                else
                {
                    UpdateBillItem(selectedItem, quantity);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid quantity.");
                textBox.Text = "1";
            }
        }
        else
        {
            MessageBox.Show("Please enter a valid quantity.");
        }
    }

    private void ClearItemButton_Click(object sender, RoutedEventArgs e)
    {
        if (BillDataGrid.SelectedItem is MenuItem menuItem)
        {
            BillItems.Remove(BillItems.First(item => item.Name == menuItem.Name));
            UpdateBillTotals();
        }
    }

    private void GenerateInvoiceButton_Click(object sender, RoutedEventArgs e)
    {
        StringBuilder invoice = new StringBuilder();
        int           count   = 1;
        foreach (MenuItem item in BillItems)
        {
            invoice.Append($"{count.ToString()}. " + item.ToString() + Environment.NewLine + Environment.NewLine);
            count++;
        }

        invoice.Append("     Tax:         +13%" + Environment.NewLine + Environment.NewLine);
        invoice.Append($"     Total:      {(BillItems.Sum(item => item.Total) * 1.13m).ToString("C")}");
        
        MessageBox.Show(invoice.ToString(), "Invoice");
    }
    
    private TextBox GetAssociatedQuantityTextBox(ComboBox comboBox)
    {
        switch (comboBox.Name)
        {
            case "BeverageComboBox":
                return BeverageQuantity;
            case "AppetizerComboBox":
                return AppetizerQuantity;
            case "MainCourseComboBox":
                return MainCourseQuantity;
            case "DessertComboBox":
                return DessertQuantity;
            default:
                return null;
        }
    }

    private ComboBox GetAssociatedCombotBox(TextBox textBox)
    {
        switch (textBox.Name)
        {
            case "BeverageQuantity":
                return BeverageComboBox;
            case "AppetizerQuantity":
                return AppetizerComboBox;
            case "MainCourseQuantity":
                return MainCourseComboBox;
            case "DessertQuantity":
                return DessertComboBox;
            default:
                return null;
        }
    }

    private void UpdateBillItem(MenuItem selectedItem, int quantity)
    {
        var existingItem = BillItems.FirstOrDefault(
                                                    item =>
                                                        item.Name     == selectedItem.Name
                                                     && item.Category == selectedItem.Category);

        if (existingItem != null)
        {
            // Update existing item
            existingItem.Quantity = quantity;
        }
        else
        {
            // Add new item
            var newItem = new MenuItem
                          {
                              Name     = selectedItem.Name,
                              Category = selectedItem.Category,
                              Price    = selectedItem.Price,
                              Quantity = quantity
                          };
            BillItems.Add(newItem);
        }

        UpdateBillTotals();
    }

    private void UpdateBillTotals()
    {
        var subtotal = BillItems.Sum(i => i.Total);
        var tax      = subtotal * 0.13m; // Assuming 13% tax rate
        var total    = subtotal + tax;

        SubtotalTextBox.Text = subtotal.ToString("C");
        TaxTextBox.Text      = tax.ToString("C");
        TotalTextBox.Text    = total.ToString("C");
    }

    private void ClearBillButton_Click(object sender, RoutedEventArgs e)
    {
        
        BeverageComboBox.SelectedIndex   = 0;
        AppetizerComboBox.SelectedIndex  = 0;
        MainCourseComboBox.SelectedIndex = 0;
        DessertComboBox.SelectedIndex    = 0;
        
        BeverageQuantity.Text   = "1";
        AppetizerQuantity.Text  = "1";
        MainCourseQuantity.Text = "1";
        DessertQuantity.Text    = "1";
        BillItems.Clear();
        UpdateBillTotals();
        // SubtotalTextBox.Text = "$0.00";
        // TaxTextBox.Text      = "$0.00";
        // TotalTextBox.Text    = "$0.00";
    }

    private List<MenuItem> LoadCSV()
    {
        List<MenuItem> menuItems = new();
        try
        {
            string[] lines = File.ReadAllLines("../../../MenuItem.csv");

            for (var i = 1; i < lines.Length; i++)
            {
                var line = lines[i]
                    .Trim();
                if (!string.IsNullOrEmpty(line))
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        var item = new MenuItem
                                   {
                                       Name = parts[0]
                                           .Trim(),
                                       Category = parts[1]
                                           .Trim(),
                                       Price = decimal.Parse(
                                                             parts[2]
                                                                 .Trim()
                                                                 .TrimStart('$')),
                                       Quantity = 0
                                   };
                        menuItems.Add(item);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading menu items: {ex.Message}");
        }

        return menuItems;
    }
}