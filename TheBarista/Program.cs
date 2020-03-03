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
        private Bean bean;
        private CoffeeSorts coffeeSort;
        private int amountWater;

        public getBean() {
            return this.bean;
        }

        public getCoffeeSort() {
            return this.coffeeSort;
        }

        public getAmountWater() {
            return this.amountWater;
        }

        public Espresso(CoffeeSorts coffeeSort, int amountWater)
        {
            this.coffeeSort = coffeeSort;
            this.amountWater = amountWater;
        }

        public void AddWater(int amountWater)
        {
            this.amountWater += amountWater;
        }
        
        void AddBean(Bean myBean)
        {
            
        }

    }

    // Spy: @Norshiervani, other people used string arrays to store these
    // we use enum instead.
    public enum CoffeeSorts {
        ROBUSTA,
        DOPPIO,
        CLASSIC
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
