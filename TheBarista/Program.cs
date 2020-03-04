using System;
using System.Collections.Generic;

namespace TheBarista
{

    public interface IBeverage
    {
        Dictionary<string, int> Ingredients { get; set; }
        EspressoTypes Type { get; set; }
        Cupsizes Cupsize { get; set; }
        Beans Beans { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FluentEspresso espresso = new FluentEspresso()
                .SetCupsize(Cupsizes.Large)
                .SetType(EspressoTypes.Americano)
                .AddWater(20)
                .AddBeans(5);

            Console.ReadLine();
        }
    }

    public class FluentEspresso {
        private Espresso obj = new Espresso();

        public FluentEspresso SetType(EspressoTypes type)
        {
            obj.Type = type;
            return this;
        }

        public FluentEspresso SetCupsize(Cupsizes size)
        {
            obj.Cupsize = size;
            return this;
        }

        public FluentEspresso AddBeans(int grams)
        {
            obj.Beans.AmountInG = grams;
            return this;
        }

        public FluentEspresso AddWater(int amount)
        {
            obj.Ingredients.Add("Water", amount);
            return this;
        }

        public FluentEspresso AddMilk(int amount)
        {
            obj.Ingredients.Add("Milk", amount);
            return this;
        }

        public FluentEspresso AddMilkFoam(int amount)
        {
            obj.Ingredients.Add("MilkFoam", amount);
            return this;
        }

    }

    public enum EspressoTypes
    {
        Espresso,
        Americano,
        Latte
    }

    public enum Cupsizes
    {
        Small,
        Medium,
        Large
    }

    public class Espresso : IBeverage
    {
        public Dictionary<string, int> Ingredients { get; set; }
        public Beans Beans { get; set; }
        public EspressoTypes Type { get; set; }
        public Cupsizes Cupsize { get; set; }

        public Espresso()
        {
            this.Ingredients = new Dictionary<string, int>();
            this.Beans = new Beans();
        }

        public void SetType(EspressoTypes type)
        {
            this.Type = type;
        }

        public void SetCupsize(Cupsizes size)
        {
            this.Cupsize = size;
        }
    }

    public enum CoffeeSorts
    {
        Robusta,
        Colombia
    }

    public class Beans
    {
        CoffeeSorts sort;
        private int _amount;
        public int AmountInG
        {
            get { return _amount; }
            set
            {
                _amount = value;
            }
        }
    }

    public class Additive
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }
    }
}
