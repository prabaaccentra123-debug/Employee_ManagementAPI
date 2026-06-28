# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore "EmployeeManagement.csproj"
RUN dotnet publish "EmployeeManagement.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

COPY --from=build /app/publish .
ENV ASPNETCORE_ENVIRONMENT=Docker

EXPOSE 8080


ENTRYPOINT ["dotnet", "EmployeeManagement.dll"]