using System;

namespace TheBarista
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }


    }

    class Espresso
    {

        Type espressotype;
        int Volume = 0;

        enum Type
        {
            Regular,
            Romano
        }

        void Espresso()
        {

        }
    }

    class Bean
    {
        string Country { get; set; }
        int Strength { get; set; }
        bool Fairtrade { get; set; }
        bool Ecologic { get; set; }
    }

    class Cup
    {
        float Volume { get; set; }
        string Material { get; set; }
        string Color { get; set; }
    }
}
