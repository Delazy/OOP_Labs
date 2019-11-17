using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*                  Двигатель - интерфейс
                Транспортное средство - абс класс
          Автомобиль                Вагон - абс класс
                                Экспресс, Поезд. */

namespace LP_05
{
    interface IEngine
    {
        int Power { get; set; }
        void DoWrrr();
    }
    abstract class Transport : IEngine
    {
        int power;
        public int Power { get { return power; } set { power = value; } }

        void IEngine.DoWrrr()
        {
            Console.WriteLine("WRRR!");
        }  

        public virtual void WhoIAm()
        {
            Console.WriteLine("I am Transport ");
        }

    }

    class Car : Transport
    {
        public override void WhoIAm()
        {
            Console.WriteLine("I am Car ");
        }
        public override string ToString()
        {
            return ($"Тип: {this.GetType()}, Мощность: {this.Power}");
        }
    }

    abstract class Vagon : Transport
    {

    }

    class Train : Vagon
    {
        public override string ToString()
        {
            return ($"Тип: {this.GetType()}, Мощность: {this.Power}");
        }
    }

    sealed class FastTrain : Vagon
    {
        public override bool Equals(object obj)
        {
            FastTrain temp = obj as FastTrain;
            if (temp == null)
                return false;
            if (temp.Power == this.Power)
                return true;
            else return false;
        }
        public override string ToString()
        {
            return ($"Тип: {this.GetType()}, Мощность: {this.Power}");
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    // /////////////////////////////////

    interface ICloneable { void DoClone(); }
    abstract class BaseClone { public abstract void DoClone(); }
    class UserClass : BaseClone, ICloneable
    {
        public override void DoClone()
        {
            Console.WriteLine("Я абстрактный класс!");
        }
        void ICloneable.DoClone()
        {
            Console.WriteLine("I Am Interface!");
        }
    }

    static class Printer
    {
        static void IAmPrinting(IEngine engine)
        {
            Car temp = engine as Car;
            if (temp != null) { temp.ToString(); }
            Train temp1 = engine as Train;
            if (temp1 != null) { temp1.ToString(); }
            FastTrain temp2 = engine as FastTrain;
            if (temp2 != null) { temp2.ToString(); }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Car T = new Car();
            T.WhoIAm();

            UserClass U = new UserClass();
            U.DoClone();
            ICloneable IU = U;
            IU.DoClone();

            if(T is Car)
                Console.WriteLine("I Am Car!");
            else
                Console.WriteLine("I Am Not a Car!");

            Transport TUser = T as Transport;

        }
    }
}
