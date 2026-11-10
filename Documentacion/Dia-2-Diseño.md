Algoritmo General

* Inicio
* Declaracion de la matriz bidimensional sala de 10 filas por 10 columnas (char[10, 10]).
* llenar la matriz recorriendo sus filas (A a J) y columnas (0 a 9) asignando a cada posicion el caracter 'O' (asiento disponible).
* Iniciar un ciclo repetitivo para el Menu Principal que se ejecute mientras la opcion seleccionada no sea 0 Salir:

   * imprimir en pantalla las opciones del Menu Principal:

      - 0. Salir

      - 1. Mostrar sala de asientos

      - 2. Reservar asiento

      - 3. Liberar asiento

      - 4. Consultar disponibilidad

      - 5. Estadistica de ocupacion

   * solicitar al usuario que ingrese el numero de la opcion deseada del Menu Principal
   * verificar la opcion ingresada y usar un Switch para cada opcion posible:
      * Caso 1 (Mostrar Matriz): Recorrer la matriz de 10x10 e imprimir en pantalla el estado actual de los 100 asientos formados y con sus indices de filas y columnas.
      * Caso 2 (reservar Asiento): Solicitar fila (A-J) y columna (0-9) y Validar que la coordenada este en rango y que el valor sea 'O' Si esta libre, cambiar el estado a 'X' (ocupado) y confirmar la reserva Si esta ocupado o fuera de rango entonces mostrar mensaje de error
      * Caso 3 (Liberar Asiento): Solicitar fila (A-J) y columna (0-9) y Validar que la coordenada este en rango y que el valor sea 'X'. Si esta ocupado, cambiar el estado a 'O' (libre) y confirmar la liberacion. Si ya esta libre o fuera de rango entonces informar al usuario
      * Caso 4 (Consultar disponibilidad): Solicitar fila (A-J) y columna (0-9) y Verificar si la posicion contiene 'O' o 'X' y mostrar un mensaje especificando si el asiento esta libre u ocupado
      * Caso 5 (Estadistica de ocupacion): Recorrer las 100 posiciones de la matriz y contabilizar cuantas tienen 'X' (ocupados) y cuantas 'O' (disponibles)  y el calculo del porcentaje mediante la formula (ocupados / 100) * 100 e imprimir el porcentaje resultante y ambos totales en pantalla
      * Caso 6 (Salir): Mostrar mensaje de cierre y finalizar el ciclo del menu
      * Caso Defecto (Opcion por defecto): Notificar al usuario que la opcion no es vlida y solicitar una nueva opcion
* Fin 

Pseudocodigo

Algoritmo ProyectoCine
	
	Dimension sala[10, 10]
	Definir opcion COMO Entero
	
	MatrizInicial(sala)
	
	Repetir
		Escribir "Menu Principal de cine"
		Escribir "0. Salir"
		Escribir "1. Mostrar matriz de asientos"
		Escribir "2. Reservar asiento"
		Escribir "3. Liberar asiento"
		Escribir "4. Consultar disponibilidad"
		Escribir "5. Estadisticas de ocupacion"
		Escribir "Seleccione una opcion (0-5): "
		Leer opcion
		
		Segun opcion Hacer
			0:
				Escribir "Gracias por usar el servicio"
			1:
				MostrarMatriz(sala)
			2:
				ReservarAsiento(sala)
			3:
				LiberarAsiento(sala)
			4:
				ConsultarDisponibilidad(sala)
			5:
				MostrarEstadisticas(sala)
			De Otro Modo:
				Escribir "Error: Opcion invalida Intente de nuevo."
		FinSegun
		
		Si opcion <> 0 Entonces
			Escribir "Presione Enter para continuar"
			Esperar Tecla
		FinSi
		
	Hasta Que opcion = 0
FinAlgoritmo

SubProceso MatrizInicial(sala)
	Definir f, c Como Entero
	Para f = 1 Hasta 10 Con Paso 1 Hacer
		Para c = 1 Hasta 10 Con Paso 1 Hacer
			sala[f, c] = 'O'
		FinPara
	FinPara
FinSubProceso

SubProceso MostrarMatriz(sala)
	Definir f, c Como Entero
	Definir letras Como Cadena
	letras = "ABCDEFGHIJ"
	
	Escribir "Sala del cine"
	Escribir " Leyenda: O Libre | X Ocupado"
	Escribir "    1   2   3   4   5   6   7   8   9  10"
	Escribir "    --------------------------------------"
	Para f = 1 Hasta 10 Con Paso 1 Hacer
		Escribir Sin Saltar Subcadena(letras, f, f), " | "
		Para c = 1 Hasta 10 Con Paso 1 Hacer
			Escribir Sin Saltar sala[f, c], " | "
		FinPara
		Escribir ""
	FinPara
FinSubProceso

SubProceso ReservarAsiento(sala)
	Definir fila, columna Como Entero
	Definir letraFila Como Cadena
	
	Escribir "Reserva de asiento"
	Escribir "Ingrese la fila (A-J): "
	Leer letraFila
	letraFila = Mayusculas(letraFila)
	
	Segun letraFila Hacer
		"A": fila = 1
		"B": fila = 2
		"C": fila = 3
		"D": fila = 4
		"E": fila = 5
		"F": fila = 6
		"G": fila = 7
		"H": fila = 8
		"I": fila = 9
		"J": fila = 10
		De Otro Modo: fila = -1
	FinSegun
	
	Si fila = -1 Entonces
		Escribir "Error: Debe ingresar una letra entre A y J."
	Sino
		Escribir "Ingrese la columna (1-10): "
		Leer columna
		
		Si columna < 1 O columna > 10 Entonces
			Escribir "Error: Columna fuera de rango (1-10)."
		Sino Si sala[fila, columna] = 'X' Entonces
				Escribir "Error: El asiento ya se encuentra OCUPADO."
			Sino
				sala[fila, columna] = 'X'
				Escribir "Asiento reservado correctamente."
			FinSi
		FinSi
	FinSi
FinSubProceso

SubProceso LiberarAsiento(sala)
	Definir fila, columna Como Entero
	Definir letraFila Como Cadena
	
	Escribir "Liberar asiento"
	Escribir "Ingrese la fila (A-J): "
	Leer letraFila
	letraFila = Mayusculas(letraFila)
	
	Segun letraFila Hacer
		"A": fila = 1
		"B": fila = 2
		"C": fila = 3
		"D": fila = 4
		"E": fila = 5
		"F": fila = 6
		"G": fila = 7
		"H": fila = 8
		"I": fila = 9
		"J": fila = 10
		De Otro Modo: fila = -1
	FinSegun
	
	Si fila = -1 Entonces
		Escribir "Error: Debe ingresar una letra entre A y J."
	Sino
		Escribir "Ingrese la columna (1-10): "
		Leer columna
		
		Si columna < 1 O columna > 10 Entonces
			Escribir "Error: Columna fuera de rango (1-10)."
		Sino Si sala[fila, columna] = 'O' Entonces
				Escribir "Aviso: El asiento ya se encuentra LIBRE."
			Sino
				sala[fila, columna] = 'O'
				Escribir "Asiento liberado correctamente."
			FinSi
		FinSi
	FinSi
FinSubProceso

SubProceso ConsultarDisponibilidad(sala)
	Definir fila, columna Como Entero
	Definir letraFila Como Cadena
	
	Escribir "Consultar Disponibilidad"
	Escribir "Ingrese la fila (A-J): "
	Leer letraFila
	letraFila <- Mayusculas(letraFila)
	
	Segun letraFila Hacer
		"A": fila = 1
		"B": fila = 2
		"C": fila = 3
		"D": fila = 4
		"E": fila = 5
		"F": fila = 6
		"G": fila = 7
		"H": fila = 8
		"I": fila = 9
		"J": fila = 10
		De Otro Modo: fila = -1
	FinSegun
	
	Si fila = -1 Entonces
		Escribir "Error: Debe ingresar una letra entre A y J."
	Sino
		Escribir "Ingrese la columna (1-10): "
		Leer columna
		
		Si columna < 1 O columna > 10 Entonces
			Escribir "Error: Columna fuera de rango."
		Sino Si sala[fila, columna] = 'O' Entonces
				Escribir "El asiento en (", letraFila, ", ", columna, ") esta disponible O."
			Sino
				Escribir "El asiento en (", letraFila, ", ", columna, ") esta ocupado X."
			FinSi
		FinSi
	FinSi
FinSubProceso

SubProceso MostrarEstadisticas(sala)
	Definir f, c, ocupados, disponibles Como Entero
	Definir porcentaje Como Real
	ocupados = 0
	disponibles = 0
	
	Para f = 1 Hasta 10 Con Paso 1 Hacer
		Para c = 1 Hasta 10 Con Paso 1 Hacer
			Si sala[f, c] = 'X' Entonces
				ocupados = ocupados + 1
			Sino
				disponibles = disponibles + 1
			FinSi
		FinPara
	FinPara
	
	porcentaje = (ocupados / 100.0) * 100
	
	Escribir "Estadistica de ocupacion"
	Escribir "Asientos Disponibles O: ", disponibles
	Escribir "Asientos Ocupados    X: ", ocupados
	Escribir "Total de asientos       : ", (disponibles + ocupados)
	Escribir "Porcentaje de ocupacion : ", porcentaje, "%"
FinSubProceso


* Diseño modular

* El programa se divide en funciones, y cada una hace una sola cosa:

| Modulo | Que hace |
| :--- | :--- |
| **Menu principal** | Muestra las opciones y llama a la funcion que se elija |
| **MostrarSala** | Recorre la matriz e imprime la sala |
| **LeerCoordenada** | Pide fila (A-J) y columna (0-9) y valida los rangos |
| **ReservarAsiento** | Cambia O por X si el asiento esta libre |
| **LiberarAsiento** | Cambia X por O si el asiento esta ocupado |
| **ConsultarAsiento** | Dice si un asiento esta libre u ocupado |
| **MostrarEstadisticas** | Cuenta ocupados y disponibles y calcula el porcentaje |

* Diseño preliminar de la interfaz

* Menu Principal

   Sala  de Cine

0. Salir
1. Ver sala
2. Reservar asiento
3. Liberar asiento
4. Consultar disponibilidad
5. Ver estadisticas
Elige una opcion:

Sala (O = libre, X = ocupado)

| Fila | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |
| :---: | :---: | :---: | :---: | :---: | :---: | :---: | :---: | :---: | :---: | :---: |
| **A** | O | O | O | O | O | O | O | O | O | O |
| **B** | O | O | O | O | O | O | O | O | O | O |
| **C** | O | O | O | X | O | O | O | O | O | O |
| **D** | O | O | O | O | O | O | O | O | O | O |
| **E** | O | O | O | O | O | O | O | O | O | O |
| **F** | O | O | O | O | O | O | O | O | O | O |
| **G** | O | O | O | O | O | O | O | O | O | O |
| **H** | O | O | O | O | O | O | O | O | O | O |
| **I** | O | O | O | O | O | O | O | O | O | O |
| **J** | O | O | O | O | O | O | O | O | O | O |