#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WebApiVotos/WebApiVotos.WebApi.csproj", "WebApiVotos/"]
COPY ["Infraestructura.Plataforma/Infraestructura.Plataforma.csproj", "Infraestructura.Plataforma/"]
COPY ["Infraestructura.Datos/Infraestructura.Datos.csproj", "Infraestructura.Datos/"]
COPY ["Negocio.IRepositorio/Negocio.IRepositorio.csproj", "Negocio.IRepositorio/"]
COPY ["Dominio.Entidades/Dominio.Entidades.csproj", "Dominio.Entidades/"]
COPY ["Dominio.Modelos/Dominio.Modelos.csproj", "Dominio.Modelos/"]
COPY ["Infraestructura.Extensiones/Infraestructura.Extensiones.csproj", "Infraestructura.Extensiones/"]
COPY ["Negocio.Servicio/Negocio.Servicio.csproj", "Negocio.Servicio/"]
COPY ["Dominio.Servicios/Dominio.Servicios.csproj", "Dominio.Servicios/"]
RUN dotnet restore "WebApiVotos/WebApiVotos.WebApi.csproj"
COPY . .
WORKDIR "/src/WebApiVotos"
RUN dotnet build "./WebApiVotos.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./WebApiVotos.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApiVotos.WebApi.dll"]