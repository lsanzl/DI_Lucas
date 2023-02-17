using System.Collections.Generic;
using System.IO;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Xps.Serialization;
using JSON_Lucas_Sanz.Model;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace JSON_Lucas_Sanz.Persistence;

public class JSONConsumer
{
    public string jsonfile = "Consumer.json";
    public int id { get; set; }
    public string name_consumer { get; set; }
    public int age { get; set; }
    public StreamWriter w;
    public StreamReader r;

    public void ConsumerToJson(Consumer c)
    {
        StreamWriter w = File.AppendText(jsonfile);
        var consumertojson = new JSONConsumer
        {
            id = c.id,
            name_consumer = c.name_consumer,
            age = c.age
        };
        string stringconsumer = JsonSerializer.Serialize(consumertojson);
        w.Write(stringconsumer);
        w.Write("\n");
        w.Close();
    }
    public List<Consumer> ReadConsumerJson()
    {
        List<Consumer> list_consumers = new List<Consumer>();

        foreach (string line in System.IO.File.ReadLines(jsonfile))
        {
            if (!line.Equals(""))
            {
                Consumer c = JsonSerializer.Deserialize<Consumer>(line);
                list_consumers.Add(c);
            }
        }
        return list_consumers;
    }
}