#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["E-Payroll.sln", "."]
COPY ["API/E-Payroll.API.Web/E-Payroll.API.Web.csproj", "API/E-Payroll.API.Web/"]
COPY ["Application/E-Payroll.Application/E-Payroll.Application.csproj", "Application/E-Payroll.Application/"]
COPY ["Core/E-Payroll.Core/E-Payroll.Core.csproj", "Core/E-Payroll.Core/"]
COPY ["Infrastructure/E-Payroll.Infrastructure.Persistence/E-Payroll.Infrastructure.Persistence.csproj", "Infrastructure/E-Payroll.Infrastructure.Persistence/"]
RUN dotnet restore "E-Payroll.sln"
COPY . .
WORKDIR "/src/API/E-Payroll.API.Web"
RUN dotnet build "E-Payroll.API.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "E-Payroll.API.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "E-Payroll.API.Web.dll"]
