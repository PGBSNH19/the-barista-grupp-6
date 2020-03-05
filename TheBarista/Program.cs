using System;
using System.Collections.Generic;
using System.Linq;

namespace TheBarista
{
    public interface IFinishedDrink
    {
        List<Ingredient> GetIngredients { get; }
    }

    public interface IBeverage
    {
        List<Ingredient> Ingredients { get; set; }
        Beans Beans { get; set; }

        IBeverage AddBeans(CoffeeSort sort, int amount);
        IBeverage AddIngredient(Ingredient ingredient);
        IFinishedDrink ToBrew();
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

            //Should match Cappucino
            IFinishedDrink drink = new FluentEspresso()
                .AddBeans(CoffeeSort.Robusta, 4)
                .AddIngredient(Ingredient.MilkFoam)
                .AddIngredient(Ingredient.Espresso)
                .AddIngredient(Ingredient.Milk)
                .ToBrew();

            //Shouldn't match any (Unknown drink)
            IFinishedDrink drink2 = new FluentEspresso()
                .AddBeans(CoffeeSort.Robusta, 4)
                .AddIngredient(Ingredient.MilkFoam)
                .AddIngredient(Ingredient.Espresso)
                .AddIngredient(Ingredient.Milk)
                .AddIngredient(Ingredient.Water)
                .ToBrew();

            Console.WriteLine(drink);
            Console.WriteLine(drink2);
        }
    }

    public class FluentEspresso : IBeverage
    {
        //private Drink obj = new Drink();

        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public Beans Beans { get; set; }

        public IBeverage AddBeans(CoffeeSort sort, int grams)
        {
            Beans = new Beans(sort, grams);
            return this;
        }

        public IBeverage AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
            return this;
        }

        //function(Func<obj, bool> someName)

        public IFinishedDrink ToBrew()
        {
            IFinishedDrink[] finishedDrinks = new IFinishedDrink[] {
                new Latte(), new Americano(), new Cappuccino(), new Macchiato(), new Mocha(), new Espresso()
            };

            IFinishedDrink finishedDrink = finishedDrinks.FirstOrDefault(f => Enumerable.SequenceEqual(f.GetIngredients.OrderBy(i => i), this.Ingredients.OrderBy(i => i)));

            return finishedDrink == null ? new UnknownDrink() : finishedDrink;
        }
    }

    public class Latte : IFinishedDrink 
    {
        public List<Ingredient> GetIngredients => new List<Ingredient> 
        { 
            Ingredient.Espresso, 
            Ingredient.Milk 
        };
    }

    public class Espresso : IFinishedDrink
    {
        public List<Ingredient> GetIngredients => new List<Ingredient> 
        { 
            Ingredient.Espresso 
        };
    }

    public class Cappuccino : IFinishedDrink
    {
        public List<Ingredient> GetIngredients => new List<Ingredient> 
        { 
            Ingredient.Milk, 
            Ingredient.MilkFoam,
            Ingredient.Espresso 
        };
    }

    public class Americano : IFinishedDrink
    {
        public List<Ingredient> GetIngredients => new List<Ingredient> 
        { 
            Ingredient.Espresso, 
            Ingredient.Water 
        };
    }

    public class Macchiato : IFinishedDrink
    {
        public List<Ingredient> GetIngredients => new List<Ingredient> 
        { 
            Ingredient.Espresso, 
            Ingredient.MilkFoam 
        };
    }

    public class Mocha : IFinishedDrink
    {
        public List<Ingredient> GetIngredients => new List<Ingredient> 
        {
            Ingredient.Espresso, 
            Ingredient.ChocolateSyrup, 
            Ingredient.Milk 
        };
    }

    public class UnknownDrink : IFinishedDrink {
        public List<Ingredient> GetIngredients => new List<Ingredient> { };
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
