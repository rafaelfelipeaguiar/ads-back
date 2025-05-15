# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copia .csproj e restaura
COPY *.csproj ./
RUN dotnet restore crudVeiculos.csproj

# Copia todo o código e publica
COPY . ./
RUN dotnet publish crudVeiculos.csproj -c Release -o out

# Etapa final: uso SDK para ter o CLI dotnet-ef disponível
FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app

# Copia artefatos compilados
COPY --from=build-env /app/out ./

# Expõe porta da API
EXPOSE 5000

# EntryPoint: primeiro roda a migration, depois inicia a API
ENTRYPOINT ["bash", "-c", "dotnet ef database update --no-build && exec dotnet crudVeiculos.dll"]
