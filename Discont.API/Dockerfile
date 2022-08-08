FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Discont.API/Discont.API.csproj", "Discont.API/"]
RUN dotnet restore "Discont.API/Discont.API.csproj"
COPY . .
WORKDIR "/src/Discont.API"
RUN dotnet build "Discont.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Discont.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Discont.API.dll"]