# Stage 1: Build the Angular application
FROM node:20 as build
WORKDIR /app
COPY package*.json ./
RUN npm install
RUN npm install -g @angular/cli
COPY . .
#RUN npm run build --prod
RUN ng build --configuration production

# Stage 2: Serve the application from Nginx
FROM nginx:alpine
# Some Angular builds may produce a nested 'browser' folder inside the output
# so copy that if present; otherwise fallback to the root of the dist folder.
RUN rm -rf /usr/share/nginx/html/*
COPY --from=build /app/dist/e-payroll.ui/browser /usr/share/nginx/html
COPY --from=build /app/dist/e-payroll.ui /usr/share/nginx/html
EXPOSE 80

# Start Nginx server
CMD ["nginx", "-g", "daemon off;"]


