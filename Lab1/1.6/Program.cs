namespace _1._6
{
    interface IAbility : IIntelligent, IThingking
    { }

    interface IIntelligent
    {
        void intelligent_behavior();
    }

    interface IThingking
    {
        void intelligent_behavior();
    }

    class Mamal
    {
        string characteristics;
    }

    class Whale : Mamal
    {
        public Whale() { }
    }

    class Human : Mamal, IAbility
    {
        public Human() { }
        public void intelligent_behavior()
        {
            Console.WriteLine("Steven has stopped thinking...");
        }
        public void thinking_behavior()
        {
            Console.WriteLine("Steven tries to use 'Failure' - It failed...");
        }
    }

    

    internal class Program
    {
        static void Main(string[] args)
        {
            Human Steven = new Human();
            Steven.thinking_behavior();
            Steven.intelligent_behavior();
        }
    }
}