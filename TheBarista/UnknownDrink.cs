using System;
using System.Collections.Generic;
using System.Text;

namespace TheBarista
{
    public class UnknownDrink : IBeverage
    {
        public string Name { get; } = "Unknown Drink";

        public string GetName()
        {
            return this.Name;
        }

        public List<Ingredient> GetIngredients => new List<Ingredient> { };
    }
}
