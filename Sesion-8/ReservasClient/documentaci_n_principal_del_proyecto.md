# Sistema de Gestión de Reservas de Salas - API REST & Cliente OpenAPI

## 1. Descripción breve de la solución
Esta solución implementa una API RESTful desarrollada en **ASP.NET Core** para gestionar la reserva de salas de reuniones. El sistema permite listar reservas, filtrarlas por fecha, consultar por identificador único (`Guid`), registrar nuevas reservas, actualizarlas y cancelarlas.

La arquitectura incluye:
* **Validaciones de negocio** mediante Data Annotations y `IValidatableObject` (verificación de campos obligatorios, aforo mayor a cero y validación de que la hora de fin sea posterior a la hora de inicio).
* **Seguridad y Autenticación** implementada con **JWT (JSON Web Tokens)** bajo el esquema `Bearer`, protegiendo las operaciones de escritura (`POST`, `PUT`, `DELETE`).
* **Documentación interactiva OpenAPI 3.0** generada con **Swashbuckle (Swagger UI)**, incluyendo soporte para autenticación e inyección del token en las cabeceras HTTP (`Authorization`).
* **Cliente .NET tipado** autogenerado a partir de la especificación `openapi.json` utilizando herramientas de OpenAPI/NSwag en una aplicación de consola (`ReservasConsolaClient`).

---

## 2. Estructura de Entregables
1. **`ReservasClient/CodigoFuenteAPI.cs`**: Código fuente de la Web API en ASP.NET Core (Controladores, DTOs, Modelos y configuración en `Program.cs`).
2. **`openapi.json`**: Archivo de especificación OpenAPI 3.0 generado por el servidor.
3. **`Evidencias_Swagger.md`**: Demostración y guía de pruebas de la API funcionando mediante Swagger UI con todos los JSON de prueba.
4. **`ReservasConsolaClient/ClienteOpenApi.cs`**: Proyecto de consola en C# que contiene el cliente autogenerado (`ReservasApiClient`) y su flujo de consumo con JWT en `Program.cs`.
5. **`README.md`**: Documento principal con la descripción de la solución, pasos de ejecución, uso de Swagger UI, JSON de prueba y explicación de generación del cliente .NET.

---

## 3. Pasos para ejecutar el proyecto

### Requisitos previos
* .NET 8.0 SDK o .NET 9.0 SDK instalado.
* Visual Studio 2022 (con la carga de trabajo de desarrollo web y ASP.NET) o Visual Studio Code.

### Ejecución desde Visual Studio 2022
1. Abrir el archivo de solución `ReservasClient.sln`.
2. En el **Explorador de soluciones**, hacer clic derecho sobre el proyecto **`ReservasClient`** y seleccionar **Establecer como proyecto de inicio**.
3. Presionar **F5** (o hacer clic en el botón de inicio `https`) para compilar y levantar el servidor Kestrel.
4. Para probar el cliente de consola sin detener la API: hacer clic derecho sobre el proyecto **`ReservasConsolaClient`** > **Depurar** > **Iniciar nueva instancia**.

### Ejecución desde la terminal (.NET CLI)
```bash
cd ReservasClient
dotnet restore
dotnet run --launch-profile https
```

---

## 4. Explicación de cómo acceder y usar Swagger UI

1. Una vez iniciada la API, el navegador se abrirá automáticamente en la interfaz de Swagger UI a través de la dirección:
   ```text
   https://localhost:7248/swagger/index.html
   ```
2. **Cómo autenticarse con JWT en Swagger UI:**
   * Desplegar el endpoint **`POST /api/Auth/login`**, hacer clic en **Try it out** y luego en **Execute**.
   * Copiar únicamente el valor del token devuelto en el cuerpo de la respuesta (`eyJhbGci...`).
   * Subir al inicio de la página y hacer clic en el botón verde **Authorize**.
   * En el campo **Value**, escribir la palabra `Bearer`, dejar un espacio en blanco y pegar el token copiado:
     ```text
     Bearer eyJhbGciOiJIUzI1NiIs...
     ```
   * Hacer clic en **Authorize** y luego en **Close**.
3. El archivo de especificación OpenAPI crudo se puede visualizar o descargar desde:
   ```text
   https://localhost:7248/swagger/v1/swagger.json
   ```

---

## 5. JSON de Prueba para Validar Todos los Endpoints

### 5.1. `POST /api/Reservas` (Registrar una nueva reserva)
* **JSON válido (Prueba de éxito - Devuelve `201 Created`):**
```json
{
  "nombreSala": "Sala Principal",
  "fechaReserva": "2026-10-20",
  "horaInicio": "09:00:00",
  "horaFin": "11:00:00",
  "responsable": "Carlos Mendoza",
  "cantidadAsistentes": 8,
  "motivo": "Reunión de planificación"
}
```

* **JSON inválido (Prueba de validaciones - Devuelve `400 Bad Request`):**
```json
{
  "nombreSala": "",
  "fechaReserva": "2026-10-20",
  "horaInicio": "14:00:00",
  "horaFin": "12:00:00",
  "responsable": "",
  "cantidadAsistentes": 0,
  "motivo": "Reunión con errores de validación"
}
```

### 5.2. `GET /api/Reservas` (Obtener todas las reservas)
* **Parámetros:** Dejar el campo `fecha` vacío.
* **Respuesta esperada (`200 OK`):**
```json
[
  {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "nombreSala": "Sala Principal",
    "fechaReserva": "2026-10-20T00:00:00",
    "horaInicio": "09:00:00",
    "horaFin": "11:00:00",
    "responsable": "Carlos Mendoza",
    "cantidadAsistentes": 8,
    "motivo": "Reunión de planificación",
    "estado": "Pendiente"
  }
]
```

### 5.3. `GET /api/Reservas?fecha={fecha}` (Filtrar reservas por fecha)
* **Parámetro Query `fecha`:** `2026-10-20`
* **Respuesta esperada (`200 OK`):** Lista JSON únicamente con las reservas correspondientes a la fecha `2026-10-20`.

### 5.4. `GET /api/Reservas/{id}` (Obtener una reserva por su Id)
* **Parámetro Path `id`:** `(Pegar el GUID generado en el POST, ej: 3fa85f64-5717-4562-b3fc-2c963f66afa6)`
* **Respuesta esperada (`200 OK`):** Objeto JSON de la reserva solicitada (o `404 Not Found` si el ID no existe).

### 5.5. `PUT /api/Reservas/{id}` (Actualizar una reserva existente)
* **Parámetro Path `id`:** `(Pegar el GUID generado en el POST)`
* **JSON para el Request Body (Devuelve `200 OK`):**
```json
{
  "nombreSala": "Sala Secundaria (Actualizada)",
  "fechaReserva": "2026-10-22",
  "horaInicio": "15:00:00",
  "horaFin": "17:30:00",
  "responsable": "Ana Rojas",
  "cantidadAsistentes": 12,
  "motivo": "Revisión de presupuesto y métricas"
}
```

### 5.6. `DELETE /api/Reservas/{id}` (Cancelar o eliminar una reserva)
* **Parámetro Path `id`:** `(Pegar el GUID generado en el POST)`
* **Respuesta esperada (`200 OK`):**
```json
{
  "message": "Reserva cancelada exitosamente."
}
```

---

## 6. Explicación breve de cómo se generó el cliente .NET

El cliente .NET (`ReservasApiClient`) fue autogenerado a partir de la especificación OpenAPI 3.0 expuesta por la propia Web API en `Program.cs` mediante `Swashbuckle.AspNetCore` (`AddSwaggerGen` y `UseSwagger()`):

1. **Extracción de la especificación OpenAPI:** 
   Con la API en ejecución, se accedió al documento generado automáticamente por el middleware `app.UseSwagger()` en la ruta `https://localhost:7248/swagger/v1/swagger.json` y se descargó localmente como `swagger.json` (`openapi.json`).
2. **Creación del proyecto consumidor:** 
   Se agregó a la solución un proyecto de Aplicación de Consola en .NET llamado **`ReservasConsolaClient`**.
3. **Generación automática de código con NSwag (Connected Services):**
   * En Visual Studio, se hizo clic derecho sobre `ReservasConsolaClient` > **Agregar > Servicio conectado (Connected Service) > Referencias de servicio (OpenAPI)**.
   * Se seleccionó el archivo `swagger.json` descargado.
   * Se configuró el generador asignando el nombre de clase **`ReservasApiClient`** y el espacio de nombres **`ReservasConsolaClient`**.
4. **Integración con Autenticación JWT:**
   Dado que en `Program.cs` se definió el esquema de seguridad en el encabezado `Authorization` (`ParameterLocation.Header`), el cliente de consola obtiene primero un token válido llamando a `POST /api/Auth/login`, lo asigna en `httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token)` e invoca los métodos tipados del cliente (`ReservasPOSTAsync`, `ReservasAllAsync`, `ReservasGETAsync`, `ReservasPUTAsync` y `ReservasDELETEAsync`).