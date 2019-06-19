FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 8080

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["suteservice.api/suteservice.api.csproj", "suteservice.api/"]
COPY ["suteservice.domain/suteservice.domain.csproj", "suteservice.domain/"]
COPY ["suteservice.infrastructure/suteservice.infrastructure.csproj", "suteservice.infrastructure/"]
COPY . .

RUN dotnet restore "suteservice.api/suteservice.api.csproj"
#RUN dotnet restore "suteservice.domain/suteservice.domain.csproj"
#RUN dotnet restore "suteservice.infrastructure/suteservice.infrastructure.csproj"

WORKDIR "/src/suteservice.api"
RUN dotnet build "suteservice.api.csproj" -c Release -o /app
#WORKDIR "/src/suteservice.domain"
#RUN dotnet build "suteservice.domain.csproj" -c Release -o /app
#WORKDIR "/src/suteservice.infrastructure"
#RUN dotnet build "suteservice.infrastructure.csproj" -c Release -o /app
#WORKDIR "/src/suteservice.api"

FROM build AS publish
RUN dotnet publish "suteservice.api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "suteservice.api.dll"]
