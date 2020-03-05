﻿using System;
using System.Collections.Generic;

namespace TheBarista
{
    public interface IFinishedDrink
    {

    }

    public interface IBeverage
    {
        List<Ingredient> Ingredients { get; set; }
        Beans Beans { get; set; }

        IBeverage AddBeans(CoffeeSort sort, int amount) { return this; }
        IBeverage AddIngredient(Ingredient ingredient) { return this;  }
        IBeverage ToBrew() { return this; }
    }

    public enum CoffeeSort
    {
        Robusta,
        Colombia
    }

    public enum Ingredient
    {
        Milk,
        MilkFoam,
        ChocolateSyrup,
        Water
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
            // Fortsätt
            
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
        public static List<Ingredient> Ingredients { get; private set; } = new List<Ingredient> { Ingredient.Milk };
    }

    public class Cappuccino : IFinishedDrink
    {
        public static List<Ingredient> Ingredients { get; private set; } = new List<Ingredient> { Ingredient.Milk, Ingredient.MilkFoam };
    }

    public class Americano : IFinishedDrink
    {
        public static List<Ingredient> Ingredients { get; private set; } = new List<Ingredient> { Ingredient.Water };
    }

    public class Macchiato : IFinishedDrink
    {
        public static List<Ingredient> Ingredients { get; private set; } = new List<Ingredient> { Ingredient.MilkFoam };
    }

    public class Mocha : IFinishedDrink
    {
        public static List<Ingredient> Ingredients { get; private set; } = new List<Ingredient> { Ingredient.ChocolateSyrup, Ingredient.Milk };
    }

    public class UnknownDrink : IFinishedDrink { }

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
