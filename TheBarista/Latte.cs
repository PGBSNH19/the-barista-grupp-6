using System;
using System.Collections.Generic;
using System.Text;

namespace TheBarista
{
    public class Latte : IBeverage
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
}
