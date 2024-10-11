
# Delivery Tracking System - Backend API

This repository contains the backend API for the **Delivery Tracking System**. It is built using **ASP.NET Core** and provides functionality for tracking the real-time location of delivery staff members. The system enables an admin to monitor staff locations, view historical location data, and manage delivery staff profiles.

## Features
- **Delivery Staff Management**: CRUD operations to manage delivery staff profiles.
- **Location Tracking**: Real-time location updates using GPS coordinates (latitude & longitude).
- **Location History**: Store and retrieve historical location data for analysis.
- **Authentication**: JWT-based authentication for secure access to the system.
- **Database Integration**: Uses SQL Server for data storage.
  
---

## Table of Contents
1. [Technologies Used](#technologies-used)
2. [System Requirements](#system-requirements)
3. [Installation](#installation)
4. [Environment Variables](#environment-variables)
5. [Database Setup](#database-setup)
6. [Running the API](#running-the-api)
7. [API Endpoints](#api-endpoints)
8. [Authentication](#authentication)
9. [Deployment](#deployment)
10. [Contributing](#contributing)

---

## Technologies Used
- **ASP.NET Core** (.NET 6 or later)
- **Entity Framework Core** (EF Core)
- **SQL Server** (Database)
- **JWT Authentication**
- **Swagger** (API documentation)
  
---

## System Requirements
Ensure you have the following software installed:
- **.NET 6 SDK** or later
- **SQL Server** (Local or Cloud)
- **Postman** (or any API testing tool)
- **Git**

---

## Installation

### 1. Clone the Repository
First, clone the repository to your local machine:
```bash
git clone https://github.com/your-username/delivery-tracking-system-api.git
cd delivery-tracking-system-api
```

### 2. Restore NuGet Packages
Install the necessary dependencies by running:
```bash
dotnet restore
```

### 3. Configure `appsettings.json`
Update the connection string for SQL Server and any necessary environment variables in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your-server;Database=DeliveryTrackingDB;User Id=your-username;Password=your-password;"
  },
  "JwtSettings": {
    "SecretKey": "Your-JWT-Secret-Key",
    "Issuer": "Your-Issuer",
    "Audience": "Your-Audience"
  }
}
```

---

## Environment Variables
The following environment variables need to be set up:

| Variable Name       | Description                           |
|---------------------|---------------------------------------|
| `JWT_SECRET`        | Secret key for JWT token encryption   |
| `SQL_CONNECTION`    | Connection string for the SQL Server  |
| `ENVIRONMENT`       | Environment setting (e.g., Development, Production) |

Make sure these variables are properly set in the `.env` file or in the hosting environment.

---

## Database Setup

### 1. Apply Database Migrations
If the database doesn't already exist, create it by applying the migrations:
```bash
dotnet ef database update
```

This command will create the necessary tables in your SQL Server database.

---

## Running the API

### 1. Local Development
To run the API locally, use the following command:
```bash
dotnet run
```

By default, the API will be available at:
- `https://localhost:5001` for HTTPS
- `http://localhost:5000` for HTTP

### 2. Testing the API
You can use Postman or any other API testing tool to test the API endpoints. Additionally, Swagger is integrated for easy exploration of the API at `https://localhost:5001/swagger` after the API is running.

---

## API Endpoints

### 1. **Authentication**
| Method | Endpoint           | Description                      |
|--------|--------------------|----------------------------------|
| POST   | `/api/auth/login`   | Login to receive JWT token       |

### 2. **Delivery Staff**
| Method | Endpoint                      | Description                         |
|--------|-------------------------------|-------------------------------------|
| GET    | `/api/deliverystaff`           | Get all delivery staff              |
| GET    | `/api/deliverystaff/{id}`      | Get delivery staff by ID            |
| POST   | `/api/deliverystaff`           | Add new delivery staff              |
| PUT    | `/api/deliverystaff/{id}`      | Update delivery staff by ID         |
| DELETE | `/api/deliverystaff/{id}`      | Delete delivery staff by ID         |

### 3. **Location Tracking**
| Method | Endpoint                      | Description                         |
|--------|-------------------------------|-------------------------------------|
| GET    | `/api/location`                | Get all location data               |
| GET    | `/api/location/{id}`           | Get location data for specific staff|
| POST   | `/api/location`                | Add new location data               |

---

## Authentication

The API uses **JWT (JSON Web Token)** for authentication. Here’s how to use it:
1. Send a POST request to `/api/auth/login` with the user credentials to get a JWT token.
2. Include the token in the `Authorization` header in subsequent requests to access secured endpoints.

Example:
```
Authorization: Bearer <your-jwt-token>
```

---

## Deployment

### Steps to Deploy on Cloud Providers:
1. **Publish the API:**
   ```bash
   dotnet publish -c Release
   ```

2. **Deploy to Cloud Providers (e.g., Azure, AWS, Heroku):**
   - For Azure, you can use the **Azure App Service**.
   - For AWS, use **Elastic Beanstalk** or **EC2**.
   - For Heroku, you can deploy using Docker or a simple Git push.

3. **Set Environment Variables:**
   Make sure to set all necessary environment variables such as `JWT_SECRET` and `SQL_CONNECTION` in your cloud environment.

4. **Configure SSL:**
   Ensure that your cloud provider supports SSL for secure HTTPS communication.

---

## Contributing
Contributions are welcome! Please follow these steps:
1. Fork the repository.
2. Create a new feature branch (`git checkout -b feature/new-feature`).
3. Make your changes.
4. Commit your changes (`git commit -m "Add new feature"`).
5. Push to the branch (`git push origin feature/new-feature`).
6. Create a Pull Request.



