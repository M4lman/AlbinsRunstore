using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Interfaces;

public interface IOrderService
{
    Task<List<Order>> List();
}
