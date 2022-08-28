#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CloudTribe.Frontend/CloudTribe.Frontend.csproj", "CloudTribe.Frontend/"]
RUN dotnet restore "CloudTribe.Frontend/CloudTribe.Frontend.csproj"
COPY . .
WORKDIR "/src/CloudTribe.Frontend"
RUN dotnet build "CloudTribe.Frontend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CloudTribe.Frontend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudTribe.Frontend.dll"]