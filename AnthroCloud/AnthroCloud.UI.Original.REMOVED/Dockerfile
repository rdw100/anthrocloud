#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

#FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-nanoserver-1903 AS base
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0.0-preview7-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#FROM mcr.microsoft.com/dotnet/core/sdk:3.0-nanoserver-1903 AS build
FROM mcr.microsoft.com/dotnet/core/sdk:3.0.100-preview7-nanoserver-1809 AS build
WORKDIR /src
COPY ["AnthroCloud.UI/AnthroCloud.UI.csproj", "AnthroCloud.UI/"]
RUN dotnet restore "AnthroCloud.UI/AnthroCloud.UI.csproj"
COPY . .
WORKDIR "/src/AnthroCloud.UI"
RUN dotnet build "AnthroCloud.UI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AnthroCloud.UI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AnthroCloud.UI.dll"]