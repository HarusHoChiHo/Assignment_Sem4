using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Assignment3_ChiHoHo;

public class MenuItem : INotifyPropertyChanged
{
    public static readonly MenuItem EmptySelection = new()
                                                     {
                                                         Name =
                                                             "Select an item",
                                                         Category = "",
                                                         Price    = 0,
                                                         Quantity = 0
                                                     };

    private int     _quantity;
    public  string  Name     { get; set; }
    public  decimal Price    { get; set; }
    public  string  Category { get; set; }

    public int Quantity
    {
        get => _quantity;
        set
        {
            if (_quantity != value)
            {
                _quantity = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Total));
            }
        }
    }

    public decimal Total => Price * Quantity;

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
        {
            return false;
        }

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}