using System;
using System.Collections.Generic;

namespace TheBarista
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Espresso Group 6!\n");

            // Should match a Latte and print out steps
            IBeverage latte = new FluentCoffeeMaker()
                .AddBeans(CoffeeSort.Colombia, 5)
                .ApplyHeat(92)
                .ValidateTemperature(h => h < 90 || h > 94)
                .AddIngredient(new List<Ingredient> {
                    Ingredient.Espresso,
                    Ingredient.Milk
                })
                .ToBrew();
        }
    }

    // Note @pierre-nygard
    // Not implemented
    [Obsolete("This class has not been implemented yet.", true)]
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
