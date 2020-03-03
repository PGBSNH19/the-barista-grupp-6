using System;

namespace TheBarista
{
    // Spy: @Norshiervani, other people used string arrays to store these
    // we use enum instead.
    public enum CoffeeSorts {
        RISTRETTO,
        CLASSIC
    }

    abstract class CupSize
    {
        private float volume;
        private double price;

        protected CupSize(float volume, double price) {
            this.volume = volume;
            this.price = price;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Espresso Group 6!");
            Espresso espresso = new Espresso();
            espresso.AddWater(10);
            espresso.SetCoffeeSort(CoffeeSorts.CLASSIC);
            //espresso.SetBean(new Bean);

        }

    }

    class Espresso
    {
        private Bean bean;
        private CoffeeSorts coffeeSort;
        private int amountWater = 0;
        private CupSize cup;

        public Bean GetBean() {
            return this.bean;
        }

        public CoffeeSorts GetCoffeeSort() {
            return this.coffeeSort;
        }

        public int GetAmountWater() {
            return this.amountWater;
        }

        public CupSize GetCupSize()
        {
            return this.cup;
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
        public void SetCupSize(CupSize cup)
        {
            this.cup=cup;

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

    class SmallCup : CupSize
    {
        public SmallCup() {
            super(8, 25);
        }
    }
    
    class MediumCup : CupSize
    {
        public MediumCup() {
            super(12, 30);
        }
    }

    class LargeCup : CupSize
    {
        public LargeCup() {
            super(16, 35);
        }
    }
}
