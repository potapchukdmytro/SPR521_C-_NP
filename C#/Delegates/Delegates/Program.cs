using System.Threading.Channels;

namespace Delegates
{
    public delegate void VoidMethod();
    public delegate void PrintString(string str);
    public delegate bool Comparator(int a, int b);

    internal class Program
    {
        static void TestMethod()
        {
            Console.WriteLine("Call TestMethod");
        }

        static void GreenPrinter(string value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        static void RedPrinter(string value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        static bool Less(int a, int b)
        {
            return a < b;
        }

        static bool Greater(int a, int b)
        {
            return a > b;
        }

        static bool Equal(int a, int b)
        {
            return a == b;
        }

        static void Main(string[] args)
        {
            //VoidMethod method = TestMethod;
            //method();
            //TestMethod();

            //PrintString printStr = GreenPrinter;
            //printStr("Hello world");

            //Printer("My text", GreenPrinter);
            //Printer("Red text", RedPrinter);

            //Comparator comparator = Equal;
            //int a = 10;
            //int b = 17;
            //Console.WriteLine(comparator(a, b));


            int[] arr = { 1, 5, 3, 9, 2, 7, 10, 12, 35, 65, 12, 1, 0, 99, 11, 7, 15, 27 };

            //int res = FindNumber(arr, Greater);
            //Console.WriteLine(res);


            // Анонімні функції
            // Якщо після => є фігурні дужки, то потрібно явно вказувати типи параметрів та використовувати return для повернення результату
            // Якщо після => немає фігурних дужок, то типи параметрів можна не вказувати, а результат буде неявно повернутий

            //Comparator cmp = (int a, int b) => { return a != b; };
            //Comparator cmp2 = (int a, int b) => a != b;

            //int res = FindNumber(arr, (int a, int b) => a < b);
            //Console.WriteLine(res);



            //ArrayService service = new ArrayService(arr);
            //int res = service.Find((a, b) => a > b);
            //Console.WriteLine(res);




            //UserService userService = new UserService();
            //User user = userService.FindUser(user => user.Email == "user10@example.com");
            //if(user != null)
            //{
            //    Console.WriteLine(user);
            //}
            //else
            //{
            //    Console.WriteLine("User not found");
            //}







            // Стандартні делегати
            // Action - делегат для методів, які не повертають значення
            Action action = TestMethod; // жодних параметрів
            Action<string> printAction = GreenPrinter; // один параметр типу string
            Action<int, int> intAction = (int a, int b) => Console.WriteLine(a + b); // два параметри типу int
            Action<int, bool, string, char, User, object, int[]> actionMul;

            // Func - делегат для методів, які повертають значення. Останній тип - це тип повертаємого значення
            Func<bool> boolRet = () => true;
            Func<int, int, bool> comp = (int a, int b) => a < b;

            // Predicate - делегат для методів, які повертають bool і приймають один параметр. Еквівалент Func<T, bool>
            Predicate<User> findUser = (User user) => user.IsPremium = true;
        }

        static void Printer(string text, PrintString print)
        {
            print(text);
        }

        static int FindNumber(int[] arr, Comparator comp)
        {
            int res = arr[0];

            foreach (var item in arr)
            {
                if(comp(item, res))
                {
                    res = item;
                }
            }

            return res;
        }
    }
}
