#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["NetSparkScheduler.Worker/NetSparkScheduler.Worker.csproj", "NetSparkScheduler.Worker/"]
RUN dotnet restore "NetSparkScheduler.Worker/NetSparkScheduler.Worker.csproj"
COPY . .
WORKDIR "/src/NetSparkScheduler.Worker"
RUN dotnet build "NetSparkScheduler.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetSparkScheduler.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetSparkScheduler.Worker.dll"]