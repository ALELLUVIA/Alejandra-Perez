# Usar Nginx como servidor web
FROM nginx:alpine

# Copiar todos los archivos del frontend a Nginx
COPY webapp/ /usr/share/nginx/html/

# Exponer puerto 80 para HTTP
EXPOSE 80

# Ejecutar Nginx en primer plano
CMD ["nginx", "-g", "daemon off;"]