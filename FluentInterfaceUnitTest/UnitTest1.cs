using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TheBarista;

namespace FluentInterfaceUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMakingLatte()
        {
            IFinishedDrink latte = new FluentEspresso()
                .AddBeans(CoffeeSort.Colombia, 5)
                .ApplyHeat(92)
                .ValidateTemperature(h => h < 90 || h > 94)
                .AddIngredient(new List<Ingredient> {
                    Ingredient.Espresso,
                    Ingredient.Milk
                })
                .ToBrew();

            Assert.IsInstanceOfType(latte, typeof(Latte));
        }

        [TestMethod]
        public void TestApplyingHeat()
        {
            double temperature = 92;
            IBeverage beverage = new FluentEspresso()
                .ApplyHeat(temperature);

            Assert.AreEqual(temperature, beverage.Temperature);
        }

        [TestMethod]
        public void TestValidatingTemp()
        {
            double temperature = 92;

            Assert.ThrowsException<ArgumentException>(() => new FluentEspresso()
                .ApplyHeat(temperature).ValidateTemperature(h => h < 100 || h > 105));
        }
    }
}
