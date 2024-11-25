# Devices Manager API

A REST API developed using C# and Entity Framework for managing devices. This project includes essential CRUD operations and additional functionality for filtering devices by brand. 

## Features

- **GET** `/Device`: Retrieve all devices.
- **POST** `/Device`: Create a new device.
- **PUT** `/Device`: Update an existing device.
- **GET** `/Device/{id}`: Retrieve a specific device by its identifier.
- **DELETE** `/Device/{id}`: Delete a specific device by its identifier.
- **GET** `/Device/get-by-brand/{brand}`: Retrieve devices by brand name.

### API Documentation
The API uses **Swagger** for automatic documentation. Once the API is running, you can access the Swagger UI to explore and test all available routes.

---

## Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd <repository-folder>
   ```

2. **Set up the database**
   - Use the file `DatabaseStructure.sql` located in the project root to create the PostgreSQL database structure.
   - Update the `appsettings.json` files in both projects (`DevicesManager.Presentation.Test` and `DevicesManager.Presentation`) with your local database connection string under the property `DevicesDBContext`.

3. **Run the API**
   ```bash
   dotnet run --project DevicesManager.Presentation
   ```

4. **Access Swagger**
   Open your browser and navigate to: `http://localhost:<port>/swagger`

---

## Running Unit Tests

The solution includes a test project (`DevicesManager.Presentation.Test`) with unit tests for all API routes. 

### Prerequisites for running tests:
- Ensure the database is empty before running the tests.

### Running tests:
1. Navigate to the test project folder:
   ```bash
   cd DevicesManager.Presentation.Test
   ```
2. Run the tests:
   ```bash
   dotnet test
   ```

---

### **Project Structure**

The project is organized following **Domain-Driven Design (DDD)** principles to ensure scalability, maintainability, and separation of concerns:

1. **DevicesManager.Domain**  
   - Contains the **core domain logic** and rules, ensuring the business logic is independent of infrastructure and presentation concerns.
   - Key components:
     - **Entities**: Represent the core objects of the domain, such as `Device`.
     - **Value Objects**: Immutable objects that define descriptive aspects of entities.
     - **Interfaces**: Define contracts for repositories and services to be implemented by infrastructure layers.
     - **Aggregates**: Group related entities for consistency.

2. **DevicesManager.Application**  
   - Acts as the **service layer**, coordinating operations between the domain and presentation/infrastructure layers.
   - Key components:
     - **DTOs (Data Transfer Objects)**: Simplified objects used for API communication.
     - **Use Cases/Services**: Handle application-specific business logic for API endpoints.
     - **Mappers**: Transform domain entities into DTOs and vice versa.

3. **DevicesManager.Infrastructure**  
   - Implements the **data access layer** and integrates with external systems.
   - Key components:
     - **Repositories**: Concrete implementations of the domain interfaces, using Entity Framework for database operations.
     - **Database Configuration**: Includes database context (`DevicesDBContext`) and mappings for domain entities.
     - **Third-Party Integrations**: Interfaces with external APIs or services.

4. **DevicesManager.Presentation**  
   - The **API layer**, responsible for handling HTTP requests and returning responses.
   - Key components:
     - **Controllers**: Define API endpoints for managing devices.
     - **Middleware**: Manage cross-cutting concerns like error handling and authentication.
     - **Swagger Integration**: Automatically document and test API routes.

5. **DevicesManager.Presentation.Test**  
   - The **testing project**, focused on unit testing the API.
   - Key components:
     - **Mocks**: Replace database dependencies to test functionality in isolation.
     - **Test Cases**: Cover all API endpoints to ensure correctness and reliability.

---

### **Diagram Representation**

The project structure can be visualized as:

```
DevicesManager
│
├── DevicesManager.Domain
│   ├── Entities/
│   ├── ValueObjects/
│   ├── Interfaces/
│   └── Aggregates/
│
├── DevicesManager.Application
│   ├── DTOs/
│   ├── Services/
│   └── Mappers/
│
├── DevicesManager.Infrastructure
│   ├── Repositories/
│   ├── Database/
│   │   ├── DevicesDBContext.cs
│   │   └── Configurations/
│   └── Integrations/
│
├── DevicesManager.Presentation
│   ├── Controllers/
│   ├── Middleware/
│   ├── appsettings.json
│   └── Swagger/
│
└── DevicesManager.Presentation.Test
    ├── Mocks/
    └── Tests/
```

---

### **Benefits of the DDD Structure**
- **Scalability**: Easily extendable by adding new features without affecting existing logic.
- **Maintainability**: Clear separation of concerns makes the codebase easier to maintain.
- **Testability**: Each layer can be tested independently, improving overall quality.

---

## Configuration

### Database Configuration
- Locate the `appsettings.json` files in both projects.
- Update the connection string under the `DevicesDBContext` property to match your PostgreSQL database configuration.

```json
"ConnectionStrings": {
  "DevicesDBContext": "Host=<host>;Database=<database>;Username=<username>;Password=<password>"
}
```

---

## Contributing

1. Fork the repository.
2. Create a feature branch (`git checkout -b feature/new-feature`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature/new-feature`).
5. Create a pull request.

---

## Acknowledgments

- [Swagger](https://swagger.io) for API documentation.
- [Entity Framework](https://learn.microsoft.com/en-us/ef/) for ORM.
- PostgreSQL for database support.

Feel free to modify or enhance this README as needed!
