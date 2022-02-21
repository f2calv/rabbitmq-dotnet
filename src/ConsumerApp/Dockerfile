ARG BUILD_IMAGE=mcr.microsoft.com/dotnet/sdk:6.0
FROM $BUILD_IMAGE AS build
WORKDIR /src
COPY ["src/ConsumerApp/ConsumerApp.csproj", "src/ConsumerApp/"]
COPY ["src/SharedLibrary/SharedLibrary.csproj", "src/SharedLibrary/"]
RUN dotnet restore "src/ConsumerApp/ConsumerApp.csproj"
COPY . .
WORKDIR "/src/src/ConsumerApp"
RUN dotnet build "ConsumerApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConsumerApp.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsumerApp.dll"]