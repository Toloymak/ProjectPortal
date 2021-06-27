FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build-env
WORKDIR /app
COPY . ./
RUN dotnet publish -c Release -o output

FROM nginx:latest
WORKDIR /var/www/web
COPY --from=build-env /app/output/wwwroot .
COPY Web/nginx.conf /etc/nginx/nginx.conf
EXPOSE 80