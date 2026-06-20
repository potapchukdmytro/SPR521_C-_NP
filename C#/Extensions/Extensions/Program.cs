namespace Extensions
{
    internal class Program
    {
        static void SetFive(ref int value)
        {
            value = 5;
        }

        static void PrintValue(in int value)
        {
            // помилка тому що in тільки для читання
            // value = 5;
            Console.WriteLine(value);
        }

        static void NowDate(out DateTime now)
        {
            now = DateTime.Now;
        }

        // Extension methods
        static void Main(string[] args)
        {
            int number = 10;
            // В аргумент this автоматично передається змінна від якої було викликано метод
            double res = number.Power(-3);
            Console.WriteLine(res);

            number = 2;
            res = number.Power(10);
            Console.WriteLine(res);

            string text = "Hello world";
            text.ColoredPrint(ConsoleColor.Yellow);


            Stack<int> stack = new Stack<int>([7, 9, 9, 3, 46, 56, 1]);
            Dictionary<int, int> dictionary = new Dictionary<int, int>
            {
                { 1, 1},
                { 2, 2},
                { 3, 3}
            };
            List<string> list = new List<string> { "January", "February", "March" };

            list.Print(false);
            stack.Print(false);
            dictionary.Print();


            var now = DateTime.Now;
            Console.WriteLine(now.ToUaFormat());


            string myText = "Hello World!";
            Console.WriteLine(myText.GetFirstSymbol());
        }


        // ref in out
        //static void Main(string[] args)
        //{
        //    // ref - передати за посиланням

        //    int number = 25;
        //    SetFive(ref number);


        //    // in - передати за посиланням але тільки для читання
        //    PrintValue(in number);


        //    // out - передати за посилання для ініціалізації
        //    // out - гарантує що метод щось запише у змінну
        //    DateTime dt;
        //    NowDate(out dt);
        //    Console.WriteLine(dt);

        //    NowDate(out DateTime dtNow);
        //    Console.WriteLine(dtNow.Year);


        //    string numberStr = "100";
        //    bool result = int.TryParse(numberStr, out int n);
        //    if(result)
        //    {
        //        Console.WriteLine(n * 2);
        //    }
        //    else
        //    {
        //        Console.WriteLine("numberStr not number");
        //    }
        //}
    }
}
