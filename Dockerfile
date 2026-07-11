FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TSPOnline/TSPOnline.csproj", "TSPOnline/"]
RUN dotnet restore "TSPOnline/TSPOnline.csproj"
COPY . .
WORKDIR "/src/TSPOnline"
RUN dotnet build "TSPOnline.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TSPOnline.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TSPOnline.dll"]
