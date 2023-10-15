#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src

# Build DATA
COPY ["DATA/DATA.csproj", "DATA/"]
RUN dotnet restore "DATA/DATA.csproj"
COPY ["DATA/*", "DATA/"]
RUN dotnet build "DATA/DATA.csproj" -c Release

# Build SEVICE
COPY ["SERVICE/SERVICE.csproj", "SERVICE/"]
RUN dotnet restore "SERVICE/SERVICE.csproj"
COPY ["SERVICE/*", "SERVICE/"]
RUN dotnet build "SERVICE/SERVICE.csproj" -c Release

# Build MAIN
COPY ["MAIN/MAIN.csproj", "MAIN/"]
RUN dotnet restore "MAIN/MAIN.csproj"
COPY ["MAIN/*", "MAIN/"]
RUN dotnet build "MAIN/MAIN.csproj" -c Release

FROM build AS publish
RUN dotnet publish "MAIN/MAIN.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ARG ASPNETCORE_ENVIRONMENT
ENV ASPNETCORE_ENVIRONMENT ${ASPNETCORE_ENVIRONMENT}
ENTRYPOINT ["dotnet", "MAIN.dll"]