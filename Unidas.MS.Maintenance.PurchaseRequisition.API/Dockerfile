#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Unidas.MS.Maintenance.PurchaseRequisition.API/Unidas.MS.Maintenance.PurchaseRequisition.API.csproj", "Unidas.MS.Maintenance.PurchaseRequisition.API/"]
COPY ["Unidas.MS.Maintenance.PurchaseRequisition.Application/Unidas.MS.Maintenance.PurchaseRequisition.Application.csproj", "Unidas.MS.Maintenance.PurchaseRequisition.Application/"]
COPY ["Unidas.MS.Maintenance.PurchaseRequisition.Domain/Unidas.MS.Maintenance.PurchaseRequisition.Domain.csproj", "Unidas.MS.Maintenance.PurchaseRequisition.Domain/"]
COPY ["Unidas.MS.Maintenance.PurchaseRequisition.Infra.IoC/Unidas.MS.Maintenance.PurchaseRequisition.Infra.IoC.csproj", "Unidas.MS.Maintenance.PurchaseRequisition.Infra.IoC/"]
COPY ["Unidas.MS.Maintenance.PurchaseRequisition.Infra/Unidas.MS.Maintenance.PurchaseRequisition.Infra.csproj", "Unidas.MS.Maintenance.PurchaseRequisition.Infra/"]
RUN dotnet restore "Unidas.MS.Maintenance.PurchaseRequisition.API/Unidas.MS.Maintenance.PurchaseRequisition.API.csproj"
COPY . .
WORKDIR "/src/Unidas.MS.Maintenance.PurchaseRequisition.API"
RUN dotnet build "Unidas.MS.Maintenance.PurchaseRequisition.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Unidas.MS.Maintenance.PurchaseRequisition.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Unidas.MS.Maintenance.PurchaseRequisition.API.dll"]