# Día 2: Diseño modular e interfaz

## Diseño modular
El programa se divide en funciones, y cada una hace una sola cosa:

| Módulo | Qué hace |
|---|---|
| Menú principal | Muestra las opciones y llama a la función que se elija |
| MostrarSala | Recorre la matriz e imprime la sala con letras en las filas y números en las columnas |
| LeerCoordenada | Pide fila (A a J) y columna (0 a 9), valida los datos y convierte la letra en número de fila |
| ReservarAsiento | Cambia O por X si el asiento está libre |
| LiberarAsiento | Cambia X por O si el asiento está ocupado |
| ConsultarAsiento | Dice si un asiento está libre u ocupado |
| MostrarEstadisticas | Cuenta ocupados y disponibles y calcula el porcentaje |

## Diseño preliminar de la interfaz

### Menú
```
===== CINE =====
0. Salir
1. Mostrar sala de asientos
2. Reservar asiento
3. Liberar asiento
4. Consultar disponibilidad
5. Estadística de ocupación
Elige una opción:
```

### Sala (O = libre, X = ocupado)
Las filas (horizontales) se identifican con letras de la A a la J y las columnas (verticales) con números del 0 al 9.
```
    0 1 2 3 4 5 6 7 8 9
A | O O O O O O O O O O
B | O O O O O O O O O O
C | O O O O O X O O O O
D | O O O O O O O O O O
```
El asiento ocupado del ejemplo está en la fila C, columna 5 (C5).

### Captura de datos
```
Fila (A-J): C
Columna (0-9): 5
```
Si el usuario escribe la letra en minúscula, el programa la convierte a mayúscula.

### Mensajes
- Reservado: `Asiento reservado.`
- Ocupado: `Ese asiento ya está ocupado.`
- Liberado: `Asiento liberado.`
- Ya libre: `Ese asiento ya estaba libre.`
- Error: `Dato no válido. Fila de A a J y columna de 0 a 9.`
- Opción inválida: `Opción no válida. Intenta de nuevo.`
- Estadísticas: `Ocupados: 12 | Disponibles: 88 | Ocupación: 12%`