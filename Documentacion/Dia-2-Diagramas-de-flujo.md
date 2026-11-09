# Día 2: Diagramas de flujo

## 1. Menú principal
```mermaid
%%{init: {'flowchart': {'curve': 'linear'}}}%%
flowchart TD
    A([Inicio]) --> B[Llenar matriz con O]
    B --> C[/Mostrar menú y leer opción/]
    C --> D{"¿Qué opción?"}
    D -->|0| J([Fin])
    D -->|1| E[Mostrar sala de asientos]
    D -->|2| F[Reservar asiento]
    D -->|3| G[Liberar asiento]
    D -->|4| H[Consultar disponibilidad]
    D -->|5| I[Estadística de ocupación]
    D -->|Otra| K[Opción no válida]
    E --> C
    F --> C
    G --> C
    H --> C
    I --> C
    K --> C
```

## 2. Mostrar sala
```mermaid
%%{init: {'flowchart': {'curve': 'linear'}}}%%
flowchart TD
    A([Inicio]) --> B[/Imprimir columnas 0 a 9/]
    B --> C[fila i = 0]
    C --> D{"¿i es menor que 10?"}
    D -->|No| Z([Fin])
    D -->|Sí| E[/Imprimir letra de la fila/]
    E --> F[columna j = 0]
    F --> G{"¿j es menor que 10?"}
    G -->|Sí| H[/Imprimir asiento/]
    H --> I[j = j + 1]
    I --> G
    G -->|No| J[Salto de línea y i = i + 1]
    J --> D
```

## 3. Reservar asiento
```mermaid
%%{init: {'flowchart': {'curve': 'linear'}}}%%
flowchart TD
    A([Inicio]) --> B[/Pedir fila A-J y columna 0-9/]
    B --> C{"¿Fila de A a J y columna de 0 a 9?"}
    C -->|No| D[Mostrar error]
    D --> Z([Fin])
    C -->|Sí| E[Convertir la letra en número de fila]
    E --> F{"¿El asiento está libre?"}
    F -->|No| G[Mostrar: asiento ocupado]
    G --> Z
    F -->|Sí| H[Cambiar O por X]
    H --> I[/Mostrar confirmación/]
    I --> Z
```

## 4. Liberar asiento
```mermaid
%%{init: {'flowchart': {'curve': 'linear'}}}%%
flowchart TD
    A([Inicio]) --> B[/Pedir fila A-J y columna 0-9/]
    B --> C{"¿Fila de A a J y columna de 0 a 9?"}
    C -->|No| D[Mostrar error]
    D --> Z([Fin])
    C -->|Sí| E[Convertir la letra en número de fila]
    E --> F{"¿El asiento está ocupado?"}
    F -->|No| G[Mostrar: ya estaba libre]
    G --> Z
    F -->|Sí| H[Cambiar X por O]
    H --> I[/Mostrar confirmación/]
    I --> Z
```

## 5. Consultar disponibilidad
```mermaid
%%{init: {'flowchart': {'curve': 'linear'}}}%%
flowchart TD
    A([Inicio]) --> B[/Pedir fila A-J y columna 0-9/]
    B --> C{"¿Fila de A a J y columna de 0 a 9?"}
    C -->|No| D[Mostrar error]
    D --> Z([Fin])
    C -->|Sí| E[Convertir la letra en número de fila]
    E --> F{"¿El asiento es X?"}
    F -->|Sí| G[/Mostrar: ocupado/]
    F -->|No| H[/Mostrar: libre/]
    G --> Z
    H --> Z
```

## 6. Estadística de ocupación
```mermaid
%%{init: {'flowchart': {'curve': 'linear'}}}%%
flowchart TD
    A([Inicio]) --> B[Poner contadores en 0]
    B --> C{"¿Quedan asientos por revisar?"}
    C -->|Sí| D{"¿El asiento es X?"}
    D -->|Sí| E[ocupados + 1]
    D -->|No| F[disponibles + 1]
    E --> C
    F --> C
    C -->|No| G[Calcular porcentaje: ocupados entre total por 100]
    G --> H[/Mostrar resultados/]
    H --> Z([Fin])
```