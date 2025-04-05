# GestionProductosDeSeguros
Descripción
Este proyecto permite gestionar productos de seguros mediante una API y una interfaz de usuario en Blazor.

Pasos para Ejecutar el Proyecto

1-Crear la Base de Datos
  Los scripts SQL se encuentran en la carpeta ScriptSQL dentro de la API.
  Ejecuta el script llamado ScriptBaseDeDatos para crear la base de datos y agregar datos estáticos a las tablas.

2-Ejecutar Procedimientos Almacenados
 Asegúrate de que los siguientes procedimientos estén creados:
   ActualizarProducto
   BuscarProductos
   CrearProducto
   EliminarProducto
   ObtenerPorId
   ObtenerProductos
   
3-Configurar la Conexión a la Base de Datos
 Abre el archivo appsettings.json y modifica la cadena de conexión

"ConnectionStrings": {
  "Cnn": "Server=DESKTOP-H891OI5; Initial Catalog=Productos; Integrated Security=True"
}

Cambia Server por el nombre de tu servidor y Initial Catalog por el nombre de tu base de datos.

4-Ejecutar la API
 Inicia el proyecto de la API. La API cuenta con 5 endpoints para:
   Crear
   Obtener
   Buscar
   Obtener por ID
   Editar
   Eliminar

5-Ejecutar el Proyecto de Blazor
 Inicia el proyecto de Blazor. Al iniciar, serás llevado a la página principal.
 Desde el layout, podrás acceder a la lista de productos.