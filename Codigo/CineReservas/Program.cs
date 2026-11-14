class Program
{
    // La sala: matriz de 10 filas (A-J) por 10 columnas (0-9).
    // 'O' = libre, 'X' = ocupado.
    static char[,] sala = new char[10, 10];
    
    static void Main()
    {
        
        //La sala inicia con todos los asientos libres.
        LlenarSala();

        // Bucle principal del programa.
        bool salir = false;
        //El Menu se mostrará hasta que el usuario decida salir con 0.
        while (!salir)
        {
            Console.Clear();
            MostrarMenu();
            //Lee la opcion que escribe el usuario y si es null, le asigna un string vacio.
            string opcion = Console.ReadLine() ?? "";
            Console.Clear();

            //Segun la opcion que el usuario elija, se ejecutará una acción diferente.
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
                    //Cualquier otro numero o letra.
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

    //Pone un 'O' en cada asiento de la sala, indicando que está libre.
    static void LlenarSala()
    {
        // i recorre las filas (A-J) y j recorre las columnas (0-9).
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
        // Números de columna
        Console.Write("    ");
        for (int j = 0; j < 10; j++)
        {
            Console.Write(j + " ");
        }
        Console.WriteLine();
        // Linea de guiones para separar los números de las filas
        Console.WriteLine("   " + new string('-', 21));

        // Imprime fila por fila 
        for (int i = 0; i < 10; i++)
        {
            // La letra de la fila (A-J) y un separador
            Console.Write((char)('A' + i) + " | ");
            // Imprime cada asiento de la fila O o X
            for (int j = 0; j < 10; j++)
            {
                Console.Write(sala[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    // Pide la fila y la columna al usuario y las regresa 
    // Si escribe algo mal lo vuelve a pedir 
    static (int fila, int columna) LeerCoordenadas()
    {
    
    char[] letras = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
    
    int fila = -1;
    int columna = -1;

        // Pide la fila hasta que sea válida (A-J)        
        while (fila == -1)
        {
            Console.Write("Ingrese la fila (A-J): ");
            // Lee la entrada del usuario y la convierte a mayúsculas
            string entradaFila = Console.ReadLine().ToUpper();

            // C lleva el numero de fila que vamos revisando 
            int c = 0;

            // Busca la letra en la lista, su posicion es el numero de fila
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

        // Pide la columna hasta que sea válida (0-9)
        while (columna < 0 || columna > 9)
        {
            Console.Write("Ingrese la columna (0-9): ");

            // Tryparse revisa si lo que puso el usuario es un número y lo guarda en columna. Si no es un número, devuelve false.
            if (!int.TryParse(Console.ReadLine(), out columna) || columna < 0 || columna > 9)
            {
                columna = -1;
                Console.WriteLine("Columna no válida. Intente de nuevo.");
            }
        }
    
    // De aquí se regresa la fila y columna que el usuario ingresó correctamente
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

    // Regresa las dos coordenadas que el usuario ingresó correctamente
    return (fila, columna);
    }
    // Reserva uno o varios asientos, según lo que el usuario indique.
    static void ReservarAsiento()
    {
        Console.WriteLine(" RESERVAR ASIENTO ");
        int cantidadAsientos = 0;
    Console.WriteLine("Ingrese la cantidad de asientos a reservar");
    // Pide la cantidad de asientos hasta que sea válida (1-10)
    while (!int.TryParse(Console.ReadLine(), out cantidadAsientos) || cantidadAsientos <= 0|| cantidadAsientos > 10)
    {
        Console.WriteLine("Cantidad no válida. Intente de nuevo.");
    }
    // Pide las coordenadas de cada asiento a reservar
    for (int o = 0; o < cantidadAsientos; o++)
    {
    var (fila, columna) = LeerCoordenadas();

    // Si no hay coordenadas válidas, se sale del método
    if (fila == -1 || columna == -1)
    {
        return;
    }

    // Si el asiento ya tiene X no se puede reservar, si tiene O se reserva y se pone X
    if (sala[fila, columna] == 'X')
    {
        Console.WriteLine("El asiento ya se encuentra ocupado");
    }
    else
    {
        // Lo marca como ocupado
        sala[fila, columna] = 'X';
        Console.WriteLine("¡Reserva realizada con exito!");
    }
    }
    }

    // Libera uno o varios asientos y pide un motivo de liberación al usuario.
    static void LiberarAsiento()
{
    // Aqui se guarda el motivo
    string MotivoLiberacion = "";
    Console.WriteLine(" LIBERAR ASIENTO ");

    // Submenu con los motivos
    Console.WriteLine("Ingrese motivo de liberación del asiento");
    Console.WriteLine("1. Motivo de Salud");
    Console.WriteLine("2. Motivo de Viaje");
    Console.WriteLine("3. Motivo de Cambio de Planes");
    Console.WriteLine("4. Otro Motivo");
    // Guarda el motivo según la opción que el usuario elija
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
    // Pide la cantidad de asientos hasta que sea válida (1-10)
    while (!int.TryParse(Console.ReadLine(), out cantidadAsientos) || cantidadAsientos <= 0|| cantidadAsientos > 10)
    {
        Console.WriteLine("Cantidad no válida. Intente de nuevo.");
    }
    // Pide las coordenadas de cada asiento a liberar
    for (int o = 0; o < cantidadAsientos; o++)
    {
    var (fila, columna) = LeerCoordenadas();

    if (sala[fila, columna] == 'O')
    {
        Console.WriteLine("El asiento ya estaba libre");
    }
    else
    {
        // Lo marca como libre
        sala[fila, columna] = 'O';
        Console.WriteLine("¡Asiento liberado con exito!");
    }
    }
}

// Dice si un asiento está ocupado o libre, según lo que el usuario indique.
static void ConsultarDisponibilidad()
{
    Console.WriteLine("CONSULTAR DISPONIBILIDAD");
            int cantidadAsientos = 0;
    Console.WriteLine("Ingrese la cantidad de asientos que desea consultar");
    // Pide la cantidad de asientos hasta que sea válida (1-100)
    while (!int.TryParse(Console.ReadLine(), out cantidadAsientos) || cantidadAsientos <= 0|| cantidadAsientos > 100)
    {
        Console.WriteLine("Cantidad no válida. Intente de nuevo.");
    }
    for (int o = 0; o < cantidadAsientos; o++)
    {
    var (fila, columna) = LeerCoordenadas();

    // X indica que el asiento está ocupado y O que está libre
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

// Cuenta los asientos ocupados y libres y calcula el porcentaje de ocupación.
static void MostrarEstadisticas()
{
    Console.WriteLine("ESTADiSTICAS DE LA SALA");

    // Contadores en 0
    int ocupados = 0;
    int libres = 0;

    // f recorre las filas y c recorre las columnas
    for (int f = 0; f < 10; f++)
    {
        for (int c = 0; c < 10; c++)
        {
            // Si es x se suma a ocupados, si es O se suma a libres
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
    // Ocupados entre 100 asientos, por 100. Con 100.0 sale con decimales
    double porcentaje = (ocupados / 100.0) * 100;
    Console.WriteLine($"Asientos Ocupados: {ocupados}");
    Console.WriteLine($"Asientos Libres:   {libres}");
    Console.WriteLine($"Total de Asientos: 100");
    Console.WriteLine($"Porcentaje de Ocupación: {porcentaje}%");
}
}