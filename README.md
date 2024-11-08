# Proyecto: Embebido de Aplicaciones en C#

Este proyecto en C# permite integrar diversas aplicaciones dentro de ventanas personalizadas creadas con WinForms, lo que facilita la interacción con aplicaciones externas desde una sola interfaz. El proyecto fue desarrollado en Visual Studio Code con el SDK de .NET, en lugar de Visual Studio, destacando la versatilidad de este entorno.

## Aplicaciones Integradas

El proyecto embebe las siguientes aplicaciones de 32 bits (x86) dentro de ventanas de C#:

- **Block de Notas**
- **Notepad++**
- **Calculadora**
- **Everything** (motor de búsqueda de archivos)
- **Simulación de la ventana "Ejecutar" (win+r)**
- **Botón adicional** para agregar nuevos programas personalizados

> **Nota:** Solo se pueden embeber aplicaciones de 32 bits (x86) debido a la simplicidad de sus interfaces y la menor cantidad de restricciones, en comparación con las aplicaciones de 64 bits (x64) basadas en UWP (Plataforma Universal de Windows).

## Configuración del Entorno

Este proyecto se desarrolló utilizando Visual Studio Code en lugar de Visual Studio. Para habilitar esta configuración, fue necesario instalar el SDK de .NET para compilar y ejecutar la aplicación.

### Compilación y Ejecución

Para compilar y ejecutar la aplicación, se utilizaron los siguientes comandos en la terminal de Visual Studio Code:

```bash
dotnet build
dotnet run
```
## Estructura de Archivos del Proyecto

Los archivos están organizados de la siguiente manera:

- **Form1.cs**: Archivo principal que contiene la lógica de creación de ventanas y botones, así como la gestión de eventos para embeber las aplicaciones.

Los archivos siguientes contienen la lógica para abrir y embeber cada aplicación externa:

- **NotepadForm.cs**: Implementa la lógica para embeber el Bloc de notas.
- **CalculatorForm.cs**: Contiene la lógica de embebido para la Calculadora.
- **Program1.cs**: Embeber Notepad++.
- **Program2.cs**: Embeber Everything.
- **Program3.cs**: Archivo para personalizar la aplicación embebida; permite agregar la ruta (`path`) del archivo `.exe` de cualquier programa x86.
- **RunForm.cs**: Emula la ventana "Ejecutar" (win+r) de Windows.

> **Comentarios en el Código:** Se han añadido comentarios en `CalculatorForm.cs` para explicar el funcionamiento del código y en `Form1.cs`, específicamente en la sección de la calculadora, que explica el proceso de embebido. El resto de aplicaciones utilizan el mismo código base, cambiando únicamente las variables específicas para cada programa.

### Creación del Proyecto

El proyecto se creó con el siguiente comando:

```bash
dotnet new winforms -o EmbedApplications
```

## Personalización del Proyecto

Este proyecto está diseñado para ser extendible. Puedes agregar nuevas aplicaciones x86 simplemente siguiendo la estructura de los archivos ya existentes y utilizando el archivo `Program3.cs` para personalizar el path del `.exe` deseado.

## Hazlo Tú

Para empezar a trabajar con este proyecto, sigue estos pasos:

### 1. Clona el Repositorio

Primero, clona el repositorio a tu máquina local. Abre la terminal y ejecuta el siguiente comando:

```bash
git clone https://github.com/usuario/nombre-del-repo.git
```

### 2. Abre el Proyecto en Visual Studio Code

Una vez que hayas clonado el repositorio, navega a la carpeta del proyecto y ábrelo en Visual Studio Code. Puedes hacer esto desde la terminal con los siguientes comandos:

```bash
cd nombre-del-repo
code .
```

### 3. Instala las Dependencias

Si no tienes el SDK de .NET instalado, asegúrate de instalarlo antes de proceder. Luego, puedes instalar cualquier dependencia necesaria para el proyecto con el siguiente comando:

```bash
dotnet restore
```

### 4. Compila y Ejecuta la Aplicación

Finalmente, para compilar y ejecutar la aplicación, usa los siguientes comandos en la terminal de Visual Studio Code:

```bash
dotnet build
dotnet run
```



## Requisitos y Recomendaciones

- **SDK de .NET**: Asegúrate de tener instalado el SDK de .NET compatible con WinForms.
- **Aplicaciones de 32 bits (x86)**: Debido a las limitaciones de las aplicaciones x64 basadas en UWP, solo se soportan aplicaciones de 32 bits.


