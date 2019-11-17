using System;

namespace LP_06
{
    interface IBouquet
    {
        void Print();
        float TotalСost();
        Flower[] ColorSort(string color);
    }
    partial class BouquetOfFlowers:IBouquet
    {
        public float TotalСost()
        {
            float temp = 0;
            for (int i = 0; i < bouquet.Length; i++)
            {
                temp += this.bouquet[i].properties.price;
            }
            return temp;
        }

        public BouquetOfFlowers(params Flower[] flower)
        {
            bouquet = new Flower[flower.Length];
            for (int i = 0; i < flower.Length; i++)
            {
                this.bouquet[i] = flower[i];
            }
        }
        public Flower[] Bouquets
        {
            get{ return this.bouquet; }
            set{ this.bouquet = value; }
        }

        public void Print()
        {
            for (int i = 0; i < bouquet.Length; i++)
            {
                Console.WriteLine(bouquet[i]);
            }
        }

        public Flower[] ColorSort(string color)
        {
            int counter = 0;

            for (int i = 0; i < bouquet.Length; i++)
            {
                if (bouquet[i].properties.color == color)
                    counter++;
            }

            Flower[] temp = new Flower[counter];

            for (int i = 0, j = 0; i < bouquet.Length; i++)
            {
                if (bouquet[i].properties.color == color)
                    temp[j++] = bouquet[i];
            }
            return temp;
        }
    }

}