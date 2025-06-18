FROM node:18-alpine AS builder
WORKDIR /app
COPY package*.json ./
RUN npm ci
COPY . .
RUN npm run build

FROM nginx:alpine

COPY --from=builder /app/dist /usr/share/nginx/html

RUN sed -i \
    -e 's/listen  .*/listen 5173;/g' \
    -e 's/root  .*/root \/usr\/share\/nginx\/html;/g' \
    -e 's/index  .*/index index.html;/g' \
    /etc/nginx/conf.d/default.conf

EXPOSE 5173
CMD ["nginx", "-g", "daemon off;"]