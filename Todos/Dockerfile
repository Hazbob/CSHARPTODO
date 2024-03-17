FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Todos/Todos.csproj", "Todos/"]
RUN dotnet restore "Todos/Todos.csproj"
COPY . .
WORKDIR "/src/Todos"
RUN dotnet build "Todos.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Todos.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Todos.dll"]
