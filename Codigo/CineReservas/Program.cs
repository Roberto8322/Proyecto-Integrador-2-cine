class Program
{
    // La sala: matriz de 10 filas (A-J) por 10 columnas (0-9).
    // 'O' = libre, 'X' = ocupado.
    static char[,] sala = new char[10, 10];

    static void Main()
    {
        LlenarSala();

        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            MostrarMenu();
            string opcion = Console.ReadLine() ?? "";
            Console.Clear();

            switch (opcion)
            {
                case "0":
                    Console.WriteLine("Hasta luego.");
                    salir = true;
                    break;
                case "1":
                    MostrarSala();
                    break;
                case "2":
                    Console.WriteLine("Reservar asiento: pendiente.");
                    break;
                case "3":
                    Console.WriteLine("Liberar asiento: pendiente.");
                    break;
                case "4":
                    Console.WriteLine("Consultar disponibilidad: pendiente.");
                    break;
                case "5":
                    Console.WriteLine("Estadística de ocupación: pendiente.");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    break;
            }

            // Pausa para que se alcance a ver el resultado antes de volver al menú.
            if (!salir)
            {
                Console.WriteLine();
                Console.Write("Presiona Enter para continuar...");
                Console.ReadLine();
            }
        }
    }

    // Pone todos los asientos como libres ('O').
    static void LlenarSala()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                sala[i, j] = 'O';
            }
        }
    }

    // Imprime las opciones del menú principal.
    static void MostrarMenu()
    {
        Console.WriteLine("===== CINE =====");
        Console.WriteLine("0. Salir");
        Console.WriteLine("1. Mostrar sala de asientos");
        Console.WriteLine("2. Reservar asiento");
        Console.WriteLine("3. Liberar asiento");
        Console.WriteLine("4. Consultar disponibilidad");
        Console.WriteLine("5. Estadística de ocupación");
        Console.Write("Elige una opción: ");
    }

    // Recorre la matriz e imprime la sala con letras en las filas
    // y números en las columnas.
    static void MostrarSala()
    {
        Console.Write("    ");
        for (int j = 0; j < 10; j++)
        {
            Console.Write(j + " ");
        }
        Console.WriteLine();
        Console.WriteLine("   " + new string('-', 21));

        for (int i = 0; i < 10; i++)
        {
            Console.Write((char)('A' + i) + " | ");
            for (int j = 0; j < 10; j++)
            {
                Console.Write(sala[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}