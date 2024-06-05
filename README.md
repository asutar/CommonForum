# Common Forum Project Documentation

## Overview

The Common Forum Project is a web application designed to facilitate discussions and knowledge sharing in forums of any size. The application is built using ASP.NET MVC and SQL Server. The system supports two types of users: Admin and End User, each with distinct roles and responsibilities.

## Features

### Admin Features
- **Manage Data**: Admins have the ability to manage all the data within the forum, including articles, questions, and comments.

### End User Features
- **Create Login**: Users can register and create their own login.
- **Add Individual Articles**: Users can write and publish their own articles.
- **Ask Questions**: Users can post questions to the forum.
- **Comment on Existing Questions and Articles**: Users can provide comments and engage in discussions on existing questions and articles.

## System Architecture

### Technologies Used
- **Backend**: ASP.NET MVC
- **Database**: SQL Server
- **Frontend**: HTML, CSS, JavaScript
- **Libraries**: jQuery

### Project Structure
- **Controllers**: Handles the request and response cycle.
- **Models**: Represents the data and business logic.
- **Views**: Renders the user interface.
- **Migrations**: Manages database schema changes.

## Database Schema

The database schema includes the following tables:
- **Users**: Stores user details including roles (admin, end user).
- **Articles**: Stores articles created by users.
- **Questions**: Stores questions posted by users.
- **Comments**: Stores comments on articles and questions.

## User Roles and Permissions

### Admin
Admins have full access to all features and functionalities of the system, including managing all articles, questions, and comments.

### End User
End users have restricted access. They can create logins, add articles, ask questions, and comment on existing articles and questions.

## Functionality

### Creating Login
1. **Access**: End User
2. **Steps**:
   - Navigate to the "Register" section.
   - Fill in the registration form with necessary details (username, password, email, etc.).
   - Submit the form to create a new user account.

### Adding Individual Articles
1. **Access**: End User
2. **Steps**:
   - Navigate to the "Articles" section.
   - Click on "Add New Article".
   - Fill in the article details (title, content, tags, etc.).
   - Submit to publish the article.

### Asking Questions
1. **Access**: End User
2. **Steps**:
   - Navigate to the "Questions" section.
   - Click on "Ask a Question".
   - Fill in the question details (title, description, tags, etc.).
   - Submit to post the question.

### Commenting on Existing Questions and Articles
1. **Access**: End User
2. **Steps**:
   - Navigate to the article or question you wish to comment on.
   - Scroll to the comments section.
   - Enter your comment in the provided field.
   - Submit to post the comment.

### Managing Data (Admin)
1. **Access**: Admin
2. **Steps**:
   - Navigate to the admin panel.
   - Use the provided options to manage articles, questions, and comments (edit, delete, etc.).

## Installation and Setup

### Prerequisites
- .NET Core SDK
- SQL Server
- Visual Studio

### Steps
1. **Clone the Repository**:
   ```bash
   git clone <repository-url>
   ```
2. **Open the Solution**:
   - Open the project solution in Visual Studio.

3. **Update Database Connection String**:
   - In `appsettings.json`, update the connection string to point to your SQL Server instance.

4. **Run Migrations**:
   - Open the Package Manager Console and run:
     ```bash
     Update-Database
     ```

5. **Build and Run the Project**:
   - Build the solution in Visual Studio.
   - Run the project to start the web application.

## Conclusion

The Common Forum Project provides a robust platform for forums of any size to manage discussions and knowledge sharing. With features tailored for both admin and end users, the application ensures smooth management of articles, questions, and comments.

For any further queries or issues, please refer to the project documentation or contact the support team.
