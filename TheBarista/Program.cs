using System;
using System.Collections.Generic;

namespace TheBarista
{
    public interface IFinishedDrink
    {

    }

    public interface IBeverage
    {
        Dictionary<string, int> Ingredients { get; set; }
        Cupsizes Cupsize { get; set; }
        Beans Beans { get; set; }

        IBeverage SetCupsize(Cupsizes size) { return this; }
        IBeverage AddBeans(CoffeeSorts sort, int amount) { return this; }
        IBeverage AddWater(int amount) { return this; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IBeverage americano = new FluentEspresso()
                .SetCupsize(Cupsizes.Large)
                .AddBeans(CoffeeSorts.Robusta, 8)
                .AddWater(10)
                .ToBrew();

            IBeverage espresso = new FluentEspresso()
                .SetCupsize(Cupsizes.Large)
                .AddBeans(CoffeeSorts.Robusta, 5)
                .ToBrew();

            Console.ReadLine();
        }
    }

    public class FluentEspresso : IBeverage {
        private Drink obj = new Drink();

        public Dictionary<string, int> Ingredients { get; set; }
        public Cupsizes Cupsize { get; set; }
        public Beans Beans { get; set; }

        public IBeverage SetCupsize(Cupsizes size)
        {
            obj.Cupsize = size;
            return this;
        }

        public IBeverage AddBeans(CoffeeSorts sort, int grams)
        {
            obj.Beans = new Beans(sort, grams);
            return this;
        }

        //Argument: amount in grams?
        public IBeverage AddWater(int amount)
        {
            obj.Ingredients.Add("Water", amount);
            return this;
        }

        public IBeverage AddMilk(int amount)
        {
            obj.Ingredients.Add("Milk", amount);
            return this;
        }

        public IBeverage AddMilkFoam(int amount)
        {
            obj.Ingredients.Add("MilkFoam", amount);
            return this;
        }

        //Purpose?
        public IFinishedDrink ToBrew()
        {
            if (this.obj.Beans.AmountInG > 0 && this.obj.Ingredients.Count == 0)
                return new Espresso();
            return new UnknownDrink();
        }
    }

    public enum CoffeeSorts
    {
        Robusta,
        Colombia
    }

    public enum Cupsizes
    {
        Small,
        Medium,
        Large
    }

    public class Drink : IBeverage
    {
        public Dictionary<string, int> Ingredients { get; set; }
        public Beans Beans { get; set; }
        public Cupsizes Cupsize { get; set; }

        public Drink()
        {
            this.Ingredients = new Dictionary<string, int>();
        }

        public void SetCupsize(Cupsizes size)
        {
            this.Cupsize = size;
        }
    }

    public class Espresso : IFinishedDrink { }

    public class UnknownDrink : IFinishedDrink
    {

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

        public Beans(CoffeeSorts sort, int amountInG)
        {
            this.sort = sort;
            this.AmountInG = amountInG;
        }
    }

    // Not in use
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
