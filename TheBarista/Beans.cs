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
            get
            {
                return _amountInGrams;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Amount of grams cannot be 0 or lower.");
                }
                else
                {
                    _amountInGrams = value;
                }
            }
        }

        public Beans(CoffeeSort sort, int amountInGrams)
        {
            this.sort = sort;
            this.AmountInGrams = amountInGrams;
        }
    }
}
