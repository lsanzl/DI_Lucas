using System;
using System.IO;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using JSON_Lucas_Sanz.Persistence;

namespace JSON_Lucas_Sanz.Model;

public class Consumer
{
    public static string fileNameCostumer = Environment.CurrentDirectory + "\\consumer.json";
    public int id { get; set; }
    public string name_consumer { get; set; }
    public int age { get; set; }
    public JSONConsumer jc;

    public Consumer()
    {
        this.jc = new JSONConsumer();
    }
    public Consumer(int id, string name_consumer, int age)
    {
        this.id = id;
        this.name_consumer = name_consumer;
        this.age = age;
        this.jc = new JSONConsumer();
    }

    public void ConsumerToJson()
    {
        jc.ConsumerToJson(this);
    }
}