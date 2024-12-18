# 💈 Hair Salon Booking App 💇🏼‍♀️

👋 Welcome to the Hair Salon Booking App! This project is designed to streamline hair salon management and enhance customer experiences. It includes a backend API, Razor Page application, and supporting services.

## Project Structure 📂

### **1. SERVER**

- **HairSalon.RazorPage**: A Razor Pages application providing the web UI for both administrators and customers.
- **HairSalonBE.API**: A backend API for handling all business logic and exposing endpoints for salon management.

### **2. SERVICES**

- **HairSalon.Contract.Services**: Contains interfaces defining service contracts.
- **HairSalon.Services**: Implements business logic and services based on defined contracts.

### **3. REPOSITORY**

- **HairSalon.Contract.Repositories**: Defines repository interfaces for interacting with data sources.
- **HairSalon.Repositories**: Implements repositories for database access using Entity Framework Core.
- **HairSalon.ModelViews**: Contains ViewModels and DTOs (Data Transfer Objects) for seamless data communication.

### **4. CORE**

- **HairSalon.Core**: Contains shared utilities, constants, and base functionality used across the solution.

---

## Features 🔍

### For Customers:

- **Appointment Booking**: Book appointments online with preferred stylists.
- **Service Catalog**: View available services with descriptions and pricing.
- **Stylist Profiles**: Browse stylist details, specialties, and customer reviews.
- **Booking History**: Manage upcoming and past appointments.

### For Administrators:

- **Manage Appointments**: View, update, or cancel customer bookings.
- **Service Management**: Add, edit, or delete services offered by the salon.
- **Stylist Management**: Manage staff availability, profiles, and roles.
- **Customer Management**: View and manage customer details.

---

## Technologies Used 🔎

- **.NET 8.0**: For building the backend API and Razor Pages.
- **ASP.NET Core Razor Pages**: To create the web application UI.
- **ASP.NET Core API**: For backend endpoints and business logic.
- **Entity Framework Core**: To manage database operations.
- **JWT Authentication**: For secure user authentication and authorization.
- **Unit of Work**: To manage database transactions efficiently.
- **Redis Cache**: For caching frequently accessed data.
- **Firebase**: For image storage and user authentication (OTP).
- **Google OAuth & Facebook OAuth**: For social login and user authentication.
- **VNPay**: For secure online payment processing.

---

## Getting Started 🔨

### Prerequisites

- **.NET 8.0 SDK**
- **SQL Server**
- **Firebase Project**
- **Redis Server**
- **VNPay Sandbox Account**
- **Google & Facebook OAuth Credentials**

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/LilMIKHuwng/Hair-Salon-Booking-App
   ```
2. Navigate to the project directory:
   ```bash
   cd Hair-Salon-Booking-App
   ```
3. Configure connection strings, Firebase, Redis, JWT, and OAuth settings in `appsettings.json`.
4. Restore dependencies:
   ```bash
   dotnet restore
   ```
5. Apply database migrations:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```
6. Run the application:
   ```bash
   dotnet run
   ```

---

## Contributing 👏

We welcome contributions! If you'd like to suggest improvements, report bugs, or add features, please open an issue or submit a pull request.

---

## License 🗃️

This project is licensed under the MIT License. See the `LICENSE` file for details.

---

## About 👥

This project is developed by a team of passionate developers to modernize and simplify hair salon management. Feel free to contact us for inquiries, feedback, or collaboration!
