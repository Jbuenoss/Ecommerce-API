# Ecommerce-API

Ecommerce-API is a  web API designed for managing an e-commerce platform. This API handles users and products, providing essential functionalities required for a typical e-commerce application.

## Features

* **User Management:** Create, read, update, and delete user information
* **Product Management:** Create, read, update, and delete product information.
* **Entity Framework Integration:** Simplified database operations with Entity Framework.

## Technologies Used

* **.NET:** The framework used to develop the API, offering a powerful and flexible platform
* **ASP.NET Core:** For building the web API, providing high performance and cross-platform capabilities.
* **Entity Framework:** For Object-Relational Mapping (ORM), facilitating database interactions.
* **xUnit:** Used for testing the repositories and controllers, ensuring code quality and reliability.

## API Endpoints

### Users
* GET /api/user
* GET /api/user/{id}
* GET /api/user/product/{userId}
* POST /api/user
* PUT /api/user
* DELETE /api/user
  
### Products
* GET /api/product
* GET /api/product/{id}
* POST /api/product
* PUT /api/product
* DELETE /api/products
