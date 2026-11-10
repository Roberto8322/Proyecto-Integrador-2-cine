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
                    ConsultarDisponibilidad();
                    break;
                case "3":
                    ReservarAsiento();
                    break;
                case "4":
                    LiberarAsiento();
                    break;
                case "5":
                    MostrarEstadisticas();
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
        Console.WriteLine("2. Consultar disponibilidad");
        Console.WriteLine("3. Reservar asientos");
        Console.WriteLine("4. Liberar asiento");
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

    static (int fila, int columna) LeerCoordenadas()
    {
    
    char[] letras = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
    
    int fila = -1;
    int columna = -1;

        
        while (fila == -1)
        {
            Console.Write("Ingrese la fila (A-J): ");
            string entradaFila = Console.ReadLine().ToUpper();

            int c = 0;

            for (int j = 0; j <= 9; j++)
            {
                if (entradaFila.Length > 0 && letras[j] == entradaFila[0])
                {
                    fila = c;
                }
                c++;
            }

            if (fila == -1)
            {
                Console.WriteLine("Fila no válida. Intente de nuevo.");
            }
        }

        while (columna < 0 || columna > 9)
        {
            Console.Write("Ingrese la columna (0-9): ");

            if (!int.TryParse(Console.ReadLine(), out columna) || columna < 0 || columna > 9)
            {
                columna = -1;
                Console.WriteLine("Columna no válida. Intente de nuevo.");
            }
        }
    
    while (fila == -1)
    {
        Console.Write("Ingrese la fila (A-J): ");
        string entradaFila = Console.ReadLine().ToUpper();

        int c = 0;

        for (int i = 0; i <= 9; i++)
        {
            
            if (entradaFila.Length > 0 && letras[i] == entradaFila[0])
            {
                fila = c; 
            }
            c++; 
        }

        if (fila == -1)
        {
            Console.WriteLine("Fila no válida. Intente de nuevo.");
        }
    }       
    
    

while (columna < 0 || columna > 9)
    {
        Console.Write("Ingrese la columna (0-9): ");
        
        // TryParse lee lo que puso. Si presionó Enter, out dará false
        if (!int.TryParse(Console.ReadLine(), out columna) || columna < 0 || columna > 9)
        {
            columna = -1; // Lo mantenemos en -1 para que el while se repita
            Console.WriteLine("Columna no válida. Intente de nuevo.");
        }
    }

    return (fila, columna);
    }
    static void ReservarAsiento()
    {
        Console.WriteLine(" RESERVAR ASIENTO ");
        int cantidadAsientos = 0;
    Console.WriteLine("Ingrese la cantidad de asientos a reservar");
    while (!int.TryParse(Console.ReadLine(), out cantidadAsientos) || cantidadAsientos <= 0|| cantidadAsientos > 10)
    {
        Console.WriteLine("Cantidad no válida. Intente de nuevo.");
    }
    for (int o = 0; o < cantidadAsientos; o++)
    {
    var (fila, columna) = LeerCoordenadas();

    if (fila == -1 || columna == -1)
    {
        return;
    }

  
    if (sala[fila, columna] == 'X')
    {
        Console.WriteLine("El asiento ya se encuentra ocupado");
    }
    else
    {
        sala[fila, columna] = 'X';
        Console.WriteLine("¡Reserva realizada con exito!");
    }
    }
    }
    static void LiberarAsiento()
{
    string MotivoLiberacion = "";
    Console.WriteLine(" LIBERAR ASIENTO ");

    Console.WriteLine("Ingrese motivo de liberación del asiento");
    Console.WriteLine("1. Motivo de Salud");
    Console.WriteLine("2. Motivo de Viaje");
    Console.WriteLine("3. Motivo de Cambio de Planes");
    Console.WriteLine("4. Otro Motivo");
    switch (Console.ReadLine())
        {
            case "1":
                MotivoLiberacion = "Motivo de Salud seleccionado.";
                break;
            case "2":
                MotivoLiberacion = "Motivo de Viaje seleccionado.";
                break;
            case "3":
                MotivoLiberacion = "Motivo de Cambio de Planes seleccionado.";
                break;
            case "4":
                Console.WriteLine("Ingrese el motivo de liberación del asiento:");
                MotivoLiberacion = "" + Console.ReadLine();
                break;
            default:
                Console.WriteLine("Opción no válida. Se considerará como 'Otro Motivo'.");
                break;
        }    

            int cantidadAsientos = 0;
    Console.WriteLine("Ingrese la cantidad de asientos a liberar");
    while (!int.TryParse(Console.ReadLine(), out cantidadAsientos) || cantidadAsientos <= 0|| cantidadAsientos > 10)
    {
        Console.WriteLine("Cantidad no válida. Intente de nuevo.");
    }
    for (int o = 0; o < cantidadAsientos; o++)
    {
    var (fila, columna) = LeerCoordenadas();

    if (sala[fila, columna] == 'O')
    {
        Console.WriteLine("El asiento ya estaba libre");
    }
    else
    {
        sala[fila, columna] = 'O';
        Console.WriteLine("¡Asiento liberado con exito!");
    }
    }
}
static void ConsultarDisponibilidad()
{
    Console.WriteLine("CONSULTAR DISPONIBILIDAD");
            int cantidadAsientos = 0;
    Console.WriteLine("Ingrese la cantidad de asientos que desea consultar");
    while (!int.TryParse(Console.ReadLine(), out cantidadAsientos) || cantidadAsientos <= 0|| cantidadAsientos > 100)
    {
        Console.WriteLine("Cantidad no válida. Intente de nuevo.");
    }
    for (int o = 0; o < cantidadAsientos; o++)
    {
    var (fila, columna) = LeerCoordenadas();

    if (sala[fila, columna] == 'X')
    {
        Console.WriteLine("El asiento seleccionado esta: ocupado X");
    }
    else
    {
        Console.WriteLine("El asiento seleccionado esta: libre O");
    }
    }
}
static void MostrarEstadisticas()
{
    Console.WriteLine("ESTADiSTICAS DE LA SALA");

    int ocupados = 0;
    int libres = 0;

    for (int f = 0; f < 10; f++)
    {
        for (int c = 0; c < 10; c++)
        {
            if (sala[f, c] == 'X')
            {
                ocupados++;
            }
            else
            {
                libres++;
            }
        }
    }
    double porcentaje = (ocupados / 100.0) * 100;
    Console.WriteLine($"Asientos Ocupados: {ocupados}");
    Console.WriteLine($"Asientos Libres:   {libres}");
    Console.WriteLine($"Total de Asientos: 100");
    Console.WriteLine($"Porcentaje de Ocupación: {porcentaje}%");
}
}