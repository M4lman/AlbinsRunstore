using System;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Client.ViewModels;

public partial class AddOrderViewModel : ViewModelBase
{
    private readonly IOrderService _orderService;

    [ObservableProperty]
    public partial string ItemNumber { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string ProductName { get; set; } = string.Empty;
    [ObservableProperty]
    public partial string Supplier { get; set; } = string.Empty;
    [ObservableProperty]
    public partial int Price { get; set; }

    // Endast för design och preview hantering
    /* Ta bort när allt fungerar!!! */
    // TODO: Ta bort när allt fungerar...
    public AddOrderViewModel()
    {
        _orderService = new OrderServices();
        PageTitle = "Ny Produkt";
    }
    /*********************************************/

    public AddOrderViewModel(IOrderService orderService)
    {
        _orderService = orderService;
        PageTitle = "Ny Produkt";
    }

    [RelayCommand]
    private async Task Save()
    {
        // Behöver eventuellt göra validering här...
        Product product = new()
        {
            ItemNumber = ItemNumber,
            Name = ProductName,
            SupplierName = Supplier,
            ImageUrl = "https://res.cloudinary.com/softtech-dev/image/upload/v1773483409/no-image_ymlpwk.png",
            Description = "Ny Produkt",
            Price = Price
        };

       // await _orderService.Add(order);

        ClearData();
    }

    private void ClearData()
    {
        ItemNumber = string.Empty;
        ProductName = string.Empty;
        Supplier = string.Empty;
        Price = 0;
    }
}
