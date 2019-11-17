using System;

namespace LP_06
{
    partial class BouquetOfFlowers
    {
        public Flower[] ColorSort(string color)
        {
            int counter = 0;

            for (int i = 0; i < Bouquet.Length; i++)
            {
                if (Bouquet[i].properties.color == color)
                    counter++;
            }

            Flower[] temp = new Flower[counter];

            for (int i = 0, j = 0; i < Bouquet.Length; i++)
            {
                if (Bouquet[i].properties.color == color)
                    temp[j++] = Bouquet[i];
            }
            return temp;
        }
    }

}