# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar os arquivos do projeto
COPY . ./

# Restaurar depend�ncias
RUN dotnet restore

# Publicar a aplica��o
RUN dotnet publish -c Release -o out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copiar os arquivos publicados para o cont�iner final
COPY --from=build-env /app/out .

# Expor a porta que ser� usada pela aplica��o
EXPOSE 5000

# Comando para iniciar a aplica��o
ENTRYPOINT ["dotnet", "MyCondo.API.dll"]
