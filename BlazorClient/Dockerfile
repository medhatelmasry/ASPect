FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy BlazorClient to container working directory
COPY BlazorClient ./BlazorClient
COPY ASPectLibrary ./ASPectLibrary

# Build and publish BlazorClient
RUN dotnet publish BlazorClient/BlazorClient.csproj -c Release -o output

FROM nginx:alpine
WORKDIR /var/www/web
COPY --from=build-env /app/output/wwwroot .
COPY --from=build-env /app/BlazorClient/nginx.conf /etc/nginx/nginx.conf
EXPOSE 80