namespace Generic
{
    internal class GenericClass<T>
        where T : struct
    {
        private T value;

        public T Value { get; set; }

        public GenericClass()
        {
            value = default;
        }

        public GenericClass(T value)
        {
            this.value = value;
        }

        public T GetValue()
        {
            return value;
        }
    }
}
