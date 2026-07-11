namespace Patterns.Prototype
{
    public class Tree : ICloneable
    {
        private string model;
        private string texture;

        public int Size { get; set; }

        public Tree(string model, string texture, int size)
        {
            Size = size;
            this.model = model;
            this.texture = texture;
        }

        public object Clone()
        {
            var newTree = new Tree(model, texture, Size);
            return newTree;
        }

        //public Tree Clone()
        //{
        //    var newTree = new Tree(model, texture, Size);
        //    return newTree;
        //}
    }
}
