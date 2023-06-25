using GlidedRose.Domain.BusinessLogic.Factory;
using GlidedRose.Domain.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

public class App
{
    private readonly IUpdateItemPolicy UpdateItemPolicy;

    public App(IUpdateItemPolicy updateItemPolicy)
    {
        UpdateItemPolicy = updateItemPolicy;
    }


    public void Run(string[] args)
    {
        IList<Item>? items = new List<Item>();
        string json = string.Empty;
        using (StreamReader r = new StreamReader("Assets/items.json"))
        {
            json = r.ReadToEnd();
            if(json!= null) 
            items = JsonConvert.DeserializeObject<IList<Item>>(json);
            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");

                foreach (var item in items)
                {
                    System.Console.WriteLine(item.Name + " : " + item.Quality.ToString());
                    var policy = UpdateItemPolicy.Create(item);
                    policy.UpdateItem(item);
                }
                Console.WriteLine("");
                Console.ReadLine();
            }
        }
    }
}