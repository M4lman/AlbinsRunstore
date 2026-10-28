using System;

namespace Client.Models;

public record class OrderRestDb : Order
{
    public string _id { get; set; } = string.Empty;
}
