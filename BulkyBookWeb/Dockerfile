#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BulkyBookWeb/BulkyBookWeb.csproj", "BulkyBookWeb/"]
COPY ["BulkyBook.DataAccess/BulkyBook.DataAccess.csproj", "BulkyBook.DataAccess/"]
COPY ["BulkyBook.Models/BulkyBook.Models.csproj", "BulkyBook.Models/"]
COPY ["BulkyBook.Utility/BulkyBook.Utility.csproj", "BulkyBook.Utility/"]
RUN dotnet restore "BulkyBookWeb/BulkyBookWeb.csproj"
COPY . .
WORKDIR "/src/BulkyBookWeb"
RUN dotnet build "BulkyBookWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BulkyBookWeb.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BulkyBookWeb.dll"]
