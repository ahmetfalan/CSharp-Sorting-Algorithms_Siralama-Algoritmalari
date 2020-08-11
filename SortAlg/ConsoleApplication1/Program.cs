using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        private static void BubleSort(int[] dizi)
        {
            int gecici;
            for (int j = 0; j <= dizi.Length - 2; j++)
            {
                for (int i = 0; i <= dizi.Length - 2; i++)
                {
                    if (dizi[i] > dizi[i + 1])
                    {
                        gecici = dizi[i + 1];
                        dizi[i + 1] = dizi[i];
                        dizi[i] = gecici;
                    }
                }
            }
        }
        
        private static void SelectionSort(int[] dizi)
        {
            int gecici, enkucuk;
            for (int i = 0; i < dizi.Length - 1; i++)
            {
                enkucuk = i;
                for (int j = i + 1; j < dizi.Length; j++)
                {
                    if (dizi[j] < dizi[enkucuk])
                    {
                        enkucuk = j;
                    }
                }
                gecici = dizi[enkucuk];
                dizi[enkucuk] = dizi[i];
                dizi[i] = gecici;
            }
        }

        private static void QuickSort(int[] sayilar, int sol, int sag)
        {
            int i = sol;
            int j = sag;

            var ortanokta = sayilar[(sol + sag) / 2];

            while (i <= j)
            {
                while (sayilar[i] < ortanokta)
                    i++;

                while (sayilar[j] > ortanokta)
                    j--;

                if (i <= j)
                {
                    var tmp = sayilar[i];
                    sayilar[i] = sayilar[j];
                    sayilar[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (sol < j)
                QuickSort(sayilar, sol, j);


            if (i < sag)
                QuickSort(sayilar, i, sag);
        }


        static public void MergeMethod(int[] sayilar, int sol, int orta, int sag)
        {
            int[] gecici = new int[25];
            int i, sol_, sayi, gecici_;
            sol_ = (orta - 1);
            gecici_ = sol;
            sayi = (sag - sol + 1);
            while ((sol <= sol_) && (orta <= sag))
            {
                if (sayilar[sol] <= sayilar[orta])
                    gecici[gecici_++] = sayilar[sol++];
                else
                    gecici[gecici_++] = sayilar[orta++];
            }
            while (sol <= sol_)
                gecici[gecici_++] = sayilar[sol++];
            while (orta <= sag)
                gecici[gecici_++] = sayilar[orta++];
            for (i = 0; i < sayi; i++)
            {
                sayilar[sag] = gecici[sag];
                sag--;
            }
        }
        static public void SortMethod(int[] sayilar, int sol, int sag)
        {
            int orta;
            if (sag > sol)
            {
                orta = (sag + sol) / 2;
                SortMethod(sayilar, sol, orta);
                SortMethod(sayilar, (orta + 1), sag);
                MergeMethod(sayilar, sol, (orta + 1), sag);
            }
        }

        static void Main(string[] args)
        {
            int[] dizi = new int[20]; // 20 elemanlı dizi oluşturuldu.
            Random rnd = new Random();

            for (int i = 0; i < dizi.Length; i++)
            {
                dizi[i] = rnd.Next(1, 100);
            }
            Console.WriteLine("Belirlenen dizi: ");
            foreach (var item in dizi)
            {
                Console.Write(" " + item);
            }
            Console.WriteLine();

            Console.WriteLine("Bubble Sort için:     1 ");
            Console.WriteLine("Selection Sort için:  2 ");
            Console.WriteLine("Quick Sort için:      3 ");
            Console.WriteLine("Merge Sort için:      4 ");
            Console.WriteLine("Çıkış için           -1 ");
            Console.WriteLine("------------------------");

            string islem = "";
            while (islem != "-1")
            {
                Console.Write("Seçim yap: ");
                islem = Console.ReadLine();

                if (islem == "1")
                {
                    BubleSort(dizi);
                    Console.WriteLine("Buble Sort: ");
                    foreach (var item in dizi)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                }
                else if (islem == "2")
                {
                    SelectionSort(dizi);
                    Console.WriteLine("Selection Sort: ");
                    foreach (var item in dizi)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                }
                else if (islem == "3")
                {
                    QuickSort(dizi, 0, dizi.Length - 1);
                    Console.WriteLine("Quick Sort: ");
                    foreach (var item in dizi)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                }
                else if (islem == "4")
                {
                    SortMethod(dizi, 0, dizi.Length - 1);
                    Console.WriteLine("Merge Sort: ");
                    foreach (var item in dizi)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                }
                else if (islem == "-1")
                {
                    Console.WriteLine("Çıkış yapıldı. Bu ekranı kapatmak için herhangi bir tuşa basmanız yeterli.");

                }
                else if (islem == "")
                {
                    Console.WriteLine("Seçim yapılmadı. ");
                }
                else
                {
                    Console.WriteLine("Hatalı seçim yapıldı. ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
