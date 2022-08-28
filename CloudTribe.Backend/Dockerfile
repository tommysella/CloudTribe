#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CloudTribe.Backend/CloudTribe.Backend.csproj", "CloudTribe.Backend/"]
RUN dotnet restore "CloudTribe.Backend/CloudTribe.Backend.csproj"
COPY . .
WORKDIR "/src/CloudTribe.Backend"
RUN dotnet build "CloudTribe.Backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CloudTribe.Backend.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudTribe.Backend.dll"]