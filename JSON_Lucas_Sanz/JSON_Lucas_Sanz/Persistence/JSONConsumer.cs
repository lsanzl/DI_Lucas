using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Xps.Serialization;
using JSON_Lucas_Sanz.Model;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace JSON_Lucas_Sanz.Persistence;
/// <summary>
/// Persistence manager of Consumer object class
/// </summary>
public class JSONConsumer
{
    public string jsonfile = "Consumer.json";
    public int id { get; set; }
    public string name_consumer { get; set; }
    public int age { get; set; }
    public List<Product> productos_cliente;
    public string name_product;
    public int price;
    public StreamWriter w;
    public StreamReader r;
    /// <summary>
    /// Method to serialize (Json format) a Consumer object and add it to Json file
    /// </summary>
    /// <param name="c">Consumer object to serialize</param>
    public void ConsumerSerialize(Consumer c)
    {
        string stringconsumer = JsonSerializer.Serialize(c);
        StreamWriter w = File.AppendText(jsonfile);
        w.Write(stringconsumer);
        w.Write("\n");
        w.Close();
    }
    /// <summary>
    /// Method to read Json file and create a Consumer list
    /// </summary>
    /// <returns>Consumer list from Json file</returns>
    public List<Consumer> ReadConsumerJson()
    {
        List<Consumer> list_consumers = new List<Consumer>();

        foreach (string line in System.IO.File.ReadLines(jsonfile))
        {
            if (line.Length != 0)
            {
                Consumer c = JsonSerializer.Deserialize<Consumer>(line);
                list_consumers.Add(c);
            }
        }
        return list_consumers;
    }
}