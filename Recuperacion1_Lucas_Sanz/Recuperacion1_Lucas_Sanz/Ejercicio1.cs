using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Recuperacion1_Lucas_Sanz
{
    class Ejercicio1
    {
        public static void Main(string[] args)
        {
            Console.Write("Introduzca número de filas: ");
            int filas = Convert.ToInt32(Console.ReadLine());
            Console.Write("Introduzca número de columnas: ");
            int columnas = Convert.ToInt32(Console.ReadLine());
            Console.Write("Introduzca fila final: ");
            int fila_final = Convert.ToInt32(Console.ReadLine());
            Console.Write("Introduzca columna final: ");
            int columna_final = Convert.ToInt32(Console.ReadLine());

            int[,] cuadrante = new int[filas, columnas];

            Boolean check = false;
            int tamaño_serpiente;
            do
            {
                Console.Write("Introduzca tamaño serpiente: ");
                tamaño_serpiente = Convert.ToInt32(Console.ReadLine());
                check = checkTamaño(tamaño_serpiente, cuadrante, fila_final, columna_final);
            } while (!check);

            crearCuadrante(cuadrante, fila_final, columna_final, tamaño_serpiente);
        }
        public static int calcularAsterisco(int[,] cuadrante_actual, int fila_final, int columna_final)
        {
            Boolean impar = false;
            int contador = 0;
            for (int i=0; i<cuadrante_actual.GetLength(0) && i<=fila_final; i++)
            {
                if (!impar)
                {
                    for (int j=0; j<cuadrante_actual.GetLength(1); j++)
                    {
                        contador++;
                        if (i == fila_final && j == columna_final)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    for (int j = cuadrante_actual.GetLength(1) - 1; j >= 0; j--)
                    {
                        if (i == fila_final && j == columna_final)
                        {
                            break;
                        }
                        contador++;
                    }
                }
                impar = !impar;
            }
            return contador;
        }
        public static Boolean checkTamaño(int N, int[,] cuadrante_actual, int fila_final, int columna_final)
        {
            int tamaño = calcularAsterisco(cuadrante_actual, fila_final, columna_final);
            if (tamaño < N)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void crearCuadrante(int[,] cuadrante_actual, int fila_final, int columna_final, int tamaño_serpiente)
        {
            int contador_estela = calcularAsterisco(cuadrante_actual, fila_final, columna_final) - tamaño_serpiente;
            int contador = 0;
            Boolean impar = false;
            for (int i = 0; i < cuadrante_actual.GetLength(0); i++)
            {
                for (int j=0; j < cuadrante_actual.GetLength(1); j++)
                {
                    cuadrante_actual[i, j] = 0;
                }
            }

            for (int i = 0; i < cuadrante_actual.GetLength(0) && i <= fila_final; i++)
            {
                if (!impar)
                {
                    for (int j = 0; j < cuadrante_actual.GetLength(1); j++)
                    {
                        if (i == fila_final && j == columna_final)
                        {
                            cuadrante_actual[i, j] = 3;
                            break;
                        }
                        if (contador <= contador_estela)
                        {
                            cuadrante_actual[i, j] = 1;
                        }
                        else
                        {
                            cuadrante_actual[i, j] = 3;
                        }
                        contador++;                        
                    }
                }
                else
                {
                    for (int j = cuadrante_actual.GetLength(1) - 1; j >= 0; j--)
                    {
                        if (i == fila_final && j == columna_final)
                        {
                            cuadrante_actual[i, j] = 3;
                            break;
                        }
                        if (contador < contador_estela)
                        {
                            cuadrante_actual[i, j] = 2;
                        }
                        else
                        {
                            cuadrante_actual[i, j] = 3;
                        }
                        contador++;
                    }
                }
                impar = !impar;
            }
            imprimirCuadrante(cuadrante_actual);

        }
        public static void imprimirCuadrante(int[,] cuadrante_actual)
        {
            for (int i = 0; i < cuadrante_actual.GetLength(0); i++)
            {
                for (int j = 0; j < cuadrante_actual.GetLength(1); j++)
                {
                    if (cuadrante_actual[i,j] == 0)
                    {
                        Console.Write("   ");
                    }
                    else if (cuadrante_actual[i, j] == 1)
                    {
                        Console.Write(" > ");
                    }
                    else if (cuadrante_actual[i, j] == 2)
                    {
                        Console.Write(" < ");
                    }
                    else
                    {
                        Console.Write(" * ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
