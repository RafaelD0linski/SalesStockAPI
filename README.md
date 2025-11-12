# 🧩 SalesStockAPI

API desenvolvida em **ASP.NET Core 8** com **Entity Framework Core** e **PostgreSQL** para o projeto **SalesStock**, um sistema simples de controle de produtos, clientes e vendas.

## 🚀 Tecnologias Utilizadas

- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **PostgreSQL (via Docker)**
- **CORS (Cross-Origin Resource Sharing)**
- **Render / Docker** (para deploy)

## 🐳 Configuração do Banco via Docker

Execute no terminal:

docker run --name salesstock_db \
-e POSTGRES_USER=postgres \
-e POSTGRES_PASSWORD=123456 \
-e POSTGRES_DB=salesstockdb \
-p 5432:5432 -d postgres:15
⚙️ Configuração da String de Conexão
Edite o arquivo appsettings.json:

json
Copiar código
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=salesstockdb;Username=postgres;Password=123456"
}

🧰 Migrações do Banco de Dados
bash
Copiar código
dotnet ef migrations add InitialCreate
dotnet ef database update
▶️ Executando a API
bash
Copiar código
dotnet run
A API será iniciada em:

arduino
Copiar código
http://localhost:5000


🌐 Rotas Principais
Método	Rota	Descrição
GET	/produtos	Lista todos produtos
POST	/produtos	Adiciona produto
GET	/clientes	Lista clientes
POST	/clientes	Cria novo cliente
GET	/vendas	Lista vendas
POST	/vendas	Registra nova venda


👨‍💻 Autor
Desenvolvido por Rafael Dolinski


