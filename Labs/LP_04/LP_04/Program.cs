using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Класс - Строка. Дополнительно перегрузить следующие операции: < - удаление всех символов равных заданному;
 * + удаление нечетных символов; != сравнение длин строк; true -  проверка на знаки препинания Методы расширения: 
 * 1) Проверка наличия в строке заданных символов 
 * 2) Удаление чисел их строки */

namespace LP_04
{
    public class String1
    {
        public readonly DateTime creationTime;

        char[] strArr;
        public char[] Arr
        {
            get { return strArr; }
        }

        int length;
        int maxSize;

        public int Length
        {
            get { return length; }
        }
       
        public String1(string inputStr)
        {
            maxSize = 100;
            strArr = new char[maxSize];
            for (int i = 0; i < inputStr.Length; i++)
                strArr[i] = inputStr[i];
            length = inputStr.Length;
            this.creationTime = DateTime.Now;
        }
        public String1()
        {
            maxSize = 100;
            strArr = new char[maxSize];
            this.creationTime = DateTime.Now;
        }

        public char this[int index]
        {
            get
            {
                return strArr[index];
            }
            set
            {
                strArr[index] = value;
            }
        }

        public static String1 operator <(String1 string1, char a)
        {
            String1 temp = new String1();
            for (int i = 0, j = 0; i < string1.length; i++)
                if (string1[i] != a)
                {
                    temp[j++] = string1[i];
                    temp.length++;
                }

            return temp;
        }
        public static String1 operator >(String1 string1, char a)
        {
            String1 temp = new String1();
            for(int i=0, j=0; i<string1.length; i++)
                if(string1[i]!=a)
                {
                    temp[j++] = string1[i];
                    temp.length++;
                }

            return temp;
        }
        public static String1 operator ++(String1 string1)
        {
            String1 temp = new String1();

            for (int i = 0, j = 0; i < string1.length; i++)
                if (i % 2!=0)
                {
                    temp[j++] = string1[i];
                    temp.length++;
                }

            return temp;
        }
        public static string operator !=(String1 string1, String1 string2)
        {
            if (string1.length < string2.length)
                return "Первая строка меньше второй.";
            else if (string1.length > string2.length)
                return "Первая строка больше второй.";
            else return "Строки равны.";
        }
        public static string operator ==(String1 string1, String1 string2)
        {
            if (string1.length < string2.length)
                return "Первая строка меньше второй.";
            else if (string1.length > string2.length)
                return "Первая строка больше второй.";
            else return "Строки равны.";
        }
        public static bool operator true(String1 string1)
        {
            for (int i = 0; i < string1.length; i++)
            {
                if (string1[i] == '.' || string1[i] == ',' || string1[i] == ':' || string1[i] == ';' || string1[i] == '!' || string1[i] == '?')
                    return true;
            }
            return false;

        }
        public static bool operator false(String1 string1)
        {
            for (int i = 0; i < string1.length; i++)
            {
                if (string1[i] == '.' || string1[i] == ',' || string1[i] == ':' || string1[i] == ';' || string1[i] == '!' || string1[i] == '?')
                    return true;
            }
            return false;
        }

        public class Owner
        {
            public int Id;
            public string Name;
            public string organization;
            public Owner()
            {
                Id = 1;
                Name = "";
                organization = "";
            }
        }
    }
    public static class Test
    {
        public static bool Test1(this String1 string1,char a)
        {
            for (int i = 0; i < 50; i++)
            {
                if (string1[i] == a)
                    return true;
            }
            return false;
        }
        public static bool Test2(this String1 string1, char a)
        {
            for (int i = 0; i < 50; i++)
            {
                if (string1[i] >30 && string1[i] < 40)
                    return true;
            }
            return false;
        }
    }
    public static class StatisticOperation
    {
        public static void Sum(this String1 a, String1 b)
        {
            String1 temp = new String1();
            int i = 0, j = 0; 
            while(a[i]!='\0')
            {
                temp[i] = a[i];
                i++;
            }
            while (b[j] != '\0')
            {
                temp[i] = b[j++];
                i++;
            }
            Console.WriteLine(temp.Arr);
        }

        public static void Raznoct(this String1 a, String1 b)
        {
            Console.WriteLine(Math.Abs(a.Length - b.Length));
        }
        public static void TAsk3(this String1 a)
        {
            Console.WriteLine(a.Length);
        }

        public static bool Test1(this string str, char a)
        {
            for (int i = 0; i < 50; i++)
            {
                if (str[i] == a)
                    return true;
            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String1 a = new String1("xxzxxz");
            a = a < 'z'; 
            String1 b = new String1("123456");
            //a[0] = '2';
            b++;
            Console.WriteLine(a != b);
            String1 c = new String1("123x.456"); //. , : ; ! ? -
            if (c)
                Console.WriteLine("Есть знак препинания.");
            else Console.WriteLine("Нет знака препинания.");

            Console.WriteLine(a.Test1('x'));
            Console.WriteLine(a.Test1('b'));
            Console.WriteLine(a.Test2('a'));
            Console.WriteLine(a.Test2('b'));

            String1.Owner a1 = new String1.Owner() { Id = 2, Name = "n", organization = "mn" };
            Console.WriteLine(a.creationTime);

            String1 test111 = new String1("abcde");
            String1 test222 = new String1("fgh");

            test111.Sum(test222);
            test111.Raznoct(test222);
            test111.TAsk3();
            
        }
    }


}
