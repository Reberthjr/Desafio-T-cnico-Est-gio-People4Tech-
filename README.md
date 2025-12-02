# 📦 CatalogApi — Desafio Técnico .NET 2025

API desenvolvida para o desafio técnico da People4Tech, utilizando **.NET 10**, **Entity Framework Core** e **SQLite**.
O sistema permite **gerenciar produtos** e **emitir pedidos**, validando estoque automaticamente.

---

## 🚀 Tecnologias Utilizadas

* .NET 10 Web API
* Entity Framework Core
* SQLite
* Swagger (documentação automática)
* C#

---

## 📁 Estrutura do Projeto

```
CatalogApi/
 ├── Controllers/
 │    ├── ProductsController.cs
 │    ├── OrdersController.cs
 │    └── OrderItemsController.cs
 ├── Data/
 │    └── AppDbContext.cs
 ├── Models/
 │    ├── Product.cs
 │    ├── Order.cs
 │    └── OrderItem.cs
 ├── Services/
 │    └── OrderService.cs
 ├── appsettings.json
 ├── Program.cs
 └── README.md
```

---

## ⚙️ Configuração do Banco (SQLite)

O arquivo `app.db` é criado automaticamente ao rodar as migrations.

---

## ▶️ Como Executar o Projeto

### 1️⃣ Restaurar dependências

```bash
dotnet restore
```

### 2️⃣ Criar o banco e tabelas

```bash
dotnet ef database update
```
### 3️⃣ Rodar o servidor

```bash
dotnet run
```

A API ficará disponível em:

```
https://localhost:5000/swagger/ui
```

---

## 📌 API Endpoints

### 🟦 **Products**

#### ➤ Create product

`POST /api/products`

**Body:**

```json
{
  "name": "Keyboard",
  "description": "Mechanical RGB Keyboard",
  "price": 250.00,
  "stock": 10
}
```

**Response:**

```json
{
  "id": 1,
  "name": "Keyboard",
  "description": "Mechanical RGB Keyboard",
  "price": 250.00,
  "stock": 10
}
```

---

#### ➤ List all products

`GET /api/products`

---

#### ➤ Get by ID

`GET /api/products/1`

---

#### ➤ Update product

`PUT /api/products/1`

**Body:**

```json
{
  "id": 1,
  "name": "Keyboard",
  "description": "Updated description",
  "price": 275.00,
  "stock": 15
}
```

---

#### ➤ Delete product

`DELETE /api/products/1`

---

### 🟩 **Orders**

#### ➤ Create order

`POST /api/orders`

**Body:**

```json
{
  "clientName": "John Silva",
  "items": [
    { "productId": 1, "quantity": 2, "unitPrice": 250.00 },
    { "productId": 3, "quantity": 1, "unitPrice": 120.00 }
  ]
}
```

**Response:**

```json
{
    "id": 1,
    "clientName": "John Silva",
    "orderDate": "2025-12-02T13:38:00.3452168Z",
    "items": [
        {
            "id": 9,
            "orderId": 1,
            "productId": 1,
            "product": {
                "id": 1,
                "name": "Keyboard",
                "description": "Mechanical RGB Keyboard",
                "price": 250.0,
                "stock": 8
            },
            "quantity": 2,
            "unitPrice": 250.0
        },
        {
            "id": 1,
            "orderId": 1,
            "productId": 2,
            "product": {
                "id": 2,
                "name": "Mouse",
                "description": "RGB Mouse",
                "price": 155.0,
                "stock": 1
            },
            "quantity": 1,
            "unitPrice": 155.0
        }
    ]
}
```


📌 **Regras:**

* Se o estoque for insuficiente → pedido não é criado
*  **Regras:**: Insufficient stock for product Mouse.
* Se for válido → estoque é atualizado automaticamente


---

#### ➤ List all orders

`GET /api/orders`

---

#### ➤ Get order by ID

`GET /api/orders/1`

---

#### ➤ Update order

`PUT /api/orders/1`

---

#### ➤ Delete order

`DELETE /api/orders/1`

---

### 🟧 **Order Items**

#### ➤ Create order item

`POST /api/orderitems`

---

#### ➤ List all order items

`GET /api/orderitems`

---

#### ➤ Get order item by ID

`GET /api/orderitems/1`

---

#### ➤ Update order item

`PUT /api/orderitems/1`

---

#### ➤ Delete order item

`DELETE /api/orderitems/1`

---


## 📄 Notas

* Não há autenticação, conforme solicitado no desafio.
* O projeto utiliza SQLite para facilitar testes e envio pelo GitHub.
* A validação de estoque é automática ao criar pedidos.


---

## ✔️ Status

Projeto finalizado e funcionando 100%. ✅