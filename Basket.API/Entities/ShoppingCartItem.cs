﻿namespace Basket.API.Entities;

public class ShoppingCartItem
{
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string ProductId { get; set; }
    public string Productname { get; set; }
}
