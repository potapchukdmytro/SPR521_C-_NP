namespace Patterns.Prototype
{
    public class Game
    {
        private Tree tree;

        public Game()
        {
            tree = new Tree("Oak", "Bark", 10);
        }

        public void CopyTree()
        {
            var newTree = tree.Clone();
        }
    }
}
