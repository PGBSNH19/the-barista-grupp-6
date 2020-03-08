using System;
using System.Collections.Generic;
using System.Text;

namespace TheBarista
{
    public class Espresso : IBeverage
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
}
