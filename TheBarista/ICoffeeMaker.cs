using System;
using System.Collections.Generic;
using System.Text;

namespace TheBarista
{
    public interface ICoffeeMaker
    {
        List<Ingredient> Ingredients { get; set; }
        Beans Beans { get; set; }
        double Temperature { get; set; }

        ICoffeeMaker AddBeans(CoffeeSort sort, int amount);
        ICoffeeMaker AddIngredient(List<Ingredient> ingredients);
        ICoffeeMaker ValidateTemperature(Func<double, bool> query);
        ICoffeeMaker ApplyHeat(double temperature);
        IBeverage ToBrew();
    }
}
