using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrices
{
    public class Ejercicio2Matrices
    {
        private static Random rnd = new Random();
        public static void Main(string[] args)
        {
            
        }
        public static int[,] crearMatriz()
        {
            Console.Write("Introduzca dimensión matriz: ");
            int dimension = Convert.ToInt32(Console.ReadLine());
            int[,] matriz_nueva = new int[dimension, dimension];

            for (int i = 0; i < matriz_nueva.GetLength(0); i++)
            {
                for (int j = 0; j < matriz_nueva.GetLength(1); j++)
                {
                    matriz_nueva[i, j] = rnd.Next(0, 10);
                }
            }
            return matriz_nueva;
        }
        public static void showInfoMatriz(int[,] matriz)
        {
            int x;
            int y;

            do
            {
                Console.Write("Introduzca coordenada x: ");
                x = Convert.ToInt32(Console.ReadLine());
            } while (!checkPosicion(matriz, x, true));
            do
            {
                Console.Write("Introduzca coordenada y: ");
                y = Convert.ToInt32(Console.ReadLine());
            } while (!checkPosicion(matriz, y, false)); 

            Console.WriteLine("Espacio por encima: ", x - 0);
            Console.WriteLine("Espacio por debajo: ", matriz.GetLength(1) - x);
            Console.WriteLine("Espacio por la izqd: ", y - 0);
            Console.WriteLine("Espacio por debajo: ", matriz.GetLength(0) - y);
        }
        public static int getArriba
        public static Boolean checkPosicion(int[,] matriz, int num, Boolean opcion) {
            Boolean valido = false;
            if (opcion)
            {
                if (num <= matriz.GetLength(0))
                {
                    valido = true;
                }
            }
            else
            {
                if (num <= matriz.GetLength(1))
                {
                    valido = true;
                }
            }
            return valido;
        }
    }
}
