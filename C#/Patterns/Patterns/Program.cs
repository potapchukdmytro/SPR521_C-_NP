using Patterns.AbstractFactory;
using Patterns.Adapter;

namespace Patterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Singleton патерн
            // Database database = Database.GetInstance();


            // Abstract Factory патерн
            // CreateFirniture(new VictorianFurniture());



            // Adapter патерн
            //var data = new Data();
            //var analyzeLibrary = new AnalyzeLibrary();
            //var adapter = new DataAdapter();
            //string json = adapter.XmlToJson(data.GetData());

            //Console.WriteLine(analyzeLibrary.AnalyzeData(json));


            List<int> res = new List<int>();
            res.GetEnumerator();

            Dictionary<int, int> dict = new Dictionary<int, int>();
            dict.GetEnumerator();
        }

        static void CreateFirniture(IFurniture furniture)
        {
            Console.WriteLine(furniture.CreateChair());
            Console.WriteLine(furniture.CreateChair());
            Console.WriteLine(furniture.CreateTable());
            Console.WriteLine(furniture.CreateSofa());
        }
    }
}
