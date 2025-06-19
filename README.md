# Admin Panel

A simple admin dashboard with React frontend and ASP.NET Core backend, featuring JWT authentication, client management, rate management, and payment tracking.

## Features

- **Backend**:
  - ASP.NET Core
  - JWT authentication with refresh tokens
  - PostgreSQL database with EF Core
  - CQRS pattern implementation
  - Clean Architecture
  - Swagger documentation
  
- **Frontend**:
  - React with Vite
  - Axios for API calls
  - Bootstrap for styling
  - Protected routes
  - JWT token +refresh tokens management

## System Overview

- Frontend: http://localhost:5173/
- Backend API: http://localhost:5000/
- Swagger UI: http://localhost:5000/swagger/index.html

## Installation

1. Clone the repository:
   git clone git@github.com:GENRAY1/AdminPanel.git
   cd AdminPanel

2. Start the system using Docker:
   docker-compose up

> [!Database]
> Database migrations are applied automatically on startup.

## Usage

### Login Credentials

- Email: `admin@mirra.dev`
- Password: `admin123`

### API Endpoints

#### Authentication

- `POST /auth/login` - User login
- `POST /auth/logout` - User logout
- `POST /auth/refresh` - Refresh access token

#### Clients

- `GET /clients` - List all clients
- `POST /clients` - Create new client
- `PUT /clients/{id}` - Update client
- `DELETE /clients/{id}` - Delete client

#### Payments

- `GET /payments?take=100` - Get recent payments

#### Rate

- `GET /rate` - Get current rate
- `POST /rate` - Update rate

### Frontend Routes

- `/login` - Login page
- `/dashboard` - Client and rate management (protected)
- `/payments` - Payment history (protected)
    

## API Examples

### Login

curl -X POST "http://localhost:5000/auth/login" \
-H "Content-Type: application/json" \
-d '{"email":"admin@mirra.dev","password":"admin123"}'

Example response:
{
  "accountId": "8b4b4145-6122-4d99-9d7b-e669112618fe",
  "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "refreshToken": "0XeB+l7Q1Erz3GB9i9xrmabUy4dTNfMUbj1gCj6LQxWS1ZJRMsC8uFnnOA8IwZPo1PVc6IIOKSvhFdAWUyDhfQ=="
}

### Refresh Token

curl -X POST "http://localhost:5000/auth/refresh" \
-H "Content-Type: application/json" \
-d '{"accountId":"8b4b4145-6122-4d99-9d7b-e669112618fe","refreshToken":"0XeB+l7Q1Erz3GB9i9xrmabUy4dTNfMUbj1gCj6LQxWS1ZJRMsC8uFnnOA8IwZPo1PVc6IIOKSvhFdAWUyDhfQ=="}'

Example response:
{
  "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}