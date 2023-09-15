using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Onvezeto
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Auto> autok = new List<Auto>();
            StreamReader sr = new StreamReader(
                path: @"..\..\..\src\autoadat.txt",
                encoding: Encoding.UTF8);


            //2.Feladat
            Console.WriteLine("2.Feladat: Fajl beolvasva");
            while (!sr.EndOfStream)
            {
                autok.Add(new Auto(sr.ReadLine()));
            }
            Console.WriteLine();


            //3.Feladat
            int leggyorsabb = autok.Min(auto => auto.gyorsulas);

            foreach (Auto auto in autok)
            {
                if (auto.gyorsulas == leggyorsabb)
                {
                    Console.WriteLine($"3.Feladat: {auto.azonosito} {auto.teljeseitmeny} {auto.tomeg} {auto.gyorsulas} {auto.beavatkozas}");
                }
                else { }
            }
            Console.WriteLine();


            //4.Feladat
            int onallotlan = autok.Max(auto => auto.beavatkozas);

            foreach (Auto auto in autok)
            {
                if (auto.beavatkozas == onallotlan)
                {
                    Console.WriteLine($"4.Feladat: {auto.azonosito}");
                }
            }
            Console.WriteLine();

            //int onallo = 0;
            //foreach (var auto in autok)
            //{
            //    if (onallo < auto.beavatkozas)
            //    {
            //        onallo = auto.beavatkozas;
            //    }
            //}
            //foreach (Auto auto in autok)
            //{
            //    if (auto.beavatkozas == onallo)
            //    {
            //        Console.WriteLine($"4.Feladat: {auto.azonosito}");
            //    }
            //}


            //5.Feladat
            double atlagtomeg = autok.Average(auto => auto.tomeg);
            Console.WriteLine("5.Feladat: {0}", Math.Round(atlagtomeg, 3));
            Console.WriteLine();


            //6.Feladat
            int id = 1;

            using (StreamWriter sw = new StreamWriter(@"..\..\..\src\new_file.txt"))
            {
                foreach (Auto auto in autok)
                {
                    sw.WriteLine($"{id} {auto.tomeg * 1000}kg");
                    id++;
                }
            }
            Console.WriteLine("6.Feladat: Fajl kiirva");
            Console.ReadLine();
        }
    }
}
