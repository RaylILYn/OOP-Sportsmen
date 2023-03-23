using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Sportsmen
    {
        // Закрытые поля:  фамилия, название группы, успеваемость (массив)
        string fam;
        int[] mesto;
        string god;

        // Конструктор с параметрами
        public Sportsmen(string ffnam, string god, int n)
        { mesto = new int[n]; fam = ffnam; this.god = god; }

        // Свойство "Количество мест меньше заданного" только для чтения
        public int K_mest
        {
            get
            {
                int k = 0;
                foreach (int x in mesto)
                    if (x > 3) k = k + 1;
                {
                    return k;
                }
            }
        }
        // Свойство "Средние занимаемые места" только для чтения
        public double Sr_mesto
        {
            get
            {
                double S = 0;
                foreach (int x in mesto)
                    S = S + x;
                return S / mesto.Length;
            }
        }
        // Свойство доступа к полю fam- "Фамилия спортсмена"
        public string Fam
        {
            get
            { return fam; }
            set { fam = value; }

        }
        // Свойство доступа к полю god- "Год рождения"
        public string God
        {
            get
            { return god; }
            set
            { god = value; }

        }
        // Метод ввода мест спортсменов
        public void vvod_mest()
        {
            Console.WriteLine("Введите места в количестве ");
            for (int i = 0; i < mesto.Length; i++)
                mesto[i] = Convert.ToInt32(Console.ReadLine());
        }

        // Индексатор только для чтения для доступа к местам спортсмена
        public int this[int i]
        {
            get
            {
                if (i < 0 || i >= mesto.Length)
                    throw new Exception(" Недопустимый индекс");
                else return mesto[i];
            }
        }

        public void vyvod_mest()
        {
            Console.WriteLine("\nМеста, занимаемые спортсменом: " + fam);
            for (int i = 0; i < mesto.Length; i++)
                Console.Write(mesto[i] + " ");
        }

        //Свойство "Количество оценок за сессию"
        public int Kol_ocenok
        {
            get
            { return mesto.Length; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Sportsmen[] st;

            // Ввод информации о спортсменах в массив объектов класса Sportsmen
            Console.WriteLine("Сколько спортсменов?");
            int m = int.Parse(Console.ReadLine());
            st = new Sportsmen[m];
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine("Задайте фамилию, год рождения и количество соревнований");
                st[i] = new Sportsmen(Console.ReadLine(), Console.ReadLine(), int.Parse(Console.ReadLine()));
                st[i].vvod_mest();

            }
            Console.WriteLine("");
            //Вывод списка спортсменов с указанием их группы

            foreach (Sportsmen x in st)
            {
                Console.WriteLine(x.Fam + "   " + x.God + "г.   " + x.Sr_mesto + " место");
            }
            for (int i = 0; i < m; i++)
            {
                st[i].vyvod_mest();
            }

            //Определение количества мест
            Console.WriteLine("\n\nОпределение списка спортсменов с местами ниже 3 хотя бы один раз:");
            try
            {
                foreach (Sportsmen s in st)
                    if (s.K_mest > 0)
                        Console.WriteLine(s.Fam + "   " + s.God + "г.   ");
            }
            catch
            {
                Console.WriteLine("\nТаких спортсменов нет");
            }
            Console.ReadKey();
        }
    }
}