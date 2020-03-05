using System;
using System.Collections.Generic;

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
            IFinishedDrink espresso = new FluentEspresso()
                .AddBeans(CoffeeSort.Robusta, 4)
                .AddIngredient(Ingredient.Espresso)
                .ToBrew();
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
            List<IFinishedDrink> finishedDrinks = new List<IFinishedDrink> 
            { 
                new Latte(), 
                new Espresso(),
                new Americano(), 
                new Cappuccino(), 
                new Macchiato(), 
                new Mocha()
            };
            Dictionary<IFinishedDrink, int> rankList = new Dictionary<IFinishedDrink, int>();

            //Ersätt med LINQ - Nor

            foreach (var drink in finishedDrinks)
            {
                if(this.Ingredients == drink.GetIngredients)
                {
                    throw new ArgumentNullException();
                }
            }

            //foreach (IFinishedDrink drink in finishedDrinks)
            //{
            //    int points = 0;
            //    foreach(Ingredient ingredient in drink.GetIngredients) 
            //    {
            //        foreach (Ingredient _ingredient in this.Ingredients)
            //        {
            //            if (_ingredient == ingredient)
            //            {
            //                points++;
            //            }
            //            else
            //            {
            //                points--;
            //            }
            //        }
            //    }
            //    rankList.Add(drink, points);
            //}
            return new UnknownDrink();
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
