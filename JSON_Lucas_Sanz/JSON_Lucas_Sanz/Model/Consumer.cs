using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using JSON_Lucas_Sanz.Persistence;

namespace JSON_Lucas_Sanz.Model;
/// <summary>
/// Consumer object class with id, name and age parameters, also is created an empty list of products
/// </summary>
public class Consumer
{
    public int id { get; set; }
    public string name_consumer { get; set; }
    public int age { get; set; }
    public List<Product> productos_cliente { get; set; }
    public JSONConsumer jc;
    /// <summary>
    /// Empty consumer contructor, only persistence manager created
    /// </summary>
    public Consumer()
    {
        this.jc = new JSONConsumer();
    }
    /// <summary>
    /// Full consumer constructor, persistence manager and empty product list created
    /// </summary>
    /// <param name="id">Consumer id</param>
    /// <param name="name_consumer">Consumer name</param>
    /// <param name="age">Consumer age</param>
    public Consumer(int id, string name_consumer, int age)
    {
        this.id = id;
        this.name_consumer = name_consumer;
        this.age = age;
        this.productos_cliente = new List<Product>();
        this.jc = new JSONConsumer();
    }
    /// <summary>
    /// Method to call serializer method in persistence manager
    /// </summary>
    public void ConsumerJson()
    {
        jc.ConsumerSerialize(this);
    }
}