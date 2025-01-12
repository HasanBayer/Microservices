This repository contains a complete implementation of a **Microservices Architecture** developed using **.NET 8.0**. The project showcases a fully functional, demonstrating modern backend development techniques and best practices for microservices.

## Key Features

### Microservices Implemented:
1. **Catalog Microservice**
   - Manages course information.
   - Database: MongoDB

2. **Basket Microservice**
   - Handles shopping cart operations.
   - Database: RedisDB

3. **Discount Microservice**
   - Manages discount coupons for users.
   - Database: PostgreSQL

4. **Order Microservice**
   - Processes and manages orders.
   - Uses **Domain-Driven Design** (DDD) and **CQRS Pattern** with MediatR library.
   - Database: SQL Server

5. **FakePayment Microservice**
   - Simulates payment transactions.

6. **Identity Server Microservice**
   - Handles user authentication and token generation.
   - Supports **OAuth 2.0** and **OpenID Connect** protocols.
   - Database: SQL Server

7. **PhotoStock Microservice**
   - Manages and serves course images.

8. **API Gateway**
   - Implements routing and request aggregation using **Ocelot Library**.

### Additional Features:
- **Asynchronous and Synchronous Communication** between microservices using **RabbitMQ** (MassTransit).
- Implementation of **Eventual Consistency** for database synchronization.
- Use of **AccessToken** and **RefreshToken** for securing microservices.
- Dockerized microservices with **Docker** and **Docker Compose**.
- Integration with multiple databases:
  - MongoDB
  - PostgreSQL
  - Redis
  - SQL Server
- User interface built with **ASP.NET Core MVC**.

## Technologies Used
- **.NET 8.0**
- **RabbitMQ (MassTransit)**
- **Ocelot API Gateway**
- **IdentityServer4**
- **Domain-Driven Design (DDD)**
- **CQRS Pattern**
- **Docker & Docker Compose**
- **PostgreSQL, MongoDB, Redis, SQL Server**
- **Postman**

## How to Run
1. Clone the repository:
   ```bash
   git clone <repository_url>
   ```
2. Navigate to the project directory.
3. Start the services using Docker Compose:
   ```bash
   docker-compose up --build
   ```
4. Access the services via the API Gateway.

## Screenshots
_Add screenshots of the platform UI and key features here._

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---
Developed by **Hasan BAYER**.
