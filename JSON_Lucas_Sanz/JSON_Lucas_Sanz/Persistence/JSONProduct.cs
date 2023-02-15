using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using JSON_Lucas_Sanz.Model;

namespace JSON_Lucas_Sanz.Persistence;

public class JSONProduct
{
    public string jsonfile = "Product.json";
    public string name_product { get; set; }
    public int price { get; set; }

    public void ProductToJson(Product p)
    {
        var producttojson = new JSONProduct
        {
            name_product = p.name_product,
            price = p.price
        };
        string stringproduct = JsonSerializer.Serialize(producttojson);
        File.WriteAllText(jsonfile, stringproduct);
    }
}