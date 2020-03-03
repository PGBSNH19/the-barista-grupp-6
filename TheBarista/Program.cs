using System;

namespace TheBarista
{
    // Spy: @Norshiervani, other people used string arrays to store these
    // we use enum instead.
    public enum CoffeeSorts {
        RISTRETTO,
        CLASSIC
    }

    // Spy: @Norshiervani, I saw that people used interface, unsure if they
    // did it like this.
    public interface ICupSize
    {
        float Volume {get; set;}
        double Price {get; set;}
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Espresso Group 6!");
            Console.WriteLine();
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
