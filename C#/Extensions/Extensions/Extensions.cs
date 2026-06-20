namespace Extensions
{
    // Клас для методів розширення має бути статичний
    public static class Extensions
    {
        // Методи розширення повинні бути статичні
        // Перший аргумент повинен мати префікс this та тип який ми хочемо розширити
        public static double Power(this int value, int power)
        {
            if (power == 0)
            {
                return 1;
            }

            double res = 1;
            for (int i = 0; i < Math.Abs(power); i++)
            {
                res *= value;
            }

            return power < 0 ? 1 / res : res;
        }

        public static void ColoredPrint(this string value, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        public static void Print<T>(this IEnumerable<T> collection, bool endl = true)
        {
            foreach (var item in collection)
            {
                if (endl)
                {
                    Console.WriteLine(item);
                }
                else
                {
                    Console.Write(item + " ");
                }
            }

            if (!endl)
            {
                Console.WriteLine();
            }
        }

        public static string ToUaFormat(this DateTime date)
        {
            return date.ToString("dd.MM.yyyy HH:mm:ss");
        }

        public static char GetFirstSymbol(this string value)
        {
            foreach (var i in value)
            {
                if (!char.IsLetterOrDigit(i) && !char.IsWhiteSpace(i))
                {
                    return i;
                }
            }

            return default(char);
        }
    }
}
