using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;

namespace Generic
{
    internal class MyClass : IComparable
    {
        public MyClass()
        {
            
        }

        public int CompareTo(object? obj)
        {
            return 0;
        }
    }

    public class MyInt : INumber<MyInt>
    {
        public int intValue;

        public MyInt(int intValue)
        {
            this.intValue = intValue;
        }

        public static MyInt One => throw new NotImplementedException();

        public static int Radix => throw new NotImplementedException();

        public static MyInt Zero => throw new NotImplementedException();

        public static MyInt AdditiveIdentity => throw new NotImplementedException();

        public static MyInt MultiplicativeIdentity => throw new NotImplementedException();

        public static MyInt Abs(MyInt value)
        {
            throw new NotImplementedException();
        }

        public static bool IsCanonical(MyInt value)
        {
            throw new NotImplementedException();
        }

        public static bool IsComplexNumber(MyInt value)
        {
            throw new NotImplementedException();
        }

        public static bool IsEvenInteger(MyInt value)
        {
            throw new NotImplementedException();
        }

        public static bool IsFinite(MyInt value)
        {
            throw new NotImplementedException();
        }

        public static bool IsImaginaryNumber(MyInt value)
        {
            throw new NotImplementedException();
        }

        public static bool IsInfinity(MyInt value)
        {
            throw new NotImplementedException();
        }

        public static bool IsInteger(MyInt value)
        {
            throw new NotImplementedException();
        }

        public static bool IsNaN(MyInt value)
        {
            throw new NotImplementedException();
        }

        public static bool IsNegative(MyInt value)
        {
            throw new NotImplementedException();
        }

        public static bool IsNegativeInfinity(MyInt value)
        {
            throw new NotImplementedException();
        }

        public static bool IsNormal(MyInt value)
        {
            throw new NotImplementedException();
        }

        public static bool IsOddInteger(MyInt value)
        {
            throw new NotImplementedException();
        }

        public static bool IsPositive(MyInt value)
        {
            throw new NotImplementedException();
        }

        public static bool IsPositiveInfinity(MyInt value)
        {
            throw new NotImplementedException();
        }

        public static bool IsRealNumber(MyInt value)
        {
            throw new NotImplementedException();
        }

        public static bool IsSubnormal(MyInt value)
        {
            throw new NotImplementedException();
        }

        public static bool IsZero(MyInt value)
        {
            throw new NotImplementedException();
        }

        public static MyInt MaxMagnitude(MyInt x, MyInt y)
        {
            throw new NotImplementedException();
        }

        public static MyInt MaxMagnitudeNumber(MyInt x, MyInt y)
        {
            throw new NotImplementedException();
        }

        public static MyInt MinMagnitude(MyInt x, MyInt y)
        {
            throw new NotImplementedException();
        }

        public static MyInt MinMagnitudeNumber(MyInt x, MyInt y)
        {
            throw new NotImplementedException();
        }

        public static MyInt Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public static MyInt Parse(string s, NumberStyles style, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public static MyInt Parse(ReadOnlySpan<char> s, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public static MyInt Parse(string s, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public static bool TryConvertFromChecked<TOther>(TOther value, [MaybeNullWhen(false)] out MyInt result) where TOther : INumberBase<TOther>
        {
            throw new NotImplementedException();
        }

        public static bool TryConvertFromSaturating<TOther>(TOther value, [MaybeNullWhen(false)] out MyInt result) where TOther : INumberBase<TOther>
        {
            throw new NotImplementedException();
        }

        public static bool TryConvertFromTruncating<TOther>(TOther value, [MaybeNullWhen(false)] out MyInt result) where TOther : INumberBase<TOther>
        {
            throw new NotImplementedException();
        }

        public static bool TryConvertToChecked<TOther>(MyInt value, [MaybeNullWhen(false)] out TOther result) where TOther : INumberBase<TOther>
        {
            throw new NotImplementedException();
        }

        public static bool TryConvertToSaturating<TOther>(MyInt value, [MaybeNullWhen(false)] out TOther result) where TOther : INumberBase<TOther>
        {
            throw new NotImplementedException();
        }

        public static bool TryConvertToTruncating<TOther>(MyInt value, [MaybeNullWhen(false)] out TOther result) where TOther : INumberBase<TOther>
        {
            throw new NotImplementedException();
        }

        public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out MyInt result)
        {
            throw new NotImplementedException();
        }

        public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out MyInt result)
        {
            throw new NotImplementedException();
        }

        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, [MaybeNullWhen(false)] out MyInt result)
        {
            throw new NotImplementedException();
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out MyInt result)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object? obj)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(MyInt? other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(MyInt? other)
        {
            throw new NotImplementedException();
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            throw new NotImplementedException();
        }

        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        {
            throw new NotImplementedException();
        }

        public static MyInt operator +(MyInt value)
        {
            return new MyInt(+value.intValue);
        }

        public static MyInt operator +(MyInt left, MyInt right)
        {
            return new MyInt(left.intValue + right.intValue);
        }

        public static MyInt operator -(MyInt value)
        {
            throw new NotImplementedException();
        }

        public static MyInt operator -(MyInt left, MyInt right)
        {
            throw new NotImplementedException();
        }

        public static MyInt operator ++(MyInt value)
        {
            throw new NotImplementedException();
        }

        public static MyInt operator --(MyInt value)
        {
            throw new NotImplementedException();
        }

        public static MyInt operator *(MyInt left, MyInt right)
        {
            throw new NotImplementedException();
        }

        public static MyInt operator /(MyInt left, MyInt right)
        {
            throw new NotImplementedException();
        }

        public static MyInt operator %(MyInt left, MyInt right)
        {
            throw new NotImplementedException();
        }

        public static bool operator ==(MyInt? left, MyInt? right)
        {
            throw new NotImplementedException();
        }

        public static bool operator !=(MyInt? left, MyInt? right)
        {
            throw new NotImplementedException();
        }

        public static bool operator <(MyInt left, MyInt right)
        {
            throw new NotImplementedException();
        }

        public static bool operator >(MyInt left, MyInt right)
        {
            throw new NotImplementedException();
        }

        public static bool operator <=(MyInt left, MyInt right)
        {
            throw new NotImplementedException();
        }

        public static bool operator >=(MyInt left, MyInt right)
        {
            throw new NotImplementedException();
        }
    }

    internal class MyValueClass
    {
        
    }

    internal class MyClassWithoutDefaultCtor
    {
        private int value;
        
        public MyClassWithoutDefaultCtor(int value)
        {
            this.value = value;
        }
    }

    internal struct MyNumber()
    {
        int a = 1;
    }

    public struct MyValue()
    {
        public string value = "fsfklsdfksdfs";
        public int[] arr = [1, 2, 3, 4, 5, 67, 7, 8];
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Тип визначається автоматично по аргументу
            PrintGreenValue(2);
            PrintGreenValue("str value");
            PrintGreenValue(2.5);
            PrintGreenValue(2.5f);
            PrintGreenValue(2.5m);
            PrintGreenValue(true);
            PrintGreenValue(new DateTime());

            // Потрібно вказати типи, оскільки тип повертаємого значення не визначається автоматично
            double res = ConvertType<int, double>(2);

            string resStr = SetDefaultValue<string>();
            int resInt = SetDefaultValue<int>();
            DateTime resDateTime = SetDefaultValue<DateTime>();
            bool resBool = SetDefaultValue<bool>();

            // обмеження для типів

            // struct
            GenericStruct(2);
            GenericStruct(DateTime.Now);

            // class
            GenericClass("text");
            GenericClass(new MyClass());

            // notnull
            GenericNotNull(2);
            //GenericNotNull<string?>(null);

            // unmanaged
            GenericUnmanaged(1);
            //GenericUnmanaged(new MyValue());  // складний тип який в собі має посилання на stirng та масив
            GenericUnmanaged(new MyNumber()); // простий тип оскільки немає посилань

            // new()
            var myClass = new MyClass();
            GenericNew(myClass);
            GenericNew(1);
            GenericNew(false);

            var myClassWithoutCtor = new MyClassWithoutDefaultCtor(1);
            //GenericNew(myClassWithoutCtor); // помилка бо клас немає дефолтного конструктора



            // Інтерфейс
            int[] arr = [1, 2, 3, 4, 5];
            GenericInterface(arr);

            GenericInterface2<MyClass>(new MyClass(), new MyClass());
            //GenericInterface2<MyValueClass>(new MyValueClass(), new MyValueClass());


            // Вказаний клас
            GenericAnyClass(new MyClass());
            // GenericAnyClass(new MyValueClass()); // помилка бо MyValueClass не є дочірнім класом MyClass




            var value1 = new MyInt(5);
            var value2 = new MyInt(13);
            var resInt2 = Add(value1, value2);
            Console.WriteLine(resInt2.intValue);




            // Generic класс
            var genericClass = new GenericClass<int>();
            var genericClass2 = new GenericClass<double>();
            var genericClass3 = new GenericClass<MyNumber>();



            // Власний масив
            MyArray<string> colors = new MyArray<string>();
            colors.Add("blue");
            colors.Add("yellow");
            colors.Add("white");
            colors.Add("black");

            foreach (var color in colors)
            {
                Console.WriteLine(color);
            }
        }

        // Generic методи
        static void PrintGreenValue<T>(T value)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        static TOut ConvertType<TIn, TOut>(TIn value)
        {
            return (TOut)Convert.ChangeType(value, typeof(TOut));
        }

        static void TemplateMethod<T>(int a, T value)
        {
            T res = default;
        }

        static T SetDefaultValue<T>()
        {
            // Якщо T - це структура то записується дефотний конструктор
            // Якщо T - це клас то записується null
            T res = default;
            return res;
        }


        // where - обмеження для типів

        // struct
        static void GenericStruct<T>(T value) 
            where T : struct
        {
            // оскільки це структура то точно можна передати дефолтний конструктор
            T test = new T();
            Console.WriteLine(value);
        }

        // class
        static void GenericClass<T>(T value)
            where T : class
        {
            // оскільки це точно клас то можна записати null
            T test = null;
            Console.WriteLine(value);
        }

        // notnull
        static void GenericNotNull<T>(T value)
            where T : notnull
        {
            Console.WriteLine(value);
        }

        // unmanaged
        // Тільки прості типи які не містять в собі посилання
        static void GenericUnmanaged<T>(T value)
            where T : unmanaged
        {
            Console.WriteLine(value);
        }

        // new()
        // всі типи даних які мають конструктор за замовчуванням
        static void GenericNew<T>(T value)
            where T : new()
        {
            T test = new T();
            Console.WriteLine(value);
        }

        // Будь-який інтерфейс
        static void GenericInterface<T>(T collection)
            where T : IEnumerable
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        static int GenericInterface2<T>(T value1, T value2)
            where T : IComparable
        {
            return value1.CompareTo(value2);
        }

        // Будь-який клас
        // В якості типу можна передати тільки вказаний клас або його дочірні класи
        static void GenericAnyClass<T>(T value)
            where T : MyClass
        {
            Console.WriteLine(value);
        }




        // Приклад для суми двох значень
        static T Add<T>(T value1, T value2)
            where T : INumber<T>
        {
            return value1 + value2;
        }


        // Можна вказувати декілька умов
        static void Multi<T>(T value)
            where T : class, IComparable, IEnumerable, INumber<int>
        {
            
        }
    }
}
