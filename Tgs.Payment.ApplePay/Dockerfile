#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
ARG BuildConfiguration=Release
RUN --mount=type=secret,id=nuget,dst=/pat cp /pat ~/.nuget/NuGet/NuGet.Config
RUN dotnet nuget remove source 'Microsoft Visual Studio Offline Packages' || true
WORKDIR /src
COPY ["NuGet.config", "."]
COPY ["Tgs.Payment.ApplePay/Tgs.Payment.ApplePay.csproj", "Tgs.Payment.ApplePay/"]
COPY ["ApplePay.Repositories/ApplePay.Repositories.csproj", "ApplePay.Repositories/"]
COPY ["ApplePay.Core/ApplePay.Core.csproj", "ApplePay.Core/"]
COPY ["Tgs.Payment.ApplePay.Client/Tgs.Payment.ApplePay.Client.csproj", "Tgs.Payment.ApplePay.Client/"]
RUN dotnet restore "Tgs.Payment.ApplePay/Tgs.Payment.ApplePay.csproj"
COPY . .
WORKDIR "/src/Tgs.Payment.ApplePay"
RUN dotnet build "Tgs.Payment.ApplePay.csproj" -c ${BuildConfiguration} -o /app/build

FROM build AS publish
ARG BuildConfiguration
RUN dotnet publish "Tgs.Payment.ApplePay.csproj" -c ${BuildConfiguration} -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tgs.Payment.ApplePay.dll"]