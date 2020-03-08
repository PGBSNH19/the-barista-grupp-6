using System;
using System.Collections.Generic;
using System.Text;

namespace TheBarista
{
    public class Mocha : IBeverage
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
}
