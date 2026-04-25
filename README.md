# Ing_Software-G7-Asignaci-n-de-recursos-de-la-Universidad


# API REST - Autenticación JWT

API REST desarrollada en **.NET** que implementa autenticación mediante **JSON Web Tokens (JWT)**.  
Actualmente la API expone un único endpoint de **Login**, el cual valida credenciales y genera un token JWT que será utilizado para consumir futuros endpoints protegidos.

---

## 🚀 Tecnologías utilizadas

- .NET
- ASP.NET Core Web API
- Autenticación JWT
- C#

---

## 🔐 Autenticación

La API utiliza **JWT (JSON Web Token)** para la autenticación.  
Al realizar un login exitoso, se genera un token que debe enviarse en las solicitudes posteriores a través del header:

Authorization: Bearer {token}

---

## 📌 Endpoint disponible

### Login

POST /api/auth/login

Permite autenticar al usuario y generar un token JWT.

---

## 📥 Request

### Headers

Content-Type: application/json

### Body

```json
{
  "user": "usuario",
  "password": "password"
}
```

### Modelo LoginRequest

```csharp
public class LoginRequest
{
    public LoginRequest()
    {
        this.User = string.Empty;
        this.Password = string.Empty;
    }

    public string User { get; set; }
    public string Password { get; set; }
}
```
---

## 📤 Response

La respuesta del servicio se devuelve dentro de un objeto genérico RespuestaMensaje<T>.

### Respuesta exitosa (200 OK)
```json
{
  "ocurrioError": false,
  "mensajeCliente": "Login exitoso",
  "mensajeTecnico": "",
  "codigoError": "",
  "modelo": {
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
  }
}
```
### Modelo LoginResponse

```csharp
public class LoginResponse
{
    public LoginResponse()
    {
        this.Token = string.Empty;
    }

    public string Token { get; set; }
}
```

---

### Respuesta con error (401 Unauthorized)

```json
{
  "ocurrioError": true,
  "mensajeCliente": "Credenciales inválidas",
  "mensajeTecnico": "Usuario o contraseña incorrectos",
  "codigoError": "AUTH001",
  "modelo": null
}
```

---

## 📦 Modelo genérico de respuesta

```csharp
public class RespuestaMensaje<T>
{
    public RespuestaMensaje()
    {
        this.OcurrioError = false;
        this.MensajeTecnico = string.Empty;
        this.MensajeCliente = string.Empty;
        this.CodigoError = string.Empty;
        this.Modelo = default!;
    }

    public bool OcurrioError { get; set; }
    public string MensajeCliente { get; set; }
    public string MensajeTecnico { get; set; }
    public string CodigoError { get; set; }
    public T Modelo { get; set; }
}
```
---

## 🧪 Pruebas

El endpoint puede probarse usando herramientas como:

- Postman
- Swagger
- curl

### Ejemplo con curl

```powershell
curl -X POST https://localhost:5001/api/auth/login \
-H "Content-Type: application/json" \
-d '{
  "user": "usuario",
  "password": "password"
}'
```
---

## ⚙️ Notas importantes

- El token JWT tiene una expiración configurada en el proyecto.
- Los endpoints futuros requerirán el token JWT en el header Authorization.
- La API se encuentra en desarrollo y se agregarán nuevos módulos y endpoints.

---

## ✍️ Autor

Desarrollado por Jonathan Yos