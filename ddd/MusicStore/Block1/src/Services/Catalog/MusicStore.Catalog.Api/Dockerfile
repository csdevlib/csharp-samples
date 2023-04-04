#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Ideas/MusicStore.Catalog.Api/MusicStore.Catalog.Api.csproj", "Services/Ideas/MusicStore.Catalog.Api/"]
RUN dotnet restore "Services/Ideas/MusicStore.Catalog.Api/MusicStore.Catalog.Api.csproj"
COPY . .
WORKDIR "/src/Services/Ideas/MusicStore.Catalog.Api"
RUN dotnet build "MusicStore.Catalog.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MusicStore.Catalog.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MusicStore.Catalog.Api.dll"]