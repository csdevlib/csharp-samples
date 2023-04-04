#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ECommerce.Api.Costumers/ECommerce.Api.Costumers.csproj", "ECommerce.Api.Costumers/"]
RUN dotnet restore "ECommerce.Api.Costumers/ECommerce.Api.Costumers.csproj"
COPY . .
WORKDIR "/src/ECommerce.Api.Costumers"
RUN dotnet build "ECommerce.Api.Costumers.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECommerce.Api.Costumers.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.Api.Costumers.dll"]