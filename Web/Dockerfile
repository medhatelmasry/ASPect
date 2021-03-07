FROM mcr.microsoft.com/dotnet/sdk:5.0 as build
ENTRYPOINT ["dotnet", "run"]
ENV ASPNETCORE_ENVIRONMENT=Development 
ENV PATH="$PATH:/root/.dotnet/tools"
WORKDIR /app
COPY . .
RUN dotnet tool install --global dotnet-ef; dotnet tool update --global dotnet-ef; dotnet add package Microsoft.EntityFrameworkCore.Design
RUN dotnet restore; dotnet ef database update; dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "Web.dll"]
