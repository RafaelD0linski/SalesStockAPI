# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o arquivo de projeto e restaura dependências
COPY ["SalesStockAPI/SalesStockAPI.csproj", "SalesStockAPI/"]
RUN dotnet restore "SalesStockAPI/SalesStockAPI.csproj"

# Copia o restante do código
COPY . .

# Compila em modo Release
WORKDIR /src/SalesStockAPI
RUN dotnet publish "SalesStockAPI.csproj" -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SalesStockAPI.dll"]
