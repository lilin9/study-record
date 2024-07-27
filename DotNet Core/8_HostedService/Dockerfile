FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["8_HostedService.csproj", "./"]
RUN dotnet restore "8_HostedService.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "8_HostedService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "8_HostedService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "8_HostedService.dll"]
