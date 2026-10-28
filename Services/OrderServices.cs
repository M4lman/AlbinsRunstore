using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;

namespace Client.Services;

public class OrderServices : IOrderService
{
    public async Task<List<Order>> List()
    {
        HttpService<Order> httpService = new();
        var orders = await httpService.Get("orders");
        return orders;
    }
}
