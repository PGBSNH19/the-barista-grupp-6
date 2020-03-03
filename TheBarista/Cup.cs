using System;
using System.Collections.Generic;
using System.Text;

namespace TheBarista
{
    public class Cup
    {
        private ICupSize cupSize;
        private Espresso espresso;

        public Cup(ICupSize cupSize, Espresso espresso)
        {
            this.cupSize = cupSize;
            this.espresso = espresso;
        }

        public double GetTotalPrice()
        {
            return this.cupSize.Volume * espresso.getPricePerCl();
        }
    }
}
