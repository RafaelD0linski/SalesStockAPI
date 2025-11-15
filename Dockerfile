# Etapa 1 — Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia todos os arquivos
COPY . .

# Restaura dependências
RUN dotnet restore

# Builda em modo Release
RUN dotnet publish -c Release -o /app

# Etapa 2 — Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app .

# Expõe a porta da API
EXPOSE 8080

ENTRYPOINT ["dotnet", "SalesStock.API.dll"]
