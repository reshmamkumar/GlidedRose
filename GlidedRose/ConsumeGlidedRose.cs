using GlidedRose.BusinessLogic;
using GlidedRose.Models;
using Newtonsoft.Json;

namespace GlidedRose
{
    internal class ConsumeGlidedRose
    {
        static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");
            IList<Item> items = new List<Item>();
            using (StreamReader r = new StreamReader("assets/items.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<IList<Item>>(json);
            }
            var app = new GlidedRoseLogic(items);
            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < items.Count; j++)
                {
                    System.Console.WriteLine(items[j]);
                }
                Console.WriteLine("");
                app.UpdateQuality();
                Console.ReadLine();
            }
        }
    }
}