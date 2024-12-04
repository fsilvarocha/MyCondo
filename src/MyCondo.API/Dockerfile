# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar os arquivos do projeto
COPY . ./

# Restaurar dependências
RUN dotnet restore

# Publicar a aplicação
RUN dotnet publish -c Release -o out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar os arquivos publicados para o contêiner final
COPY --from=build-env /app/out .

# Expor a porta que será usada pela aplicação
EXPOSE 5000

# Comando para iniciar a aplicação
ENTRYPOINT ["dotnet", "MyCondo.API.dll"]
