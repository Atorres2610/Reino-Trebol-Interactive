# Evalución técnica Reino Trebol .NET 🍀
Es la resolución de un examen técnico para la empresa Interactive.

## Índice de contenido
1. [Advertencia](#advertencia)
2. [Inicio rápido](#inicio-rapido)
3. [Nota](#nota)
4. [Licencia](#licencia)

## Advertencia
Antes de ejecutar el proyecto debe de cambiar la cadena de conexión en el archivo appsettings.json que se encuentra en la siguiente ruta:

	- \Reino Trebol .NET\ReinoTrebol.API\appsettings.json

Recuerde que debe ser una cadena de conexión válida de Postgresql.

## Inicio rápido
Debe contar con los siguientes programas y base de datos:

	- VisualStudio 2022
	- .NET 7
	- Base de datos Postgresql

Se abre la solución del proyecto con VisualStudio 2022 y se ejecuta con "CTRL + F5" o "F5", esto creará la base de datos y
levantará el proyecto, se deben visualizar dos ventanas como se muestra en la siguiente imagen:
<br />

<img src="https://raw.githubusercontent.com/Atorres2610/Reino-Trebol-Interactive/master/ArchivosDocumentacion/Imagen1.png" data-canonical-src="https://gyazo.com/eb5c5741b6a9a16c692170a41a49c858.png" width="600">

En caso no se levanten los dos proyecto debe realizar lo siguientes pasos:

	- Darle click derecho la solución, seleccionar "Propiedades"
	- Aparecerá un recuadro donde debe seleccionar "Multipe startup proyects"
	- En la columna "Action" debe de cambiar la opción de "None" a "Start" para el proyecto 
		"ReinoTrebol.API" y "ReinoTrebol.Web"
	- Por último en aceptar
	
También se puede guiar de las siguientes imágenes:

<img src="https://raw.githubusercontent.com/Atorres2610/Reino-Trebol-Interactive/master/ArchivosDocumentacion/Imagen2.png" data-canonical-src="https://gyazo.com/eb5c5741b6a9a16c692170a41a49c858.png" width="300">

<img src="https://raw.githubusercontent.com/Atorres2610/Reino-Trebol-Interactive/master/ArchivosDocumentacion/Imagen3.png" data-canonical-src="https://gyazo.com/eb5c5741b6a9a16c692170a41a49c858.png" width="600">

## Nota
El proyecto web no está terminado, solo pude avanzar cierta parte de la solicitud, como el aprobar, rechazar, eliminar, actualizar y listar, me faltó el poder crear una solicitud; pero el API si está completa.

## Licencia

[MIT](https://choosealicense.com/licenses/mit/)
