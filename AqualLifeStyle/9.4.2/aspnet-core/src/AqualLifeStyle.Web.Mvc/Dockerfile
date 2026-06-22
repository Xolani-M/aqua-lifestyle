FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
RUN ln -s ~/.dotnet/tools/libman /usr/local/bin/libman

WORKDIR /src
COPY ["src/AqualLifeStyle.Web.Mvc/AqualLifeStyle.Web.Mvc.csproj", "src/AqualLifeStyle.Web.Mvc/"]
COPY ["src/AqualLifeStyle.Web.Core/AqualLifeStyle.Web.Core.csproj", "src/AqualLifeStyle.Web.Core/"]
COPY ["src/AqualLifeStyle.Application/AqualLifeStyle.Application.csproj", "src/AqualLifeStyle.Application/"]
COPY ["src/AqualLifeStyle.Core/AqualLifeStyle.Core.csproj", "src/AqualLifeStyle.Core/"]
COPY ["src/AqualLifeStyle.EntityFrameworkCore/AqualLifeStyle.EntityFrameworkCore.csproj", "src/AqualLifeStyle.EntityFrameworkCore/"]
WORKDIR "/src/src/AqualLifeStyle.Web.Mvc"
RUN dotnet restore 

WORKDIR /src
COPY ["src/AqualLifeStyle.Web.Mvc", "src/AqualLifeStyle.Web.Mvc"]
COPY ["src/AqualLifeStyle.Web.Core", "src/AqualLifeStyle.Web.Core"]
COPY ["src/AqualLifeStyle.Application", "src/AqualLifeStyle.Application"]
COPY ["src/AqualLifeStyle.Core", "src/AqualLifeStyle.Core"]
COPY ["src/AqualLifeStyle.EntityFrameworkCore", "src/AqualLifeStyle.EntityFrameworkCore"]
WORKDIR "/src/src/AqualLifeStyle.Web.Mvc"
RUN libman restore
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "AqualLifeStyle.Web.Mvc.dll"]
