# 🧩 SalesStockAPI

API desenvolvida em **ASP.NET Core 8** com **Entity Framework Core** e **PostgreSQL** para o projeto **SalesStock**, um sistema simples de controle de produtos, clientes e vendas.

---

## 🚀 Tecnologias Utilizadas

- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **PostgreSQL (via Docker)**
- **CORS (Cross-Origin Resource Sharing)**
- **Render / Docker** (para deploy)

---

## 🧱 Estrutura do Projeto

SalesStockAPI/
│
├── Domain/
│ └── Entities/
│ ├── Produto.cs
│ ├── Cliente.cs
│ └── Venda.cs
│
├── Infrastructure/
│ └── Data/
│ └── SalesStockDbContext.cs
│
├── Controllers/
│ ├── ProdutosController.cs
│ ├── ClientesController.cs
│ └── VendasController.cs
│
├── appsettings.json
└── Program.cs

yaml
Copiar código

---

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

☁️ Deploy
Hospedado em Render (ou outro serviço compatível).
Exemplo de URL pública:

arduino
Copiar código
https://salesstockapi.onrender.com
👨‍💻 Autor
Desenvolvido por Rafael Dolinski
🔗 GitHub

yaml
Copiar código

---

# 💻 **README – SalesStock Dashboard (React + TailwindCSS)**

```markdown
# 💻 SalesStock Dashboard

Interface web desenvolvida em **React.js** com **Tailwind CSS**, **Axios** e **Recharts**, para consumo da API **SalesStockAPI** (.NET).

---

## 🚀 Tecnologias Utilizadas

- **React + Vite**
- **Tailwind CSS**
- **Axios**
- **Recharts**
- **Lucide React (ícones)**
- **Framer Motion (animações)**
- **React Router DOM**

---

## ⚙️ Instalação

Clone o repositório:

```bash
git clone https://github.com/RafaelD0linski/salesstock-dashboard-FrontEnd
cd salesstock-dashboard-FrontEnd
Instale as dependências:

bash
Copiar código
npm install
🔗 Configuração da API
Edite o arquivo src/api.js:

js
Copiar código
import axios from "axios";

const api = axios.create({
  baseURL: "https://salesstockapi.onrender.com", // URL pública da sua API hospedada
});

export default api;
▶️ Executando o Projeto
bash
Copiar código
npm start
O projeto rodará em:

arduino
Copiar código
http://localhost:3000
📊 Funcionalidades
Dashboard com estatísticas de produtos, clientes e vendas

Gráfico dinâmico de vendas recentes

CRUD completo:

Produtos

Clientes

Vendas

Design moderno e responsivo com TailwindCSS

☁️ Deploy
Frontend hospedado em Vercel
Exemplo de URL pública:

arduino
Copiar código
https://salesstock-dashboard.vercel.app
🧠 Estrutura do Projeto
css
Copiar código
src/
│
├── api.js
├── pages/
│   ├── Dashboard.jsx
│   ├── Produtos.jsx
│   ├── Clientes.jsx
│   └── Vendas.jsx
│
├── components/
│   ├── Sidebar.jsx
│   ├── Header.jsx
│   └── Card.jsx
│
└── App.js
✅ **Como usar:**  
- Copie o primeiro bloco e cole no `README.md` da pasta **SalesStockAPI**.  
- Copie o segundo e cole no `README.md` da pasta **salesstock-dashboard-FrontEnd**.  

Se quiser, posso gerar ambos em `.md` prontos para download (ou `.pdf` com formatação profissio
