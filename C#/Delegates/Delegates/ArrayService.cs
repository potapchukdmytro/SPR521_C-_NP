namespace Delegates
{
    public delegate bool FindDelegate(int element);
    public delegate bool ComparatorDelegate(int a, int b);

    public class ArrayService
    {
        private int[] arr;

        public ArrayService(int[] arr)
        {
            this.arr = arr;
        }

        public int Find(FindDelegate predicate)
        {
            foreach (var item in arr)
            {
                if(predicate(item))
                {
                    return item;
                }
            }

            return -1;
        }

        public int Find(ComparatorDelegate compare)
        {
            int res = arr[0];

            foreach (var item in arr)
            {
                if (compare(item, res))
                {
                    res = item;
                }
            }

            return res;
        }
    }
}
