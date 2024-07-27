FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EF Core.csproj", "./"]
RUN dotnet restore "EF Core.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "EF Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EF Core.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EF Core.dll"]
