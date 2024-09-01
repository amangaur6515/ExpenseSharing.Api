# Expense Sharing App

[![Frontend Repository](https://img.shields.io/badge/Frontend-Code-blue)](https://github.com/amangaur6515/expense-sharing-app.Ui)

## Overview

This Expense Sharing App is built using **ASP.NET Core 6.0 Web API** for the backend and **Angular 15** for the frontend. The app allows users to securely log in, create groups, add members, and manage expenses within those groups. Users can view the expenses and see what they owe to others within their groups.

## Features

- **Secure Login**: Users can securely log in to the app.
- **User Management**: Users are pre-seeded into the database, ensuring easy access to the application.
- **Group Management**: Users can create new groups and add members to them.
- **Expense Tracking**: Users can create expenses within a group and view the expenses shared among the group members.
- **Expense Summary**: The app provides a clear summary of what each user owes within a group.

## Technology Stack

- **Backend**: ASP.NET Core 6.0 Web API
- **Frontend**: Angular 15
- **Database**: SQL Server (or the database you're using)
- **Authentication**: JWT (JSON Web Tokens)

## Screenshots

### Login Page
![Login Page](assets/login-page.png)

### Home Page
![Home Page](assets/home-page.png)

### Group Creation
![Group Creation](assets/group-creation.png)

### Expenses Page
![Expenses Page](assets/expenses-page.png)

## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Node.js](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or another compatible database system

### Installation

1. **Clone the Backend Repository:**

    ```bash
    git clone https://github.com/yourusername/expense-sharing-backend.git
    cd expense-sharing-backend
    ```

2. **Backend Setup:**

    - Restore the NuGet packages:

      ```bash
      dotnet restore
      ```

    - Update the `appsettings.json` file with your database connection string.
    - Run the database migrations:

      ```bash
      dotnet ef database update
      ```

    - Start the backend server:

      ```bash
      dotnet run
      ```

3. **Clone the Frontend Repository:**

    Open a new terminal window/tab and run:

    ```bash
    git clone https://github.com/yourusername/expense-sharing-frontend.git
    cd expense-sharing-frontend
    ```

4. **Frontend Setup:**

    - Install the dependencies:

      ```bash
      npm install
      ```

    - Start the Angular development server:

      ```bash
      ng serve
      ```

5. **Access the Application:**

    - Open your browser and navigate to `http://localhost:4200` to access the frontend.
    - The backend API will be running at `http://localhost:5000` (or the port you specified).

## Usage

- **Login:** Use the seeded credentials to log in.
- **Create a Group:** Go to the "Groups" section and create a new group.
- **Add Members:** Add members to the created group.
- **Add Expenses:** Within the group, create expenses and view the summary of what each user owes.

## Contributing

Contributions are welcome! Please follow these steps:

1. **Fork the Repository**
2. **Create a Feature Branch**

    ```bash
    git checkout -b feature/YourFeatureName
    ```

3. **Commit Your Changes**

    ```bash
    git commit -m "Add some feature"
    ```

4. **Push to the Branch**

    ```bash
    git push origin feature/YourFeatureName
    ```

5. **Open a Pull Request**

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Thanks to the ASP.NET and Angular communities for their awesome documentation and tutorials.
