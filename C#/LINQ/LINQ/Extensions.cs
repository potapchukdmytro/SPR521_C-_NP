namespace LINQ
{
    public static class Extensions
    {
        public static void Print<T>(this IEnumerable<T> collection, bool endl = true)
        {
            foreach (var i in collection)
            {
                if(endl)
                {
                    Console.WriteLine(i);
                }
                else
                {
                    Console.Write(i + " ");
                }
            }

            if(!endl)
            {
                Console.WriteLine();
            }
        }
    }
}
