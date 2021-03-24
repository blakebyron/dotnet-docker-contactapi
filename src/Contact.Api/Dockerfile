#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY Contact.Api/Contact.Api.csproj Contact.Api/
COPY Contact.Domain/Contact.Domain.csproj Contact.Domain/
COPY Contact.Infrastructure/Contact.Infrastructure.csproj Contact.Infrastructure/
RUN dotnet restore "Contact.Api/Contact.Api.csproj"
COPY . .
WORKDIR "/src/Contact.Api"
RUN dotnet build "Contact.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Contact.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Contact.Api.dll"]
