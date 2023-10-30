# Use a imagem de runtime do .NET Core como base
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Use a imagem do SDK do .NET Core como base para compilar o projeto
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FolheandoBooks.Usuario/FolheandoBooks.Usuario.csproj", "SeuProjeto/"]
RUN dotnet restore "FolheandoBooks.Usuario/FolheandoBooks.Usuario.csproj"
COPY . .
WORKDIR "/src/FolheandoBooks.Usuario"
RUN dotnet build "FolheandoBooks.Usuario.csproj" -c Release -o /app/build

# Publicar o projeto
FROM build AS publish
RUN dotnet publish "FolheandoBooks.Usuario.csproj" -c Release -o /app/publish

# Configurar a imagem final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FolheandoBooks.Usuario.dll"]
