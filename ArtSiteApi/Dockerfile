FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ArtSite/ArtSite.csproj", "ArtSite/"]
RUN dotnet restore "ArtSite/ArtSite.csproj"
COPY . .
WORKDIR "/src/ArtSite"
RUN dotnet build "ArtSite.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ArtSite.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ArtSite.dll"]
