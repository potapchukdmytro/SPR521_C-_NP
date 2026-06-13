using System.Collections; 

namespace Collections
{
    internal class Program
    {
        static void GenericStack()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(4);
            stack.Push(10);
            stack.Push(1431);
            stack.Push(12);

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }

            bool resPop = stack.TryPop(out int res);
            if(resPop)
            {
                Console.WriteLine(res);
            }

            stack.Clear(); // видалити всі елементи
            stack.TryPeek(out int respeek); // peek із вбудований try catch
        }

        static void GenericQueue()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(4);
            queue.Enqueue(10);
            queue.Enqueue(1431);
            queue.Enqueue(12);

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }

            bool resPop = queue.TryDequeue(out int res);
            if (resPop)
            {
                Console.WriteLine(res);
            }

            queue.Clear(); // видалити всі елементи
            queue.TryPeek(out int respeek); // peek із вбудований try catch
        }

        // Колекція на основі динамічного масиву
        public static void GenericList()
        {
            // List<int> list = new List<int>([1, 2, 3, 4, 5, 6, 7, 8]);
            List<int> list = new List<int>
            {
                1,2,3,4,5,6,7,8,9,23,45,6756,6,8,123,653
            };

            list.Add(1); // додати елемент у кінець
            Console.WriteLine(list.Count); // к-сть елементів
            list.AddRange([100,200,300,400,500]); // додати елементи з іншої колекції

            // Є індекси
            Console.WriteLine(list[0]);
            list[0] = 555;

            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            // list.Clear(); // видаляє всі елементи
            Console.WriteLine(list.Contains(23)); // повертає bool якщо є такий елемент

            Console.WriteLine(list.Exists((i) => i % 100 == 0)); // повертає bool чи існує значення яке підходить по умові Predicate

            list.Find(i => i == 23);       // повертає перший елемент що відповідає умові
            list.FindIndex(i => i == 23);  // повертає індекс першого елементу що відповідає умові
            list.FindAll(i => i == 1);     // повертає List зі всіма елементами що відповідаються умові
            list.FindLast(i => i == 23);      // повертає останній елемент що відповідає умові
            list.FindLastIndex(i => i == 23); // повертає індекс останнього елементу що відповідає умові

            list.GetRange(4, 2); // повертне елементи з 4 по 5 індекс
            list.RemoveAll(i => i % 2 == 0); // видаляє всі елементи що відповідають умові

            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
        }

        // Двоз'язний список на нодах
        public static void GenericLinkedList()
        {
            LinkedList<int> lList = new LinkedList<int>();

            lList.AddLast(20);
            lList.AddLast(10);
            lList.AddFirst(2);
            lList.AddFirst(13);

            var firstNode = lList.First; // повертає node
            if (firstNode != null)
            {
                lList.AddAfter(firstNode, 999);
            }

            // lList.Remove(25) // видаляє першу ноду які знайде з таким value
            // lList.RemoveFirst(); // видаляє першу ноду
            // lList.RemoveLast(); // видаляє останню ноду

            foreach (var item in lList)
            {
                Console.WriteLine(item);
            }
        }

        public static void GenericDictionary()
        {
            // Колекція типу key value
            // Ключі повинні бути унікальні
            Dictionary<int, string> months = new Dictionary<int, string>();
            Dictionary<string, string> months2 = new Dictionary<string, string>();

            months.Add(1, "January");
            months.Add(2, "February");

            bool res = months.TryAdd(3, "March"); // Add але не генерує Exception а повертає bool чи успішно
            Console.WriteLine(res);

            months.Add(4, "April");
            months.Add(5, "May");
            months.Add(6, "June");

            if (months.ContainsKey(4))
            {
                Console.WriteLine(months[4]); // в [] вказує ключ
            }

            if (months2.ContainsKey("test"))
            {
                var s = months2["test"]; // в [] передає string то
            }

            foreach (var month in months)
            {
                Console.WriteLine($"{month.Key}: {month.Value}");
            }

            foreach (var key in months.Keys)
            {
                Console.WriteLine(key);
            }

            foreach (var value in months.Values)
            {
                Console.WriteLine(value);
            }

            int monthNumber = 13;
            if(months.ContainsKey(monthNumber))
            {
                Console.WriteLine(months[monthNumber]);
            } 
            else
            {
                Console.WriteLine("Incorrect month number");
            }
        }

        public static void GenericHashSet()
        {
            // Множина унікальних значень
            HashSet<int> set = new HashSet<int>();
            set.Add(1);
            set.Add(1);
            set.Add(2);
            set.Add(10);
            set.Add(8);
            set.Add(9);
            set.Add(5);
            set.Add(10);
            set.Add(8);
            set.Add(1);
            set.Add(7);
            set.Add(13);
            set.Add(27);

            HashSet<int> set2 = new HashSet<int> { 2,5,7,8,3,4,6456,47,6,546,457,867,867,987,3,1,2,45,6,7,4,7 };

            // Переріз множин (спільне для обох)
            var set3 = set.Intersect(set2);
            var set4 = new HashSet<int>(set);
            // Доповнення (додає всі елементи від іншої множини)
            set4.UnionWith(set);

            Console.WriteLine("Set 1");
            foreach (var i in set)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Set 2");
            foreach (var i in set2)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Set 3");
            foreach (var i in set3)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Set 4");
            foreach (var i in set4)
            {
                Console.Write(i + " ");
            }

            // Різниця множин (всі елементи які є тільки в першій множині)
            set.ExceptWith(set2);
            Console.WriteLine();
            Console.WriteLine("Set");
            foreach (var i in set)
            {
                Console.Write(i + " ");
            }


            // bool якщо set є піндмножиною set2
            set.IsSubsetOf(set2); // set = {1,2,3} set2 = {4 5, 1, 2, 3,}
            // bool якщо set є наддмножиною set2
            set.IsSupersetOf(set2); // // set = {4 5, 1, 2, 3,} set2 = {1,2,3}
        }

        static void Main(string[] args)
        {
            // GenericStack();
            // GenericQueue();
            // GenericList();
            // GenericLinkedList();
            // GenericDictionary();
            GenericHashSet();
        }

        static void NoGeneric()
        {
            // No Generic 
            // Застарілі вже майже не вокористовуються

            // Stack
            //Stack stack = new Stack();
            //stack.Push(1);
            //stack.Push("string");
            //stack.Push(true);

            //object next = stack.Peek();   // повертає останній елемент
            //foreach (var item in stack)
            //{
            //    Console.WriteLine(item + " ");
            //}
            //object last = stack.Pop();    // повертає останній елемент та видляє
            //foreach (var item in stack)
            //{
            //    Console.WriteLine(item + " ");
            //}

            // Queue
            Queue queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue("string");
            queue.Enqueue(true);

            object next = queue.Peek();   // повертає перший елемент
            foreach (var item in queue)
            {
                Console.WriteLine(item + " ");
            }
            object last = queue.Dequeue();    // повертає перший елемент та видляє
            foreach (var item in queue)
            {
                Console.WriteLine(item + " ");
            }



            // ArrayList
            ArrayList list = new ArrayList();
            list.Add(1);
            list.AddRange(queue);

            list.Sort();
            list.BinarySearch(1);

            // SortedList
            SortedList sl = new SortedList();
            sl.Add("1", "January");

            // HashTable
            Hashtable ht = new Hashtable();
            ht.Add("key", "value");
        }
    }
}
