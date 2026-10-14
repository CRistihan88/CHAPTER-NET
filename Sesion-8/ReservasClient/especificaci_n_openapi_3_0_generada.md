{
  "openapi": "3.0.1",
  "info": {
    "title": "API Reservas",
    "version": "v1"
  },
  "paths": {
    "/api/Auth/login": {
      "post": {
        "tags": [
          "Auth"
        ],
        "summary": "Genera un token JWT de prueba.",
        "responses": {
          "200": {
            "description": "OK"
          }
        }
      }
    },
    "/api/Reservas": {
      "get": {
        "tags": [
          "Reservas"
        ],
        "summary": "Obtiene todas las reservas o las filtra por fecha si se proporciona el parámetro.",
        "parameters": [
          {
            "name": "fecha",
            "in": "query",
            "description": "Fecha opcional para filtrar reservas (YYYY-MM-DD).",
            "schema": {
              "type": "string",
              "format": "date-time"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "OK",
            "content": {
              "application/json": {
                "schema": {
                  "type": "array",
                  "items": {
                    "$ref": "#/components/schemas/ReservaResponseDto"
                  }
                }
              }
            }
          }
        }
      },
      "post": {
        "tags": [
          "Reservas"
        ],
        "summary": "Registra una nueva reserva de sala.",
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/ReservaRequestDto"
              }
            }
          }
        },
        "responses": {
          "201": {
            "description": "Created",
            "content": {
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ReservaResponseDto"
                }
              }
            }
          },
          "400": {
            "description": "Bad Request"
          },
          "401": {
            "description": "Unauthorized"
          }
        }
      }
    },
    "/api/Reservas/{id}": {
      "get": {
        "tags": [
          "Reservas"
        ],
        "summary": "Obtiene una reserva específica por su identificador único.",
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "OK",
            "content": {
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ReservaResponseDto"
                }
              }
            }
          },
          "404": {
            "description": "Not Found"
          }
        }
      },
      "put": {
        "tags": [
          "Reservas"
        ],
        "summary": "Actualiza los datos de una reserva existente.",
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          }
        ],
        "requestBody": {
          "content": {
            "application/json": {
              "schema": {
                "$ref": "#/components/schemas/ReservaRequestDto"
              }
            }
          }
        },
        "responses": {
          "200": {
            "description": "OK",
            "content": {
              "application/json": {
                "schema": {
                  "$ref": "#/components/schemas/ReservaResponseDto"
                }
              }
            }
          },
          "400": {
            "description": "Bad Request"
          },
          "401": {
            "description": "Unauthorized"
          },
          "404": {
            "description": "Not Found"
          }
        }
      },
      "delete": {
        "tags": [
          "Reservas"
        ],
        "summary": "Cancela una reserva existente cambiando su estado.",
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "required": true,
            "schema": {
              "type": "string",
              "format": "uuid"
            }
          }
        ],
        "responses": {
          "200": {
            "description": "OK"
          },
          "401": {
            "description": "Unauthorized"
          },
          "404": {
            "description": "Not Found"
          }
        }
      }
    }
  },
  "components": {
    "schemas": {
      "ReservaRequestDto": {
        "required": [
          "cantidadAsistentes",
          "fechaReserva",
          "horaFin",
          "horaInicio",
          "nombreSala",
          "responsable"
        ],
        "type": "object",
        "properties": {
          "nombreSala": {
            "minLength": 1,
            "type": "string"
          },
          "fechaReserva": {
            "type": "string",
            "format": "date-time"
          },
          "horaInicio": {
            "type": "string",
            "format": "date-span"
          },
          "horaFin": {
            "type": "string",
            "format": "date-span"
          },
          "responsable": {
            "minLength": 1,
            "type": "string"
          },
          "cantidadAsistentes": {
            "maximum": 2147483647,
            "minimum": 1,
            "type": "integer",
            "format": "int32"
          },
          "motivo": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      },
      "ReservaResponseDto": {
        "type": "object",
        "properties": {
          "id": {
            "type": "string",
            "format": "uuid"
          },
          "nombreSala": {
            "type": "string",
            "nullable": true
          },
          "fechaReserva": {
            "type": "string",
            "format": "date-time"
          },
          "horaInicio": {
            "type": "string",
            "format": "date-span"
          },
          "horaFin": {
            "type": "string",
            "format": "date-span"
          },
          "responsable": {
            "type": "string",
            "nullable": true
          },
          "cantidadAsistentes": {
            "type": "integer",
            "format": "int32"
          },
          "motivo": {
            "type": "string",
            "nullable": true
          },
          "estado": {
            "type": "string",
            "nullable": true
          }
        },
        "additionalProperties": false
      }
    },
    "securitySchemes": {
      "Bearer": {
        "type": "apiKey",
        "description": "Escriba 'Bearer ' (con un espacio) y pegue su token.",
        "name": "Authorization",
        "in": "header",
        "scheme": "Bearer",
        "bearerFormat": "JWT"
      }
    }
  },
  "security": [
    {
      "Bearer": []
    }
  ]
}