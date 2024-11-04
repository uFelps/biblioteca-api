FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Biblioteca.Api/Biblioteca.Api.csproj", "Biblioteca.Api/"]
COPY ["Biblioteca.Application/Biblioteca.Application.csproj", "Biblioteca.Application/"]
COPY ["Biblioteca.Domain/Biblioteca.Domain.csproj", "Biblioteca.Domain/"]
COPY ["Biblioteca.Infra.IoC/Biblioteca.Infra.IoC.csproj", "Biblioteca.Infra.IoC/"]
COPY ["Biblioteca.Infra.Data/Biblioteca.Infra.Data.csproj", "Biblioteca.Infra.Data/"]
RUN dotnet restore "Biblioteca.Api/Biblioteca.Api.csproj"
COPY . .
WORKDIR "/src/Biblioteca.Api"
RUN dotnet build "Biblioteca.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Biblioteca.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Biblioteca.Api.dll"]
