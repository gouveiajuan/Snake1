using System;
using System.Threading;

class Program
{
    static int columnas;
    static int filas;
    static int[,] tablero;
    static int snakeX;
    static int snakeY;
    static int direccionX;
    static int direccionY;
    static bool GameOver;

    static void Main(string[] args)
    {
        Console.WriteLine("S N A K E");
        Console.Write("Para jugar ingrese el número de filas del tablero: ");
        filas = int.Parse(Console.ReadLine());
        Console.Write("Ingrese el número de columnas del tablero: ");
        columnas = int.Parse(Console.ReadLine());

        InicioJuego();
        MostrarTablero();

        while (GameOver == false)
        {
            Movimientos();
            ActualizarJuego();
            MostrarTablero();
            Thread.Sleep(150);
        }

        Console.WriteLine("¡Game Over!" + "\nPresione cualquier tecla para salir.");
        Console.ReadKey();
    }

    static void InicioJuego()
    {
        tablero = new int[filas, columnas];
        snakeX = columnas / 2;
        snakeY = filas / 2;
        direccionX = 0;
        direccionY = 0;
        GameOver = false;
    }
    static void MostrarTablero()
    {
        Console.Clear();

        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                if (i == 0 || i == filas - 1)
                    Console.Write("═");

                else if (j == 0 || j == columnas - 1)
                    Console.Write("║");

                else if (tablero[i, j] > 0)
                    Console.Write("█");

                else if (i == snakeY && j == snakeX)
                    Console.Write("O");

                else
                    Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
    static void Movimientos()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo tecla = Console.ReadKey(true);
            switch (tecla.Key)
            {
                case ConsoleKey.UpArrow:
                    if (direccionY != 1)
                    {
                        direccionX = 0;
                        direccionY = -1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (direccionY != -1)
                    {
                        direccionX = 0;
                        direccionY = 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (direccionX != 1)
                    {
                        direccionX = -1;
                        direccionY = 0;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (direccionX != -1)
                    {
                        direccionX = 1;
                        direccionY = 0;
                    }
                    break;
                case ConsoleKey.Escape:
                    GameOver = true;
                    break;
            }
        }
    }
    static void ActualizarJuego()
    {
        int cabezaX = snakeX + direccionX;
        int cabezaY = snakeY + direccionY;

        if (cabezaX < 0 || cabezaX >= columnas || cabezaY < 0 || cabezaY >= filas)
        {
            GameOver = true;
            return;
        }
        if (tablero[cabezaY, cabezaX] == 1)
        {
            GameOver = true;
            return;
        }
        tablero[snakeY, snakeX] = 1;
        snakeX = cabezaX;
        snakeY = cabezaY;
        tablero[snakeY, snakeX] = 0;
    }
}
