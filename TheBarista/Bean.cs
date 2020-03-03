using System;
using System.Collections.Generic;
using System.Text;

namespace TheBarista
{
    public class Bean
    {
        private string Country { get; set; }
        private int Strength { get; set; }
        private bool Fairtrade { get; set; }
        private bool Ecologic { get; set; }
        BeanType beantype { get; set; }

        public string GetCountry()
        {
            return this.Country;
        }

        public int GetStrength()
        {
            return this.Strength;
        }

        public bool GetFairtrade()
        {
            return this.Fairtrade;
        }

        public bool GetEcologic()
        {
            return this.Ecologic;
        }

        public BeanType GetBeanType()
        {
            return this.beantype;
        }

        public void SetCountry(string country)
        {
            this.Country = country;
            Console.WriteLine("Bean is from " + country);
        }

        public void SetStrength(int strength)
        {
            this.Strength = strength;
            Console.WriteLine("This bean is " + strength + "/5");

        }

        public void SetFairtrade(bool fairtrade)
        {
            this.Fairtrade = fairtrade;
            if (fairtrade)
            {
                Console.WriteLine("this bean is fairtrade");
            }
            else
            {
                Console.WriteLine("this bean is not fairtrade");
            }
        }

        public void SetEcologic(bool ecologic)
        {
            this.Ecologic = ecologic;
            if (ecologic)
            {
                Console.WriteLine("this bean is ecologic");
            }
            else
            {
                Console.WriteLine("this bean is not ecologic");
            }
        }

        public void SetBeanType(BeanType beanType)
        {
            this.beantype = beanType;
            Console.WriteLine("beantyp is" + beantype);
        }

        public enum BeanType
        {
            ROBUSTA,
            ARABICA
        }
    }
}
