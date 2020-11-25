#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/ProducerApp/ProducerApp.csproj", "src/ProducerApp/"]
COPY ["src/SharedLibrary/SharedLibrary.csproj", "src/SharedLibrary/"]
RUN dotnet restore "src/ProducerApp/ProducerApp.csproj"
COPY . .
WORKDIR "/src/src/ProducerApp"
RUN dotnet build "ProducerApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProducerApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProducerApp.dll"]