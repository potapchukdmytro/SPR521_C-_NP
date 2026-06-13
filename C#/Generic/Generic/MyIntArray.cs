using System.Collections;

namespace Generic
{
    public class MyArrayEnumerator<T> : IEnumerator<T>
    {
        public T Current => throw new NotImplementedException();

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

    public class MyArray<T> : IEnumerable
    {
        private T[] arr = new T[0];

        public void Add(T value)
        {
            var newArr = new T[arr.Length + 1];
            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }
            newArr[^1] = value;
            arr = newArr;
        }

        public IEnumerator GetEnumerator()
        {
            return arr.GetEnumerator();
        }

        public void Print()
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
