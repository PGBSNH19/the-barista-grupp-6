using System;

namespace TheBarista
{
    // Spy: @Norshiervani, other people used string arrays to store these
    // we use enum instead.
    public enum CoffeeSorts {
        RISTRETTO,
        CLASSIC
    }

    interface ICup
    {
        float volume;
        double price;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Espresso Group 6!");
            Espresso espresso = new Espresso();
            espresso.AddWater(10)
            espresso.SetCoffeeSort(CoffeeSorts.CLASSIC);
            //espresso.SetBean(Bean.)
        }

    }

    class Espresso
    {
        private Bean bean;
        private CoffeeSorts coffeeSort;
        private int amountWater = 0;

        public getBean() {
            return this.bean;
        }

        public getCoffeeSort() {
            return this.coffeeSort;
        }

        public getAmountWater() {
            return this.amountWater;
        }


        public void AddWater(int amountWater)
        {
            this.amountWater += amountWater;
        }
        
        public void SetBean(Bean bean)
        {
            this.bean = bean;
        }

        public void SetCoffeeSort(CoffeeSorts sort)
        {
            this.coffeeSort = sort;
        }

    }

    class Bean
    {
        private string Country { get; set; }
        private int Strength { get; set; }
        private bool Fairtrade { get; set; }
        private bool Ecologic { get; set; }

        public string GetCountry() 
        {
            return this.Country;
        }

        public int GetStrength() 
        {
            return this.Strength;
        }

        public bool GetFairtrade() 
        {
            return this.Fairtrade;
        }

        public bool GetEcologic() 
        {
            return this.Ecologic;
        }

        public void SetCountry(string country) 
        {
            this.Country = country;
        }

        public void SetStrength(int strength) 
        {
            this.Strength = strength;
        }

        public void SetFairtrade(bool fairtrade) 
        {
            this.Fairtrade = fairtrade;
        }

        public void SetEcologic(bool ecologic) 
        {
            this.Ecologic = ecologic;
        }

        enum BeanTypes 
        {
            ROBUSTA,
            ARABICA
        }
    }

    class SmallCup : ICup
    {
        const float Volume =  
        string Material { get; set; }
        string Color { get; set; }
    }
    
    class MediumCup : ICup
    {
        float Volume { get; set; }
        string Material { get; set; }
        string Color { get; set; }
    }

    class LargeCup : ICup
    {
        float Volume { get; set; }
        string Material { get; set; }
        string Color { get; set; }
    }
}
