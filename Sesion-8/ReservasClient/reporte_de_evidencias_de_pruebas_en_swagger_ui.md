# Evidencia de Funcionamiento de la API mediante Swagger UI

Este documento contiene la guía de evidencias y todos los cuerpos JSON utilizados para validar cada endpoint, las reglas de negocio y la seguridad JWT en `https://localhost:7248/swagger/index.html`.

---

## 1. Generación de Token JWT (`POST /api/Auth/login`)
* **Acción:** Se ejecuta el endpoint `/api/Auth/login` haciendo clic en *Try it out* > *Execute*.
* **Código devuelto:** `200 OK`
* **Response Body obtenido:**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiQWRtaW5pc3RyYWRvciIsImp0aSI6Ijc1YWVjMjdkLTA5NjItNDJlNi05N2JkLTMzMjFhZThmYTQ2MCIsImV4cCI6MTc5MTg0NzU1NX0.n6qDgQEzSw2KVXLIU_i3wNR_tENFIEsOTqD-H0xH6sc"
}
```
*(Insertar captura de pantalla del endpoint `/api/Auth/login` con código 200).*

---

## 2. Autorización con Bearer Token en Swagger UI (`Authorize`)
* **Acción:** Se abre el botón verde **Authorize** (`Bearer (apiKey)`) y en el campo **Value** se ingresa:
```text
Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiQWRtaW5pc3RyYWRvciIsImp0aSI6Ijc1YWVjMjdkLTA5NjItNDJlNi05N2JkLTMzMjFhZThmYTQ2MCIsImV4cCI6MTc5MTg0NzU1NX0.n6qDgQEzSw2KVXLIU_i3wNR_tENFIEsOTqD-H0xH6sc
```
* **Resultado obtenido:** El estado cambia a **Authorized** (`Value: ******`) y los candados de los endpoints se cierran.
*(Insertar captura de la ventana modal `Available authorizations` mostrando `Authorized`).*

---

## 3. Prueba de `POST /api/Reservas` (Registrar una nueva reserva)

### 3.1. Caso de Éxito (`201 Created`)
* **JSON de entrada (Request Body):**
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
* **Respuesta obtenida (`201 Created`):**
```json
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
```
*(Insertar captura de pantalla del `POST /api/Reservas` mostrando `201 Created`).*

### 3.2. Caso de Validación de Errores (`400 Bad Request`)
* **JSON de entrada con datos inválidos (Request Body):**
```json
{
  "nombreSala": "",
  "fechaReserva": "2026-10-20",
  "horaInicio": "14:00:00",
  "horaFin": "12:00:00",
  "responsable": "",
  "cantidadAsistentes": 0,
  "motivo": "Reunión de prueba"
}
```
* **Respuesta obtenida (`400 Bad Request`):**
```json
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "NombreSala": ["El nombre de la sala es obligatorio."],
    "Responsable": ["El nombre del responsable es obligatorio."],
    "CantidadAsistentes": ["La cantidad de asistentes debe ser mayor a cero."],
    "HoraFin": ["La hora de fin debe ser posterior a la hora de inicio."]
  }
}
```
*(Insertar captura de pantalla del `POST /api/Reservas` mostrando `400 Bad Request`).*

---

## 4. Prueba de `GET /api/Reservas` y `GET /api/Reservas?fecha={fecha}`

* **Sin filtro (`GET /api/Reservas`):** Devuelve `200 OK` con todas las reservas activas.
* **Con filtro (`GET /api/Reservas?fecha=2026-10-20`):**
  * **Parámetro `fecha`:** `2026-10-20`
  * **Respuesta obtenida (`200 OK`):**
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
*(Insertar captura de pantalla del `GET /api/Reservas`).*

---

## 5. Prueba de `GET /api/Reservas/{id}` (Obtener por Id y Validar 404)

* **Con ID existente:**
  * **Parámetro `id`:** `3fa85f64-5717-4562-b3fc-2c963f66afa6`
  * **Código devuelto:** `200 OK` con el detalle JSON de la reserva.
* **Con ID inexistente (`404 Not Found`):**
  * **Parámetro `id`:** `00000000-0000-0000-0000-000000000000`
  * **Respuesta obtenida (`404 Not Found`):**
```json
{
  "message": "Reserva no encontrada."
}
```
*(Insertar captura de pantalla del `GET /api/Reservas/{id}`).*

---

## 6. Prueba de `PUT /api/Reservas/{id}` (Actualizar una reserva existente)

* **Parámetro `id`:** `3fa85f64-5717-4562-b3fc-2c963f66afa6`
* **JSON de entrada (Request Body):**
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
* **Respuesta obtenida (`200 OK`):**
```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "nombreSala": "Sala Secundaria (Actualizada)",
  "fechaReserva": "2026-10-22T00:00:00",
  "horaInicio": "15:00:00",
  "horaFin": "17:30:00",
  "responsable": "Ana Rojas",
  "cantidadAsistentes": 12,
  "motivo": "Revisión de presupuesto y métricas",
  "estado": "Pendiente"
}
```
*(Insertar captura de pantalla del `PUT /api/Reservas/{id}` mostrando `200 OK`).*

---

## 7. Prueba de `DELETE /api/Reservas/{id}` (Cancelar o eliminar una reserva)

* **Parámetro `id`:** `3fa85f64-5717-4562-b3fc-2c963f66afa6`
* **Respuesta obtenida (`200 OK`):**
```json
{
  "message": "Reserva cancelada exitosamente."
}
```
*(Insertar captura de pantalla del `DELETE /api/Reservas/{id}` mostrando `200 OK`).*