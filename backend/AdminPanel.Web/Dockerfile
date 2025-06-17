FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AdminPanel.Web/AdminPanel.Web.csproj", "AdminPanel.Web/"]
COPY ["AdminPanel.Application/AdminPanel.Application.csproj", "AdminPanel.Application/"]
COPY ["AdminPanel.Infrastructure/AdminPanel.Infrastructure.csproj", "AdminPanel.Infrastructure/"]
COPY ["AdminPanel.Domain/AdminPanel.Domain.csproj", "AdminPanel.Domain/"]
RUN dotnet restore "AdminPanel.Web/AdminPanel.Web.csproj"
COPY . .
WORKDIR "/src/AdminPanel.Web"
RUN dotnet build "AdminPanel.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "AdminPanel.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdminPanel.Web.dll"]
