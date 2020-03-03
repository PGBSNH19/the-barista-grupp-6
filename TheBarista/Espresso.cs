using System;
using System.Collections.Generic;
using System.Text;

namespace TheBarista
{
    public class Espresso
    {
        private Bean bean;
        private CoffeeSorts coffeeSort;
        //Remove this, put this in Cup-class instead
        private int amountWater = 0;
        private ICupSize cup;
        private double pricePerCl;

        public Bean GetBean()
        {
            return this.bean;
        }

        public CoffeeSorts GetCoffeeSort()
        {
            return this.coffeeSort;
        }

        public int GetAmountWater()
        {
            return this.amountWater;
        }

        public ICupSize GetCupSize()
        {
            return this.cup;
        }


        public void AddWater(int amountWater)
        {
            this.amountWater += amountWater;
        }

        public void SetBean(Bean bean)
        {
            this.bean = bean;
        }

        public void SetCoffeeSort(CoffeeSorts sort)
        {
            this.coffeeSort = sort;
        }

        public void SetCupSize(ICupSize cup)
        {
            this.cup = cup;
        }

        public double getPricePerCl()
        {
            return this.pricePerCl;
        }

    }
}
