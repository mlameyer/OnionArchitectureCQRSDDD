#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VoucherService.Api/VoucherService.Api.csproj", "VoucherService.Api/"]
RUN dotnet restore "VoucherService.Api/VoucherService.Api.csproj"
COPY . .
WORKDIR "/src/VoucherService.Api"
RUN dotnet build "VoucherService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VoucherService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VoucherService.Api.dll"]