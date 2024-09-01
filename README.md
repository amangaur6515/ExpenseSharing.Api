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
<img width="956" alt="Screenshot 2024-09-01 204151" src="https://github.com/user-attachments/assets/72c5d1d2-44f6-49ae-af2a-01e59c761d61">

 

### Home Page
 
<img width="955" alt="Screenshot 2024-09-01 204316" src="https://github.com/user-attachments/assets/3e9656bf-05cb-4d7f-a923-bdc657decf0f">

### Group Creation
 
<img width="956" alt="Screenshot 2024-09-01 204434" src="https://github.com/user-attachments/assets/0a5ddff1-299a-4fcb-85ec-cde5aa29a242">

### Expenses Page
 
<img width="956" alt="Screenshot 2024-09-01 204546" src="https://github.com/user-attachments/assets/1ab500a4-cf21-48e2-a83b-d296d1c873b7">

### Expense Detail Page

<img width="957" alt="Screenshot 2024-09-01 204701" src="https://github.com/user-attachments/assets/9a15a54b-62ec-4ba5-82cb-2e8c39011d10">

### Create Expense Page

<img width="956" alt="Screenshot 2024-09-01 204957" src="https://github.com/user-attachments/assets/e65a313e-5df3-4c9e-a72b-5eca5e0219ea">

## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Node.js](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)  

### Installation

1. **Clone the Backend Repository:**

    ```bash
    git clone   https://github.com/amangaur6515/ExpenseSharing.Api.git
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
    git clone  https://github.com/amangaur6515/expense-sharing-app.Ui.git
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
    - The backend API will be running at `http://localhost:7035` (or the port you specified).

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
