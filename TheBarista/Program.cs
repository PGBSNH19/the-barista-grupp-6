using System;
using System.Collections.Generic;

namespace TheBarista
{
    public interface IFinishedDrink
    {
        Ingredient[] GetIngredients { get; }
    }

    public interface IBeverage
    {
        List<Ingredient> Ingredients { get; set; }
        Beans Beans { get; set; }

        IBeverage AddBeans(CoffeeSort sort, int amount) { return this; }
        IBeverage AddIngredient(Ingredient ingredient) { return this;  }
    }

    public enum CoffeeSort
    {
        Robusta,
        Colombia
    }

    public enum Ingredient
    {
        ChocolateSyrup,
        Espresso,
        MilkFoam,
        Water,
        Milk
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Espresso Group 6!");
            Console.WriteLine();
            IBeverage espresso = new FluentEspresso()
                .AddBeans(CoffeeSort.Robusta, 4)
                .ToBrew();
            Console.ReadLine();
        }
    }

    public class FluentEspresso : IBeverage
    {
        private Drink obj = new Drink();

        public List<Ingredient> Ingredients { get; set; }
        public Beans Beans { get; set; }

        public IBeverage AddBeans(CoffeeSort sort, int grams)
        {
            obj.Beans = new Beans(sort, grams);
            return this;
        }

        public IBeverage AddIngredient(Ingredient ingredient)
        {
            obj.Ingredients.Add(ingredient);
            return this;
        }

        public IFinishedDrink ToBrew()
        {
            IFinishedDrink[] finishedDrinks = new IFinishedDrink[] { 
                new Latte(), new Americano(), new Cappuccino(), new Macchiato(), new Mocha()
            };
            Dictionary<IFinishedDrink, int> rankList = new Dictionary<IFinishedDrink, int>();

            //Ersätt med LINQ - Nor
            foreach(IFinishedDrink drink in finishedDrinks)
            {
                int points = 0;
                foreach(Ingredient ingredient in drink.GetIngredients) 
                {
                    foreach (Ingredient _ingredient in this.Ingredients)
                    {
                        if (_ingredient == ingredient)
                        {
                            points++;
                        }
                    }
                }
                rankList.Add(drink, points);
            }

            return new UnknownDrink();
        }
    }

    public class Drink : IBeverage
    {
        public List<Ingredient> Ingredients { get; set; }
        public Beans Beans { get; set; }
        
        public Drink()
        {
            this.Ingredients = new List<Ingredient>();
        }
    }

    public class Latte : IFinishedDrink 
    {
        public Ingredient[] GetIngredients => new Ingredient[] { Ingredient.Espresso, Ingredient.Milk };
    }
    public class Espresso : IFinishedDrink
    {
        public Ingredient[] GetIngredients => new Ingredient[] { Ingredient.Espresso };
    }

    public class Cappuccino : IFinishedDrink
    {
        public Ingredient[] GetIngredients => new Ingredient[] { Ingredient.Milk, Ingredient.MilkFoam,
            Ingredient.Espresso };
    }

    public class Americano : IFinishedDrink
    {
        public Ingredient[] GetIngredients => new Ingredient[] { Ingredient.Espresso, Ingredient.Water };
    }

    public class Macchiato : IFinishedDrink
    {
        public Ingredient[] GetIngredients => new Ingredient[] { Ingredient.Espresso, Ingredient.MilkFoam };
    }

    public class Mocha : IFinishedDrink
    {
        public Ingredient[] GetIngredients => new Ingredient[] { Ingredient.Espresso, Ingredient.ChocolateSyrup, 
            Ingredient.Milk };
    }

    public class UnknownDrink : IFinishedDrink {
        public Ingredient[] GetIngredients => new Ingredient[] {  };
    }

    public class Beans
    {
        CoffeeSort sort;
        private int _amountInGrams;
        public int AmountInGrams
        {
            get { return _amountInGrams; }
            set
            {
                _amountInGrams = value;
            }
        }

        public Beans(CoffeeSort sort, int amountInGrams)
        {
            this.sort = sort;
            this.AmountInGrams = amountInGrams;
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
