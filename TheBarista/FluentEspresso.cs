using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBarista
{
    public class FluentCoffeeMaker : ICoffeeMaker
    {
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public Beans Beans { get; set; }
        public double Temperature { get; set; }

        public ICoffeeMaker ApplyHeat(double temperature)
        {
            this.Temperature = temperature;
            Console.WriteLine("Cranking up heat to " + temperature + " degrees.");
            return this;
        }

        public ICoffeeMaker AddBeans(CoffeeSort sort, int grams)
        {
            Beans = new Beans(sort, grams);
            Console.WriteLine(grams + " grams of " + sort.ToString() + " beans added.");
            return this;
        }

        public ICoffeeMaker AddIngredient(List<Ingredient> ingredients)
        {
            ingredients.ForEach(i => {
                this.Ingredients.Add(i);
                Console.WriteLine("Ingredient " + i.ToString() + " added.");
            }
            );
            return this;
        }

        public ICoffeeMaker ValidateTemperature(Func<double, bool> query)
        {
            if (query.Invoke(Temperature))
                throw new ArgumentException("Heat too high or too low");
            Console.WriteLine("Drink temperature is valid.");
            return this;
        }

        public IBeverage ToBrew()
        {
            IBeverage[] finishedDrinks = new IBeverage[] {
                new Latte(), new Americano(), new Cappuccino(), new Macchiato(), new Mocha(), new Espresso()
            };

            IBeverage finishedDrink = finishedDrinks.FirstOrDefault(f => Enumerable.SequenceEqual(f.GetIngredients.OrderBy(i => i), this.Ingredients.OrderBy(i => i)));

            if (finishedDrink == null)
                finishedDrink = new UnknownDrink();

            Console.WriteLine("Brew complete.");
            Console.WriteLine(finishedDrink.GetName());

            return finishedDrink;
        }
    }
}
