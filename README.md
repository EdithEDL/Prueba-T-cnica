# Catálogo de Productos - Windows Forms (C#) y MySQL

## Descripción
Este proyecto es una aplicación de escritorio desarrollada en **Windows Forms** utilizando **C#** y **MySQL** como base de datos. La aplicación permite gestionar un **Catálogo de Productos** y llevar a cabo diversas operaciones como guardar, actualizar y eliminar productos. Además, incluye un módulo de **ventas** que permite visualizar y gestionar las ventas generadas, así como la capacidad de **descargar reportes** en formato **Excel**.

## Funcionalidades

### Formulario de Catálogo de Productos
- **Agregar Producto**: Permite ingresar nuevos productos al catálogo con sus respectivos detalles como nombre, descripción, precio y cantidad.
- **Actualizar Producto**: Permite modificar la información de productos existentes en la base de datos.
- **Eliminar Producto**: Permite eliminar productos del catálogo de manera permanente.
- **Visualización de Productos**: Muestra una lista de todos los productos disponibles en el catálogo.

### Formulario de Ventas
- **Generar Venta**: Permite realizar ventas seleccionando productos del catálogo, especificando las cantidades y generando un registro de la venta.
- **Ver Ventas Generadas**: Muestra un historial de todas las ventas realizadas, incluyendo detalles como la fecha de la venta, productos vendidos y montos totales.
- **Descargar Reportes en Excel**: Genera reportes de ventas en formato **Excel**, que pueden descargarse y utilizarse para análisis y registro contable.

## Requisitos
- **Sistema Operativo**: Windows
- **Entorno de Desarrollo**: Visual Studio
- **Base de Datos**: MySQL
- **Bibliotecas**:
  - `MySql.Data` para la conexión con la base de datos.
  - `ClosedXML` para la generación de reportes en Excel.

## Configuración del Proyecto

### 1. Clonar el Repositorio
Clona este repositorio en tu máquina local:

```bash
https://github.com/EdithEDL/Prueba-T-cnica.git

## Ejecución del Proyecto 
Abre el proyecto en Visual Studio.
Restaura los paquetes **NuGe**t si es necesario.
Ejecuta la aplicación para abrir el formulario principal, donde podrás gestionar el catálogo de productos y las ventas.
