using System;

namespace TheBarista
{
    // Spy: @Norshiervani, other people used string arrays to store these
    // we use enum instead.
    public enum CoffeeSorts {
        RISTRETTO,
        CLASSIC
    }

    interface ICupSize
    {
        float Volume {get; set;}
        double Price {get; set;}
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Espresso Group 6!");
            Bean bean = new Bean();
            bean.SetCountry("COL");
            bean.SetStrength(5);
            bean.SetEcologic(false);
            bean.SetFairtrade(true);
            bean.SetBeanType(Bean.BeanType.ARABICA);
            Espresso espresso = new Espresso();
            espresso.AddWater(10);
            espresso.SetCoffeeSort(CoffeeSorts.CLASSIC);
            espresso.SetBean(bean);
            espresso.SetCupSize(new MediumCup());
            
        }

    }

    class Espresso
    {
        private Bean bean;
        private CoffeeSorts coffeeSort;
        private int amountWater = 0;
        private ICupSize cup;

        public Bean GetBean() {
            return this.bean;
        }

        public CoffeeSorts GetCoffeeSort() {
            return this.coffeeSort;
        }

        public int GetAmountWater() {
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

    }

    class Bean
    {
        private string Country { get; set; }
        private int Strength { get; set; }
        private bool Fairtrade { get; set; }
        private bool Ecologic { get; set; }
        BeanType beantype {get; set; }

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

    class SmallCup : ICupSize
    {
        public float Volume {get; set;} = 8;
        public double Price {get; set;} = 25;
    }
    
    class MediumCup : ICupSize
    {
        public float Volume {get; set;} = 12;
        public double Price {get; set;} = 30;
    }

    class LargeCup : ICupSize
    {
        public float Volume {get; set;} = 16;
        public double Price {get; set;} = 35;
    }
}
