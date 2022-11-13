using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tengeres_feladat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const char TENGER_JEL = '*';
            const char SZIGET_JEL = 'O';
            char[,] tenger = new char[14, 60];
            Alaphelyzet(TENGER_JEL, tenger);
            Megjelenit(tenger);
            SzigeteketRak(SZIGET_JEL, tenger, 100);
            Megjelenit(tenger);
            //1.feladat
            //Hány sziget van a tengeren?
            Console.WriteLine(SzigetekSzama(tenger));

            //2. feladat
            //Hány sziget van tenger szélén?
            Console.WriteLine(SzigetekTengerszelen(tenger));

            //3. feladat
            //A megadott koordinátájú szigetnek van-e közvetlen szomszédja? /alul, felül, mellete/
            if (VanSzomszed(tenger,10,10))
            {
                Console.WriteLine("Van kozvetlen szomszed");
            }
            else
            {
                Console.WriteLine("Nincs kozvetlen szomszed");
            }
            
        }

        static int SzigetekSzama(char[,] tenger)
        {
            int szamlalo = 0;
            for (int sor = 0; sor < tenger.Length; sor++)
            {

                for (int oszlop = 0; oszlop < tenger.Length + 1; oszlop++)
                {
                    if (tenger[sor, oszlop] == 'O')
                    {
                        szamlalo++;
                    }

                }
            }
            return szamlalo;
        }
        static int SzigetekTengerszelen(char[,] tenger)
        {
            int szamlalo = 0;
            for (int sor = 0; sor < tenger.Length; sor++)
            {
                for (int oszlop = 0; oszlop < tenger.Length; oszlop++)
                {
                    if (tenger[sor, oszlop] == 'X')
                    {
                        if ((sor == 0 || tenger[sor - 1, oszlop] == 'O') && (oszlop == 0 || tenger[sor, oszlop - 1] == 'O')) szamlalo++;
                    }
                }
            }
            return szamlalo;
        }
        static bool VanSzomszed(char[,] tenger, int x, int y)
        {
            bool szomszed = false;

            if (tenger[x + 1, y] == 'O' || tenger[x - 1, y] == 'O' || tenger[x, y + 1] == 'O' || tenger[x, y - 1] == 'O' || tenger[x + 1, y + 1] == 'O' || tenger[x - 1, y - 1] == 'O')
            {
                szomszed = true;
            }
            return szomszed;
        }



        static void SzigeteketRak(char SZIGET_JEL, char[,] terkep, int darab)
        {
            Random vel = new Random();
            for (int i = 0; i < darab; i++)
            {
                int sorIndex = vel.Next(terkep.GetLength(0));
                int oszlopIndexe = vel.Next(terkep.GetLength(1));
                terkep[sorIndex, oszlopIndexe] = SZIGET_JEL;
            }
        }

        static void Alaphelyzet(char TENGER_JEL, char[,] terkep)
        {
            for (int sorIndex = 0; sorIndex < terkep.GetLength(0); sorIndex++)
            {
                for (int oszlopIndexe = 0; oszlopIndexe < terkep.GetLength(1); oszlopIndexe++)
                {
                    terkep[sorIndex, oszlopIndexe] = TENGER_JEL;
                }
            }
        }

        static void Megjelenit(char[,] terkep)
        {
            Console.Clear();
            for (int sorIndex = 0; sorIndex < terkep.GetLength(0); sorIndex++)
            {
                for (int oszlopIndexe = 0; oszlopIndexe < terkep.GetLength(1); oszlopIndexe++)
                {
                    Console.Write(terkep[sorIndex, oszlopIndexe]);
                }
                Console.WriteLine();
            }
        }

    }
}
