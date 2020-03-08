using System;
using System.Collections.Generic;
using System.Text;

namespace TheBarista
{
    public class Americano : IBeverage
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
}
