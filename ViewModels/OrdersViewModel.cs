using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Client.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Client.ViewModels;

public partial class OrdersViewModel : ViewModelBase
{
    private readonly IOrderService _orderService;

    [ObservableProperty]
    public partial ObservableCollection<Order> Orders { get; set; } = [];

    public OrdersViewModel()
    {
        _orderService = new OrderServices();
        PageTitle = "Beställnings Lista";
        Init();
    }

    public OrdersViewModel(IOrderService orderService)
    {
        _orderService = orderService;
        PageTitle = "Beställnings Lista";
        Init();
    }

    private async void Init()
    {
        await LoadOrders();
    }

    private async Task LoadOrders()
    {
        try
        {
            var orders = await _orderService.List();
            Orders = new ObservableCollection<Order>(orders);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
