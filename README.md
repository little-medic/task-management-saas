# Task Management SaaS

A small full-stack task management application built with **React, TypeScript, ASP.NET Core Web API, Entity Framework Core, and SQL Server**.

## Features

* Dashboard with task statistics
* Project management overview
* Task management
* Task status and priority
* Task due dates
* Assigned users
* RESTful API
* SQL Server database
* Responsive frontend

## Tech Stack

### Frontend

* React
* TypeScript
* Vite
* Axios
* React Router

### Backend

* ASP.NET Core 8 Web API
* Entity Framework Core 8
* SQL Server

## Project Structure

```text
TaskManagement/
├── TaskManagement.Api/
│   ├── Controllers/
│   ├── Data/
│   ├── Models/
│   └── Program.cs
│
└── taskmanagement-client/
    ├── src/
    │   ├── Pages/
    │   ├── services/
    │   └── App.tsx
    └── package.json
```

## Main API Endpoints

| Method | Endpoint         | Description              |
| ------ | ---------------- | ------------------------ |
| GET    | `/api/Projects`  | Get all projects         |
| GET    | `/api/Tasks`     | Get all tasks            |
| GET    | `/api/Dashboard` | Get dashboard statistics |

## Running Locally

### Backend

Open the ASP.NET Core project in Visual Studio and run the API.

The application uses SQL Server LocalDB with Entity Framework Core.

### Frontend

Navigate to the React application:

```bash
cd taskmanagement-client
npm install
npm run dev
```

Then open the local Vite URL shown in the terminal.

## Purpose

This project was created as a portfolio demonstration of full-stack web development using React and ASP.NET Core.
