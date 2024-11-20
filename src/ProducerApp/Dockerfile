ARG BUILD_IMAGE=mcr.microsoft.com/dotnet/sdk:9.0
FROM $BUILD_IMAGE AS build
WORKDIR /src
COPY ["src/ProducerApp/ProducerApp.csproj", "src/ProducerApp/"]
COPY ["src/SharedLibrary/SharedLibrary.csproj", "src/SharedLibrary/"]
RUN dotnet restore "src/ProducerApp/ProducerApp.csproj"
COPY . .
WORKDIR "/src/src/ProducerApp"
RUN dotnet build "ProducerApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProducerApp.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProducerApp.dll"]