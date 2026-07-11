namespace GarbageCollector
{
    internal class Program
    {
        int value = 10;

        static void GenerateString()
        {
            List<string> strings = new List<string>();

            for (int i = 0; i < 5000; i++)
            {
                var rnd = new Random();

                int wordLength = rnd.Next(5, 16); // Довжина слова від 5 до 15 символів

                string word = "";
                for (int j = 0; j < wordLength; j++)
                {
                    word += (char)rnd.Next(97, 123); // 97 - 122 - це діапазон кодів для малих літер англійського алфавіту (від 'a' до 'z')
                }

                strings.Add(word);
            }

            Console.WriteLine("Without collect: " + GC.GetTotalMemory(false));
            Console.WriteLine("Gen: " + GC.GetGeneration(strings)); // Виводимо покоління об'єкта strings
            GC.Collect(0);
            Console.WriteLine("Gen: " + GC.GetGeneration(strings));

            foreach (var item in strings)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Gen: " + GC.GetGeneration(strings));
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Without collect: " + GC.GetTotalMemory(false));
            Console.WriteLine("With collect: " + GC.GetTotalMemory(true));
            // Розмір в пам'яті нашої програми
            // Аргументом приймається булеве значення, яке вказує, чи потрібно виконати повний збір сміття перед визначенням розміру пам'яті.
            // Якщо передати true, то буде виконано повний збір сміття, що може зайняти деякий час.
            // Якщо передати false, то буде визначено розмір пам'яті без виконання повного збору сміття.
            //long memory = GC.GetTotalMemory(false);
            //Console.WriteLine(memory);

            //GC.Collect(); // Викликаємо збір сміття усіх поколінь (аргументом можна вказати конкретне покоління для збору)


            //GenerateString();


            //GC.Collect(0);
            //GC.Collect(1);
            //Console.WriteLine("Without collect: " + GC.GetTotalMemory(false));
            //Console.WriteLine("With collect: " + GC.GetTotalMemory(true));




            List<MyValue> myValues = new List<MyValue>(1000000);

            for (int i = 0; i < myValues.Count; i++)
            {
                myValues[i] = new MyValue(i);
            }

            Console.WriteLine("Without collect: " + GC.GetTotalMemory(true));
        }
    }
}
