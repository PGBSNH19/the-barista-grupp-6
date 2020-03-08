using System;
using System.Collections.Generic;
using System.Text;

namespace TheBarista
{
    public class Beans
    {
        private CoffeeSort sort;
        private int _amountInGrams;
        public int AmountInGrams
        {
            get => _amountInGrams;
            set => _amountInGrams = value;
        }

        public Beans(CoffeeSort sort, int amountInGrams)
        {
            this.sort = sort;
            this.AmountInGrams = amountInGrams;
        }
    }
}
