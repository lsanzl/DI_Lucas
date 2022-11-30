using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Matrices
{
    public class Ejercicio1Matrices
    {
        private static Random rnd = new Random();
        public static void Main(string[] args)
        {
            int[,] matriz = crearMatriz();
            contarNumeros(matriz);
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
        public static void contarNumeros(int[,] matriz)
        {
            int[] numeros = new int[10];
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                Console.Write("|");
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    numeros[matriz[i, j]]++;
                    Console.Write(" " + matriz[i, j] + " |");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n----- CONTEO DE NÚMEROS -----");
            for (int i = 0; i < numeros.Length; i++)
            {
                Console.WriteLine("El número {0} ha aparecido {1} veces", i, numeros[i]);
            }
        }
    }
}