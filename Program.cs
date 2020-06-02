using System;

namespace KR_KMZI
{
    class Program
    {
        //Брой символи
        const int n = 27;
        // Разрешени символи {M}
        static char[] M = new char[n] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', ' ' };
        // Заместващи символи {N}
        static int[] N = new int[n] { 42, 44, 46, 48, 50, 52, 54, 56, 58, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34, 36, 48, 40, 60, 62, 64, 66, 68 };

        // Шифроване
        static string Encrypt(string P)
        {
            // Инициализиране на C
            string C = string.Empty;
            // Позиция на символа от P в {M}
            int pos;

            // Обхождане на P
            for(int p = 0; p < P.Length; p++)
            {
                for (pos = 0; pos < n; pos++)
                {
                    if (M[pos] == P[p])
                    {
                        // Заместване в C
                        if (p == P.Length - 1)
                        {
                            C += N[pos].ToString();
                        }
                        else
                        {
                            C += N[pos].ToString() + ' ';
                        }
                        break;
                    }
                }
            }
            return C;
        }

        static string Decrypt(string C)
        {
            string P = string.Empty;
            int pos;
            string[] splitted = C.Split(' ');
            int[] numsC = new int[splitted.Length];
            for (int i = 0; i < splitted.Length; i++)
            {
                numsC[i] = int.Parse(splitted[i]);
            }
            foreach(int num in numsC)
            {
                for(pos = 0; pos < n; pos++)
                {
                    if(N[pos] == num)
                    {
                        P += M[pos];
                        break;
                    }
                }
            }
            return P;
        }

        static void Main(string[] args)
        {
            string P;
            string C;
            string P1;
            string choice;
            do
            {
                Console.WriteLine("МЕНЮ");
                Console.WriteLine("1. Шифриране");
                Console.WriteLine("2. Дешифриране");
                Console.WriteLine("0. Изход");


                Console.Write("Въведете своя избор: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            Console.Write("Въведете P: ");
                            P = Console.ReadLine();
                            C = Encrypt(P.ToUpper());
                            Console.WriteLine("Шифриране - C: " + C);
                            Console.WriteLine();    
                            break;
                        }
                    case "2":
                        {
                            Console.Write("Въведете C: ");
                            C = Console.ReadLine();
                            P1 = Decrypt(C);
                            Console.WriteLine("Дешифриране - P: " + P1);
                            Console.WriteLine();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            } while (choice != "0");
        }
    }
}
