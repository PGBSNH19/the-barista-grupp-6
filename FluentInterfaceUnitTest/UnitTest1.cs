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
            IBeverage latte = new FluentCoffeeMaker()
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
            ICoffeeMaker beverage = new FluentCoffeeMaker()
                .ApplyHeat(temperature);

            Assert.AreEqual(temperature, beverage.Temperature);
        }

        [TestMethod]
        public void TestValidatingTemp()
        {
            double temperature = 92;

            Assert.ThrowsException<ArgumentException>(() => new FluentCoffeeMaker()
                .ApplyHeat(temperature).ValidateTemperature(h => h < 100 || h > 105));
        }
    }
}
