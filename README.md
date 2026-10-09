# MyProject
# 🏥 Hospital Management System

An educational hospital management web application currently under development, built using ASP.NET Core MVC and C#.

## 📌 Project Overview

This project aims to provide a web-based system for organizing basic hospital operations, including patient, doctor, and department management.

It is being developed as a practical project to strengthen my skills in ASP.NET Core MVC, Entity Framework Core, relational database design, and server-side web development.

## 🛠️ Technologies

* C#
* ASP.NET Core MVC
* Entity Framework Core
* SQL Server
* Razor Views
* HTML and CSS

## ✅ Current Implementation

* Patient creation and listing
* Doctor creation and listing
* Department creation and listing
* Entity Framework Core database integration
* Model validation using `ModelState.IsValid`
* Doctor–patient relationship loading
* Dashboard statistics for patients, doctors, and departments
* Doctor selection data for patient and department forms

Some functionality is still being developed and tested.

## 🏗️ Application Structure

* **Models:** Represent hospital entities, including patients, doctors, and departments.
* **Controllers:** Handle application requests and database operations.
* **Views:** Provide the user interface through Razor.
* **DataContext:** Manages database access using Entity Framework Core.

## 🚧 Planned Improvements

* Medical record PDF upload and download
* Complete doctor–patient assignment workflow
* Improved validation and error handling
* Authentication and role-based authorization
* Dashboard and user interface improvements
* Deployment and cloud database configuration

## ⚙️ Running the Project

1. Install the .NET SDK compatible with the project.
2. Install or configure a compatible SQL Server instance.
3. Clone this repository and open the solution in Visual Studio.
4. Configure the database connection string using local configuration or user secrets.
5. Apply the existing Entity Framework Core migrations to your development database.
6. Run the application.

Exact setup requirements may change as development continues.

## 🔐 Security and Privacy

* Do not commit passwords, credentials, or production connection strings.
* Use fictional data for demonstrations.
* Do not use this educational prototype to store real patient records.

## 📍 Project Status

**In development.**

Features, architecture, and documentation may change as the project evolves.

## 👨‍💻 Author

Developed as a personal learning and portfolio project.
