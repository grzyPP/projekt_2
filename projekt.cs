using System;
using System.Numerics;
namespace LiczbyPierwsze
{
    class Program
    {
        static ulong DivsNum;

        static bool AlgorytmPrzykładowy(BigInteger Num)
        {
            if (Num < 2) return false;
            else if (Num < 4) return true;
            else if (Num % 2 == 0) return false;
            else for (BigInteger u = 3; u < Num / 2; u += 2)
                    if (Num % u == 0) return false;
            return true;
        }
        static bool AlgorytmPrzykładowyInstrumentacja(BigInteger Num)
          {
            DivsNum = 1; // Zacznij liczyć od 1, to głupie ale w tylko wtedy zgadza się liczba iteracji z tym co było w tych PDF'ach
            if (Num< 2) return false;
            else if (Num< 4) return true;
            else if (Num % 2 == 0)
            {
                DivsNum++;
                return false;
            }
            else for (BigInteger u = 3; u<Num / 2; u += 2)
                {
                    DivsNum++;
                    if (Num % u == 0) return false;
                }
            return true;
        }

           static bool AlgorytmLepszy(BigInteger Num)
           {
            if (Num % 2 == 0)
                return (Num == 2);
            for (BigInteger i =3 ; i*i <= Sqrt(Num); i+=2) //Sqrt do BigInteger musisz albo napisać albo znaleźć w necie :D ja poszedłem tą drugą drogą. I to będzie algoytm "lepszy". Math nie radzi sobie z BigInteger jakby co. Mozesz ew. się pobawić z Int64 ale mieliśmy zostać przy tym typie.
            {
                DivsNum++;
                if (Num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        /*   static bool AlgorytmLepszyInstrumentacja(BigInteger Num)
           {
            //tu instrumentacja do tego co powyej

    }
        static bool AlgorytmJeszczeLepszy(BigInteger Num)
           {
            BigInteger i, p, lp, k, d, kp, dp; //nie do końca rozumiem po co Ci a tyle zmiennych w tym miejscu.
            https://www.geeksforgeeks.org/sieve-of-eratosthenes/
            ^^ tu masz dobrą implementację sita erastotenesa. U siebie rozbiłem to na dwie metody. Jedną robię sito a drugą uzywam go do tablicy z liczbami.

            Mniej więcej tak:
            jako num podawałem pierwiastek z liczby początkowej, zeby nie wypasc za inta
            static List<BigInteger> MakeSieve(int Num) {
                List<bool> is_prime = new List<bool>(); //dynamiczna kolekcja jest latwiejsza w obsludze
                for ktory wypelnia tablice

                pozniej recznie oznaczasz 0, 1, 2 jako false po nie sa pierwsze

                for z linku
            }

            druga metoda to prawie przeklejka z pozostałych.


            bool t;

            DivsNum = 1;

            lp = 0;
            k = 1; d = -1;

            while (lp < Num)
            {
                t = true;
                p = 6 * k + d;


                kp = 1; dp = -1; i = 5;

                while (i * i <= p)
                {

                    if (p % i == 0)
                    {
                        t = false;
                        break;
                    }
                    dp = -dp;
                    if (dp == -1) kp++;
                    i = 6 * kp + dp;

                }

                if (t)
                {
                    Console.WriteLine("{0} | {1} | {2}", Num, t, DivsNum);
                    lp = Num;
                }
                d = -d;
                if (d == -1) k++;
            }



            return false;


        }

        /*   static bool AlgorytmJeszczeLepszyInstrumentacja(BigInteger Num)
           {

    }

       */
        static void Main(string[] args)
        {
            BigInteger[] PrimeNums = new BigInteger[]{ 101, 1009, 10091, 100913, 1009139, 10091401, 100914061,
            1009140611, 10091406133, 100914061337, 1009140613399 };
            // testy



            foreach (BigInteger n in PrimeNums)
            {
                DivsNum = 1;
                Console.WriteLine("{0} | {1} | {2}", n, AlgorytmLepszy(n),DivsNum); //PS ostatnia liczba z tym alorytmem liczyła mi się 50h
                //AlgorytmJeszczeLepszy(n);
            }

        }
    }
}
