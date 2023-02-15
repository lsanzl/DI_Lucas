using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;

namespace JSON_Lucas_Sanz.Model;

public class Product
{
    public static string fileNameProduct = Environment.CurrentDirectory + "\\product.json";
    public string name_product { get; set; }
    public int price { get; set; }
    
    public Product(string name_product, int price)
    {
        this.name_product = name_product;
        this.price = price;
    }
    public void ProductJson()
    {
        string product_json = JsonSerializer.Serialize(this);
        File.WriteAllText(fileNameProduct, product_json);
    }
    public void readProduct()
    {
        if (File.Exists(fileNameProduct))
        {
            string product_read = File.ReadAllText(fileNameProduct);
        }
        else
        {
            MessageBox.Show("No existe el fichero");
        }
    }
}