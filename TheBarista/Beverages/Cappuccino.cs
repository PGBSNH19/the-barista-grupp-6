using System;
using System.Collections.Generic;
using System.Text;

namespace TheBarista
{
    public class Cappuccino : IBeverage
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
}
