FROM mcr.microsoft.com/dotnet/aspnet:9.0-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 5252

ENV ASPNETCORE_URLS=http://+:5252

FROM mcr.microsoft.com/dotnet/sdk:9.0-nanoserver-1809 AS build
ARG configuration=Release
WORKDIR /src
COPY ["BedAndDrinks/BedAndDrinks.csproj", "BedAndDrinks/"]
RUN dotnet restore "BedAndDrinks\BedAndDrinks.csproj"
COPY . .
WORKDIR "/src/BedAndDrinks"
RUN dotnet build "BedAndDrinks.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "BedAndDrinks.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BedAndDrinks.dll"]
