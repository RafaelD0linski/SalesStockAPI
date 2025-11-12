# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia tudo e restaura dependências
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Etapa de execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Expõe a porta da API
EXPOSE 5000

# Define variável de ambiente padrão para o Render
ENV ASPNETCORE_URLS=http://+:5000

ENTRYPOINT ["dotnet", "SalesStockAPI.dll"]
