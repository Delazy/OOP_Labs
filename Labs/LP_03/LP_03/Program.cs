using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Создать класс Airline: Пункт назначения, Номер рейса, Тип самолета, Время вылета, Дни недели.
 * Свойства и конструкторы должны обеспечивать проверку корректности.   Создать массив объектов.
 * Вывести: 
 * a)  список рейсов для заданного пункта назначения; 
 * b)  список рейсов для заданного дня недели; */

namespace LP_03
{
    partial class Airline
    {
        static int counterOfFlights = 0;

        static Airline()
        {
            int counterOfFlights;
        }  //статический конструктор
        static public int GetCounterOfFlights
        {
            get
            {
                return counterOfFlights;
            }
        }

        static public void FuncGetCounterOfFlights()
        {
            Console.WriteLine("\nКоличество проданных билетов: " + Airline.GetCounterOfFlights);
        }

        string destination;
        public string Destination
        {
            get
            {
                return destination;
            }
            set
            {
                destination = value;
            }
        }
        int number;
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                if(value>0)
                {
                    number = value;
                }
            }
        }
        const string type = "Business";
        public string Type
        {
            get
            {
                return type;
            }
        }
        string time;
        public string Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }
        string day;
        public string Day
        {
            get
            {
                return day;
            }
            set
            {
                if(value == "Monday" || value == "Tuesday" || value == "Wednesday" || value == "Thursday" || value == "Friday" || value == "Saturday" || value == "Sunday")
                {
                    day = value;
                }
                if (value == "Mon" || value == "Td" || value == "Wd" || value == "Th" || value == "Fr" || value == "Sat" || value == "Sn")
                {
                    day = value;
                }
            }
        }
        readonly int id;
        public int Id
        {
            get
            {
                return id;
            }
        }

        public void PrintAirline()
        {
            Console.WriteLine($"Пассажик №{Id} садится на рейс №{Number} {Type}-класс в {Destination} в {Time} ({Day})");
        }  //вывод инфы в консоль

        public Airline(string destination, int number, string time, string day = "Mon")
        {
            this.destination = destination;
            this.number = number;
            this.time = time;
            this.day = day;
            this.id = ++Airline.counterOfFlights;
            PrintAirline();
        }   //конструктор с параметрами(1 по умолчанию)
        public Airline(string destination, int number, string time)
        {
            this.destination = destination;
            this.number = number;
            this.time = time;
            this.id = ++Airline.counterOfFlights;
            PrintAirline();
        }  //конструктор с параметрами
        public Airline()
        {
            this.destination = "Belarus";
            this.number = 1;
            this.time = "12.12";
            this.day = "Mon";
            this.id = Airline.counterOfFlights++;
            PrintAirline();
        } //конструктор без параметров

        static public void PrintArrDest(Airline[] arr)
        {
            Console.WriteLine("\nСортировка по месту прибытия \"ukr\"");

            for(int i=0;i<counterOfFlights;i++)
            {
                if(arr[i].Destination=="ukr")
                {
                    arr[i].PrintAirline();
                }
            }
            Console.WriteLine();
        }   //курсив 1

        static public void PrintArrDay(Airline[] arr)
        {
            Console.WriteLine("\nСортировка по дню отлёта \"Fr\"");

            for (int i = 0; i < counterOfFlights; i++)
            {
                if (arr[i].Day == "Fr")
                {
                    arr[i].PrintAirline();
                }
            }
            Console.WriteLine();
        }    //курсив 2
    }

    partial class Airline
    {
        static public void Function1(ref Airline airline, out string place)
        {
            if(airline.Day=="Mon")
            {airline.Day = "Monday";}
            if (airline.Day == "Td")
            { airline.Day = "Tuesday"; }
            if (airline.Day == "Wd")
            { airline.Day = "Wednesday"; }
            if (airline.Day == "Th")
            { airline.Day = "Thursday"; }
            if (airline.Day == "Fr")
            { airline.Day = "Friday"; }
            if (airline.Day == "Sat")
            { airline.Day = "Saturday"; }
            if (airline.Day == "Sn")
            { airline.Day = "Sunday"; }

            place = airline.Destination;

            airline.PrintAirline();
        }

        public override bool Equals(object obj)
        {
            Airline temp = obj as Airline;
            if (temp == null)
                return false;
            return (temp.Destination == this.Destination && temp.Number == this.Number && temp.Type == this.Type && temp.Time == this.Time && temp.Day == this.Day && temp.Id == this.Id);
        }

        public override string ToString()
        {
            return Airline.GetCounterOfFlights.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Airline[] ArrAirline = new Airline[]   //массив объектов
            {
                new Airline("ukr", 1, "11.16", "Td"),
                new Airline("usa", 2, "00.07", "Mon"),
                new Airline("jup", 3, "13.59", "Wd"),
                new Airline("cin", 4, "12.13", "Fr"),
                new Airline("ukr", 5, "12.00", "Fr"),
            };

            Airline.PrintArrDest(ArrAirline);
            Airline.PrintArrDay(ArrAirline);
            string place = "";
            Airline.Function1(ref ArrAirline[0], out place);
            Console.WriteLine("Он прибудет в " + place);

            Airline.FuncGetCounterOfFlights();

            Airline MyAir1 = new Airline("bel", 1, "12.13", "Td");
            //Airline MyAir2 = new Airline("rus", 1, "00.55", "Wd");
            Airline MyAir3 = new Airline();

            //MyAir1.Equals
            Console.WriteLine(MyAir1.ToString());
            Console.WriteLine("Эквивалентны ли классы MyAir1 и MyAir3? " + MyAir1.Equals(MyAir3));

            var Anonim = new { Destination = "anon", Number = 100, Time = "17.17", Day = "Mon"};

            
        }
    }
}
