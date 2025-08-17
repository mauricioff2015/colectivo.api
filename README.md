# Despliegue de API .NET 8 en Docker con Portainer (Stack Git)

Este proyecto está listo para ser desplegado como stack en Portainer usando Git.

## Requisitos
- Portainer con soporte para Stacks Git
- Red Docker existente llamada `backend`
- SQL Server accesible desde la red Docker

## Despliegue rápido
1. Sube este repositorio a GitHub.
2. En Portainer, crea un nuevo stack usando la opción **Git repository**.
3. Usa la URL de tu repositorio y selecciona la rama principal.
4. Portainer detectará el `docker-compose.yml` y construirá la imagen usando el `Dockerfile`.
5. Ajusta la variable de entorno `ConnectionStrings__ColectivoDb` en Portainer si es necesario.
6. El contenedor se expondrá en el puerto 5000 y se conectará a la red `backend`.

## Variables de entorno
Puedes definir la cadena de conexión a SQL Server en Portainer como variable de entorno:
ConnectionStrings__ColectivoDb=Server=sqlserver-express;Database=ColectivoDb;User Id=sa;Password=TU_PASSWORD;TrustServerCertificate=True;Encrypt=False
## Notas
- El contexto de build es la carpeta `Colectivo.Api`.
- El servicio se llama `api-dotnet` y expone el puerto 5000.
- El contenedor se conecta a la red Docker externa `backend`.
- El Dockerfile y el docker-compose.yml están listos para producción.

---

**Estructura del repositorio:**
/ (raíz)
  |-- Colectivo.Api/
      |-- Dockerfile
      |-- ... (código fuente y archivos publicados)
  |-- docker-compose.yml
  |-- README.md
