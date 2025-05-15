# Prueba Técnica Toka

Este repositorio contiene la solución a los ejercicios 1 y 2 de la prueba técnica de Toka. La solución está dividida en dos proyectos:

- **Backend**: API REST en .NET Core para gestión de personas físicas.
- **Frontend**: Aplicación ASP.NET Core MVC que consume la API para mostrar, crear, editar y eliminar registros.

# Backend
Se desarrolló una API RESTful en .NET Core encargada de gestionar registros de personas físicas. Esta API expone endpoints para realizar operaciones CRUD (Crear, Leer, Actualizar y Eliminar). La arquitectura está basada en buenas prácticas de separación de responsabilidades, con validaciones básicas y soporte para serialización/deserialización de datos JSON.
Endpoints desarrollados:
- GET /api/personasfisicas – Lista todas las personas físicas.
- POST /api/personasfisicas – Crea un nuevo registro.
- PUT /api/personasfisicas – Actualiza un registro existente.
- DELETE /api/personasfisicas/{id} – Elimina un registro por ID.

# Frontend
## 📌 Ejercicio 1 - Autenticación
- Se realiza una autenticación contra un endpoint externo.
- El token recibido se guarda en la sesión y se utiliza para futuras peticiones.

## 📌 Ejercicio 2 - CRUD de Personas Físicas
- Se desarrolló un módulo completo para personas físicas:
  - Crear, Leer, Actualizar y Eliminar.
  - Uso de modales para agregar y editar.
  - Confirmación con modal al eliminar.
  - Validaciones en el frontend y backend.

## ❌ Ejercicio 3 - Reportes
Por problemas con la API externa, no fue posible completar este ejercicio. La API no respondió correctamente y no se recibió el aviso de privacidad mencionado.
