using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;

namespace JSON_Lucas_Sanz.Model;
/// <summary>
/// Product object class with name and price parameters
/// </summary>
public class Product
{
    public string name_product { get; set; }
    public int price { get; set; }
    /// <summary>
    /// Product constructor
    /// </summary>
    /// <param name="name_product">Product name</param>
    /// <param name="price">Product price</param>
    public Product(string name_product, int price)
    {
        this.name_product = name_product;
        this.price = price;
    }
}