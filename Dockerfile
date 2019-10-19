FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Sistem.Antrian/Sistem.Antrian.csproj", "Sistem.Antrian/"]
RUN dotnet restore "Sistem.Antrian/Sistem.Antrian.csproj"
COPY . .
WORKDIR "/src/Sistem.Antrian"
RUN dotnet build "Sistem.Antrian.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sistem.Antrian.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sistem.Antrian.dll"]

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /app 
COPY . ./
RUN dotnet publish -c Release -o ../../out Sistem.Antrian/Sistem.Antrian.csproj

FROM mcr.microsoft.com/dotnet/core/runtime:3.0
WORKDIR /app
COPY --from=build /app/out . 
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Sistem.Antrian.dll
