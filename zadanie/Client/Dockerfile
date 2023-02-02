FROM node:16 as build-step
RUN mkdir -p /app
WORKDIR /app
COPY package.json /app
RUN npm install --verbose
COPY . /app
RUN npm run build --configuration=docker

FROM nginx:1.23.3-alpine
COPY --from=build-step /app/docs /usr/share/nginx/html
