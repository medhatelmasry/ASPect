FROM nginx:alpine 
WORKDIR /var/www/web
COPY BlazorClient/dist/wwwroot .
COPY BlazorClient/nginx.conf /etc/nginx/nginx.conf
EXPOSE 80