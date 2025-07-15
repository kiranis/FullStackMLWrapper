# FullStackMLWrapper

A full-stack application that demonstrates a machine learning workflow with a Python ML service, a .NET backend API, and an Angular frontend. The system allows users to submit loan applications and receive predictions (e.g., approval or rejection) based on ML logic.

---

## Table of Contents

- [Architecture](#architecture)
- [Features](#features)
- [Project Structure](#project-structure)
- [Setup Instructions](#setup-instructions)
  - [Prerequisites](#prerequisites)
  - [Python ML Service](#python-ml-service)
  - [.NET Backend](#net-backend)
  - [Angular Frontend](#angular-frontend)
  - [Docker](#docker)
  - [Kubernetes](#kubernetes)
- [API Endpoints](#api-endpoints)
- [Development](#development)
- [Troubleshooting](#troubleshooting)
- [License](#license)

---

## Architecture

```
[Angular Frontend] <---> [.NET Backend API] <---> [Python ML Service]
```

- **Frontend:** Angular app for user interaction.
- **Backend:** .NET Web API that acts as a bridge between frontend and ML service.
- **ML Service:** Python Flask app serving ML predictions.

---

## Features

- Submit loan application data via a web form.
- Backend API forwards requests to the Python ML service.
- ML service returns a prediction (e.g., "Approved" or "Rejected").
- Dockerized for easy deployment.
- Kubernetes manifests for orchestration.

---

## Project Structure

```
FullStackMLWrapper/
│
├── backend/
│   └── MLWrapper.API/         # .NET Web API backend
│
├── frontend/                  # Angular frontend
│
├── python-ml/                 # Python ML service (Flask)
│
├── k8s/                       # Kubernetes manifests
│
└── README.md
```

---

## Setup Instructions

### Prerequisites

- [Node.js & npm](https://nodejs.org/)
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Python 3.11+](https://www.python.org/downloads/)
- [Docker Desktop](https://www.docker.com/products/docker-desktop) (optional, for containers)
- [Kubernetes](https://kubernetes.io/) (optional, for orchestration)

---

### Python ML Service

1. **Install dependencies:**
   ```sh
   cd python-ml
   pip install -r requirements.txt
   ```
2. **Run the service:**
   ```sh
   python app.py
   ```
   The service will be available at `http://localhost:8000/predict`.

---

### .NET Backend

1. **Restore and run:**
   ```sh
   cd backend/MLWrapper.API
   dotnet restore
   dotnet run
   ```
   The API will be available at `http://localhost:5000`.

---

### Angular Frontend

1. **Install dependencies:**
   ```sh
   cd frontend
   npm install
   ```
2. **Run the app:**
   ```sh
   ng serve
   ```
   The app will be available at `http://localhost:4200`.

---

### Docker

To build and run all services with Docker:

1. **Build images:**
   ```sh
   cd frontend
   docker build -t frontend-app .
   cd ../backend/MLWrapper.API
   docker build -t mlwrapper-backend .
   cd ../../python-ml
   docker build -t python-ml-service .
   ```

2. **Run containers (example):**
   ```sh
   docker run -d -p 8000:8000 python-ml-service
   docker run -d -p 5000:5000 mlwrapper-backend
   docker run -d -p 80:80 frontend-app
   ```

---

### Kubernetes

1. **Apply manifests:**
   ```sh
   kubectl apply -f k8s/deployment.yaml
   ```
2. **Access the frontend via the LoadBalancer or NodePort as configured.**

---

## API Endpoints

### Python ML Service

- **POST** `/predict`
  - **Body:**  
    ```json
    {
      "income": 60000,
      "age": 30,
      "creditScore": 750
    }
    ```
  - **Response:**  
    ```json
    {
      "result": "Approved"
    }
    ```

### .NET Backend

- **POST** `/api/predict`
  - Forwards the request to the Python ML service and returns the result.

---

## Development

- Update the ML logic in `python-ml/app.py`.
- Update backend logic in `backend/MLWrapper.API`.
- Update frontend UI and logic in `frontend/`.

---

## Troubleshooting

- **Docker not running:** Start Docker Desktop.
- **Python not found:** Install Python and add to PATH.
- **ng not recognized:** Install Angular CLI globally with `npm install -g @angular/cli`.
- **.NET errors:** Ensure you are in the correct folder with the `.csproj` file.

---

## Contact

**Anis Toauti**  
Senior .NET Developer | Cloud & DevOps Enthusiast  
[LinkedIn](https://www.linkedin.com/in/anis-toauti) | [GitHub](https://github.com/kiranis) | Montréal, QC
