using System;
using System.IO;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;

namespace JSON_Lucas_Sanz.Model;

public class Costumer
{
    public static string fileNameCostumer = Environment.CurrentDirectory + "\\costumer.json";
    public int id { get; set; }
    public string name_costumer { get; set; }
    public int age { get; set; }
    
    public Costumer(int id, string name_costumer, int age)
    {
        this.id = id;
        this.name_costumer = name_costumer;
        this.age = age;
    }
    public Costumer readCostumer()
    {
        if (File.Exists(fileNameCostumer))
        {
            string costumer_read = File.ReadAllText(fileNameCostumer);
            Costumer cread = JsonSerializer.Deserialize<Costumer>(costumer_read);
            return cread;
        }
        MessageBox.Show("No existe el archivo");
        Costumer c = new Costumer(-1, "fallo", 0);
        return c;
    }
}