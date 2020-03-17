FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["ONK1/ONK1.csproj", "ONK1/"]
RUN dotnet restore "ONK1/ONK1.csproj"
COPY . .
WORKDIR "/src/ONK1"
RUN dotnet build "ONK1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ONK1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ONK1.dll"]