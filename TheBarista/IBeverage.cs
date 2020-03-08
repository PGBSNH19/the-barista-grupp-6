using System;
using System.Collections.Generic;
using System.Text;

namespace TheBarista
{
    public interface IBeverage
    {
        string Name { get; }
        List<Ingredient> GetIngredients { get; }
        string GetName();
    }
}
