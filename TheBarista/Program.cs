﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TheBarista
{
    public interface IFinishedDrink
    {
        string Name { get; }
        List<Ingredient> GetIngredients { get; }
        string GetName();
    }

    public interface IBeverage
    {
        List<Ingredient> Ingredients { get; set; }
        Beans Beans { get; set; }
        Heat Heat { get; set; }

        IBeverage AddBeans(CoffeeSort sort, int amount);
        IBeverage AddIngredient(List<Ingredient> ingredients);
        IBeverage ValidateTemperature(Func<Heat, bool> query);
        IBeverage ApplyHeat(Heat heat);
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
            Console.WriteLine("Welcome to Espresso Group 6!\n");

            // Make a Latte
            var latte = new FluentEspresso()
                .AddBeans(CoffeeSort.Colombia, 5)
                .ApplyHeat(new Heat(92))
                .ValidateTemperature(h => h.GetTemperature() < 90 || h.GetTemperature() > 94)
                .AddIngredient(new List<Ingredient> {
                    Ingredient.Espresso,
                    Ingredient.Milk
                })
                .ToBrew();
        }
    }

    public class FluentEspresso : IBeverage
    {
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public Beans Beans { get; set; }
        // Added for experiment
        // True when drink temp is verified
        public Heat Heat { get; set; }

        public IBeverage ApplyHeat(Heat heat)
        {
            this.Heat = heat;
            Console.WriteLine("Cranking up heat to " + heat.GetTemperature() + " degrees.");
            return this;
        }

        public IBeverage AddBeans(CoffeeSort sort, int grams)
        {
            Beans = new Beans(sort, grams);
            Console.WriteLine(grams + " grams of " + sort.ToString() + " beans added.");
            return this;
        }

        public IBeverage AddIngredient(List<Ingredient> ingredients)
        {
            ingredients.ForEach(i => {
                this.Ingredients.Add(i);
                Console.WriteLine("Ingredient " + i.ToString() + " added.");
            }
            );
            return this;
        }

        public IBeverage ValidateTemperature(Func<Heat, bool> query)
        {
            if (query.Invoke(Heat))
                throw new ArgumentException("Heat too high or too low");
            Console.WriteLine("Drink temperature is valid.");
            return this;
        }

        public IFinishedDrink ToBrew()
        {
            IFinishedDrink[] finishedDrinks = new IFinishedDrink[] {
                new Latte(), new Americano(), new Cappuccino(), new Macchiato(), new Mocha(), new Espresso()
            };

            IFinishedDrink finishedDrink = finishedDrinks.FirstOrDefault(f => Enumerable.SequenceEqual(f.GetIngredients.OrderBy(i => i), this.Ingredients.OrderBy(i => i)));

            Console.WriteLine("Brew complete.");

            if (finishedDrink == null)
            {
                Console.WriteLine("Unknown Drink");
                return new UnknownDrink();
            }
            else
            {
                Console.WriteLine(finishedDrink.GetName());
                return finishedDrink;
            }
        }
    }

    public class Heat
    {
        private double _temperature = 0;

        public Heat(int temperature)
        {
            _temperature = temperature;
        }

        public double GetTemperature() { return _temperature; }
    }

    public class Latte : IFinishedDrink
    {
        public string Name { get; } = "Latte";

        public string GetName()
        {
            return this.Name;
        }

        public List<Ingredient> GetIngredients => new List<Ingredient>
        {
            Ingredient.Espresso,
            Ingredient.Milk
        };
    }

    public class Espresso : IFinishedDrink
    {
        public string Name { get; } = "Espresso";

        public string GetName()
        {
            return this.Name;
        }

        public List<Ingredient> GetIngredients => new List<Ingredient>
        {
            Ingredient.Espresso
        };
    }

    public class Cappuccino : IFinishedDrink
    {
        public string Name { get; } = "Cappuccino";

        public string GetName()
        {
            return this.Name;
        }

        public List<Ingredient> GetIngredients => new List<Ingredient>
        {
            Ingredient.Milk,
            Ingredient.MilkFoam,
            Ingredient.Espresso
        };
    }

    public class Americano : IFinishedDrink
    {
        public string Name { get; } = "Americano";

        public string GetName()
        {
            return this.Name;
        }

        public List<Ingredient> GetIngredients => new List<Ingredient>
        {
            Ingredient.Espresso,
            Ingredient.Water
        };
    }

    public class Macchiato : IFinishedDrink
    {
        public string Name { get; } = "Macchiato";

        public string GetName()
        {
            return this.Name;
        }

        public List<Ingredient> GetIngredients => new List<Ingredient>
        {
            Ingredient.Espresso,
            Ingredient.MilkFoam
        };
    }

    public class Mocha : IFinishedDrink
    {
        public string Name { get; } = "Mocha";

        public string GetName()
        {
            return this.Name;
        }

        public List<Ingredient> GetIngredients => new List<Ingredient>
        {
            Ingredient.Espresso,
            Ingredient.ChocolateSyrup,
            Ingredient.Milk
        };
    }

    public class UnknownDrink : IFinishedDrink
    {
        public string Name { get; } = "Unknown Drink";

        public string GetName()
        {
            return this.Name;
        }

        public List<Ingredient> GetIngredients => new List<Ingredient> { };
    }

    public class Beans
    {
        private CoffeeSort sort;
        private int _amountInGrams;
        public int AmountInGrams
        {
            get => _amountInGrams;
            set => _amountInGrams = value;
        }

        public Beans(CoffeeSort sort, int amountInGrams)
        {
            this.sort = sort;
            this.AmountInGrams = amountInGrams;
        }
    }

    // Note @pierre-nygard
    // Not implemented
    public class Additive
    {
        // Example: Sugar
        private string _name;

        public string Name
        {
            get => throw new NotImplementedException();
            set => _name = value;
        }
    }
}
