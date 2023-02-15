using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using JSON_Lucas_Sanz.Model;

namespace JSON_Lucas_Sanz.Persistence;

public class JSONCostumer
{
    public string jsonfile = "Costumer.json";
    public int id { get; set; }
    public string name_costumer { get; set; }
    public int age { get; set; }

    public void CostumerToJson(Costumer c)
    {
        var costumertojson = new JSONCostumer
        {
            id = c.id,
            name_costumer = c.name_costumer,
            age = c.age
        };
        string stringcostumer = JsonSerializer.Serialize(costumertojson);
        File.WriteAllText(jsonfile, stringcostumer);
    }
    public Costumer ReadCostumerJson()
    {
        string readCostumer = File.ReadAllText(jsonfile);
        Costumer cr = JsonSerializer.Deserialize<Costumer>(readCostumer);
        return cr;
    }
}