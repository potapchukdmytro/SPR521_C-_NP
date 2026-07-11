namespace Patterns.AbstractFactory
{
    public interface IFurniture
    {
        public string CreateChair();
        public string CreateTable();
        public string CreateSofa();
    }

    public class ModernFurniture : IFurniture
    {
        public string CreateChair()
        {
            return "Modern chair created";
        }

        public string CreateSofa()
        {
            return "Modern sofa created";
        }

        public string CreateTable()
        {
            return "Modern table created";
        }
    }

    public class VictorianFurniture : IFurniture
    {
        public string CreateChair()
        {
            return "Victorian chair created";
        }

        public string CreateSofa()
        {
            return "Victorian sofa created";
        }

        public string CreateTable()
        {
            return "Victorian table created";
        }
    }
}
