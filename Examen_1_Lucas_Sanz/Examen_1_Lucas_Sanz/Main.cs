using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Examen_1_Lucas_Sanz
{
    public class Juego_Barcos
    {
        public static void Main(string[] args)
        {
            Console.Write("Introduzca tamaño de mapa de juego: ");
            int N = Convert.ToInt32(Console.ReadLine());

            Console.Write("Introduzca número de barcos (máximo {0}): ", N);
            int tamaño = Convert.ToInt32(Console.ReadLine());
            while(tamaño > N)
            {
                Console.Write("Tamaño máximo {0}, introduzca número válido: ", N);
                tamaño = Convert.ToInt32(Console.ReadLine());
            }

            juegoBarcos(N, crearBarcos(tamaño, N));            
        }

        public static void juegoBarcos(int N, int[] barcos)
        {
            int[,] mapa_juego = new int[N,N];
            mapa_juego = rellenarMatriz(mapa_juego);
            imprimirMatriz(mapa_juego);
            

            Array.Sort(barcos);
            Array.Reverse(barcos);

            mapa_juego = bucleBarcos(barcos, mapa_juego);
        }
        public static int[,] bucleBarcos(int[] barcos, int[,] mapa_juego)
        {
            Boolean[] valido = new bool[barcos.Length];
            int cont = 0;

            foreach (int i in barcos)
            {
                valido[cont] = false;

                (valido[cont], mapa_juego) = checkPosiciones(mapa_juego, i);

                cont++;
            }
            foreach (Boolean val in valido)
            {
                if (!val)
                {
                    mapa_juego = rellenarMatriz(mapa_juego);
                    mapa_juego = bucleBarcos(barcos, mapa_juego);
                }
            }
            
            return mapa_juego;
        }
        public static (Boolean, int[,]) checkPosiciones(int[,] mapa, int barco)
        {
            Boolean valido = true;
            Random rnd = new Random();
            int x;
            int y;
            do
            {
                x = rnd.Next(0, mapa.GetLength(0));
                y = rnd.Next(0, mapa.GetLength(0));
            } while (mapa[x, y] == 1);

            // CHECK DCHA
            if ((x + barco) < mapa.GetLength(0))
            {
                for (int i = x; i < barco; i++)
                {
                    if (mapa[i, y] == 1)
                    {
                        valido = false;
                    }
                }
                if (valido)
                {
                    for (int i = x; i < barco; i++)
                    {
                        mapa[i, y] = 1;
                    }
                    return (valido, mapa);
                }
                
            }
            
            //CHECK ABAJO
            if ((y + barco) < mapa.GetLength(1))
            {
                for (int i = y; i < barco; i++)
                {
                    if (mapa[x, i] == 1)
                    {
                        valido = false;
                    }
                }
                if (valido)
                {
                    for (int i = y; i < barco; i++)
                    {
                        mapa[x, i] = 1;
                    }
                    return (valido, mapa);
                }
            }   
            //CHECK IZQD
            if ((x - barco) > 0)
            {
                for (int i = x - barco; i < barco; i++)
                {
                    if (mapa[i, y] == 1)
                    {
                        valido = false;
                    }
                }
                if (valido)
                {
                    for (int i = x - barco; i < barco; i++)
                    {
                        mapa[i, y] = 1;
                    }
                    return (valido, mapa);
                }
            }
            //CHECK ARRIBA
            if ((y - barco) > 0)
            {
                for (int i = y - barco; i < barco; i++)
                {
                    if (mapa[x, i] == 1)
                    {
                        valido = false;
                    }
                }
                if (valido)
                {
                    for (int i = y - barco; i < barco; i++)
                    {
                        mapa[x, i] = 1;
                    }
                    return (valido, mapa);
                }
            }
            
            return (valido, mapa);
        }
        public static int[] crearBarcos(int tamaño, int N)
        {
            int[] barcos = new int[tamaño];
            for (int i=0; i<tamaño; i++)
            {
                Console.Write("Introduzca tamaño de barco {0}: ", i+1);
                barcos[i] = Convert.ToInt32(Console.ReadLine());
                while (barcos[i] > N)
                {
                    Console.Write("Tamaño máximo permitido = {0}, introduzca número válido: ", tamaño);
                    barcos[i] = Convert.ToInt32(Console.ReadLine());
                }
            }
            return barcos;
        }
        public static int[,] rellenarMatriz(int[,] nums)
        {
            for (int i = 0; i < nums.GetLength(0); i++)
            {
                for (int j = 0; j < nums.GetLength(1); j++)
                {
                    nums[i, j] = 0;
                }
            }
            return nums;
        }
        public static void imprimirMatriz(int[,] mapa)
        {
            for (int i = 0; i < mapa.GetLength(0); i++)
            {
                for (int j = 0; j < mapa.GetLength(1); j++)
                {
                    if (mapa[i, j] == 1)
                    {
                        Console.Write("B | ");
                    }
                    else
                    {
                        Console.Write("  | ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}