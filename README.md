# Evalución técnica Reino Trebol .NET 🍀
Es la resolución de un examen técnico para la empresa Interactive.

## Índice de contenido
1. [Inicio rápido](#inicio-rapido)
2. [Advertencia](#advertencia)
3. [Nota](#nota)

## Inicio rápido
Debe contar con los siguientes programas y base de datos:

	- VisualStudio 2022
	- .NET 7
	- Base de datos Postgresql

Se abre la solución del proyecto con VisualStudio 2022 y se ejecuta con "CTRL + F5" o "F5", esto creará la base de datos y
levantará el proyecto, se deben visualizar dos ventanas como se muestra en la siguiente imagen:
![Imagen1](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/th5xamgrr6se0x5ro4g6.png)

En caso no se levantes los dos proyecto debe realizar lo siguientes pasos:

	- Darle click derecho la solución, seleccionar "Propiedades"
	- Aparecerá un recuadro donde debe seleccionar "Multipe startup proyects"
	- En la columna "Action" debe de cambiar la opción de "None" a "Start" para el proyecto "ReinoTrebol.API" y "ReinoTrebol.Web"
	- Por último en aceptar

![Imagen2](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/th5xamgrr6se0x5ro4g6.png)
![Imagen3](https://dev-to-uploads.s3.amazonaws.com/uploads/articles/th5xamgrr6se0x5ro4g6.png)

## Advertencia
Antes de ejecutar el proyecto debe de cambiar la cadena de conexión en el archivo appsettings.json que se encuentra en la siguiente ruta:

	- \Reino Trebol .NET\ReinoTrebol.API\appsettings.json

Recuerde que debe ser una cadena de conexión válida de Postgresql.

## Nota
El proyecto web no está terminado, solo puede avanzar cierta parte de la solicitud, como el aprobar, rechazar, eliminar, actualizar y listar, me faltó el poder crear una solicitud; pero el API si está completa.