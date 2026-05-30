# Sistema de reserva de recursos académicos

Aplicación web para la gestión y reserva de recursos académicos —aulas, laboratorios, equipo audiovisual y demás activos institucionales— por parte de catedráticos. Permite consultar la disponibilidad de un recurso, apartarlo durante un intervalo de tiempo para una clase, examen, asesoría u otro motivo, y mantiene una bitácora de las notificaciones generadas a partir de cada reserva.

## Características

- Gestión de recursos clasificados por categoría (aulas, laboratorios, equipo, etc.).
- Reservas con intervalo de fechas, motivo y curso asociado.
- Control de concurrencia optimista mediante `RowVersion` para evitar dobles reservas simultáneas.
- Autenticación de catedráticos con contraseña hasheada (nunca en texto plano).
- Bloqueo automático de cuentas tras varios intentos fallidos de inicio de sesión.
- Registro de último acceso y baja lógica de usuarios sin pérdida de historial.
- Bitácora de notificaciones con tipo de evento, fecha de envío, resultado y mensaje de error.
- Catálogos administrables: categorías de recurso, motivos de reserva, cursos.

## Stack tecnológico

### Frontend
- HTML5 — estructura
- CSS3 — estilos y diseño
- JavaScript — interacción y consumo de la API vía `Fetch API`

### Backend
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core como ORM

### Base de datos
- Microsoft SQL Server
- Hospedada en [Somee.com](https://somee.com)

## Arquitectura

El sistema sigue una arquitectura clásica de tres capas:

1. Capa de presentación. Cliente web (HTML, CSS, JavaScript) que se ejecuta en el navegador y consume la API mediante peticiones HTTPS con payloads JSON.
2. Capa de lógica. API REST en `ASP.NET Core` con controladores que exponen endpoints, servicios que contienen las reglas de negocio, modelos/DTOs y `Entity Framework Core` para el acceso a datos.
3. Capa de datos. Instancia de `Microsoft SQL Server` hospedada en Somee, accedida por TCP/IP sobre el puerto 1433 con el proveedor `Microsoft.Data.SqlClient`.

## Modelo de datos

El esquema gira en torno a la entidad `Reserva`, que cruza las dimensiones del dominio:

| Entidad | Rol |
|---|---|
| `Recurso` | Activo reservable (aula, laboratorio, equipo). |
| `Categoria` | Clasificación de recursos. |
| `Catedratico` | Usuario del sistema con datos de identidad, autenticación y seguridad. |
| `Curso` | Curso impartido por un catedrático; da contexto académico a la reserva. |
| `Motivo` | Catálogo de razones (clase regular, examen, evento, etc.). |
| `Reserva` | Transacción central: quién, qué, cuándo y por qué. |
| `LogNotificacion` | Bitácora de avisos generados a partir de eventos sobre reservas. |

## Requisitos previos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Acceso a una base de datos SQL Server (local o cuenta en Somee.com)
- Navegador web moderno (Chrome, Firefox, Edge)
- Editor de código: Visual Studio 2022, VS Code o JetBrains Rider

## Configuración

1. Clona el repositorio:
   ```bash
   git clone https://github.com/[usuario]/[repositorio].git
   cd [repositorio]
   ```

2. Configura la cadena de conexión en `appsettings.json` (o mejor, en `appsettings.Development.json` para no subirla al repo):
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "workstation id=...;packet size=4096;user id=...;pwd=...;data source=...;initial catalog=..."
     }
   }
   ```

3. Aplica las migraciones de Entity Framework Core:
   ```bash
   dotnet ef database update
   ```

4. Ejecuta el backend:
   ```bash
   dotnet run --project backend
   ```

5. Abre el frontend en tu navegador o sírvelo con cualquier servidor estático.

## Estructura del proyecto

```
/
├── backend/                 # API en .NET 8
│   ├── Controllers/         # Endpoints REST
│   ├── Services/            # Lógica de negocio
│   ├── Models/              # Entidades y DTOs
│   ├── Data/                # DbContext y migraciones
│   ├── appsettings.json
│   └── Program.cs
├── frontend/                # Cliente web
│   ├── index.html
│   ├── css/
│   └── js/
└── README.md
```

## Autores

- Daniel González
- Jonathan Yos
- Nelson Lopez
- Brandon Tij
![Coverage](https://img.shields.io/badge/Coverage-85%25-brightgreen)
