using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Создать несколько объектов-цветов. Собрать Букет.
 * Определить его стоимость. Провести сортировку цветов
 * в букете на основе любого параметра. Найти цветок в
 * букете, соответствующий заданному цвету.  */

namespace LP_06
{
    public enum FlowerName
    {
        rose=1,
        daisy,
        lily,
        tulip
    }
    public struct FlowerProperties
    {
        public float price;
        public float lenght;
        public int numberOfPetals;
        public string color;
        public FlowerName name;

        public FlowerProperties(float price, float lenght, int numberOfPetals, string color, FlowerName flowerName)
        {
            this.price = price;
            this.lenght = lenght;
            this.numberOfPetals = numberOfPetals;
            this.color = color;
            this.name = flowerName;
        }
    }
    public class Flower:IComparable
    {
        public FlowerProperties properties;

        public Flower()
        {
            properties = new FlowerProperties();
        }
        public Flower(float price, float lenght, int numberOfPetals, string color, FlowerName flowerName)
        {
            properties = new FlowerProperties(price, lenght, numberOfPetals, color, flowerName);
        }

        public int CompareTo(Object obj)
        {
            Flower temp = obj as Flower;
            return this.properties.price.CompareTo(temp.properties.price);
        }
    }
    public sealed class Rose : Flower       //роза
    {
        public Rose()
        {
            properties = new FlowerProperties(2.5f, 0.7f, 25, "red", FlowerName.rose);
        }
        public override string ToString()
        {
            return $"Роза \t\tЦена: {properties.price}, \tдлина: {properties.lenght}, \tкол-во лепестков: {properties.numberOfPetals}, \tцвет: {properties.color}, \tназвание: {properties.name}";
        }
    }
    public sealed class Daisy : Flower       //ромашка
    {
        public Daisy()
        {
            properties = new FlowerProperties(1f, 1f, 30, "white", FlowerName.daisy);
        }
        public override string ToString()
        {
            return $"Ромашка \t\tЦена: {properties.price}, \tдлина: {properties.lenght}, \tкол-во лепестков: {properties.numberOfPetals}, \tцвет: {properties.color}, \tназвание: {properties.name}";
        }
    }
    public sealed class Lily : Flower       //лилия
    {
        public Lily()
        {
            properties = new FlowerProperties(5f, 1f, 5, "white", FlowerName.lily);
        }
        public override string ToString()
        {
            return $"Лилия \t\tЦена: {properties.price}, \tдлина: {properties.lenght}, \tкол-во лепестков: {properties.numberOfPetals}, \tцвет: {properties.color}, \tназвание: {properties.name}";
        }
    }
    public sealed class Tulip : Flower       //тюльпан
    {
        public Tulip()
        {
            properties = new FlowerProperties(1.5f, 0.5f, 5, "red", FlowerName.tulip);
        }
        public override string ToString()
        {
            return $"Тюльпан \t\tЦена: {properties.price}, \tдлина: {properties.lenght}, \tкол-во лепестков: {properties.numberOfPetals}, \tцвет: {properties.color}, \tназвание: {properties.name}";
        }
    }

    partial class BouquetOfFlowers:IBouquet
    {
        public Flower[] bouquet;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Flower rose = new Rose();
            Flower daisy = new Daisy();
            Flower lily = new Lily();
            Flower tulip = new Tulip();

            BouquetOfFlowers Bouquet1 = new BouquetOfFlowers(rose, daisy, lily, tulip);
            Console.WriteLine(Bouquet1.TotalСost());

            Array.Sort(Bouquet1.bouquet);

            Flower[] a1 = Bouquet1.ColorSort("red");
        }
    }
}
