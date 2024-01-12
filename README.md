Welcome to the **Stll WebAPI** source code!

This API serves as the server-side component for the Stll launcher.

**Stll WebAPI Features:**
1. **User Registration:** Create a user profile in the system.
2. **User Authorization:** Users can obtain a JWT token using their login and password.
3. **Java Runtime Download:** Authorized users can download the Java runtime.
4. **Game Resources Download:** Authorized users can download game resources.

**For Developers:**
You can use this project as a template for your own WebAPI. The solution has a flexible architecture that can be easily extended if needed.

**Project Architecture:**
- **Domain:** Abstraction (repository) for working with EF Core. Independent project configured for use with Microsoft.DI. Uses Pomelo.EntityFrameworkCore.MySql.
- **Shared:** Various services, such as IPasswordHasher. A standalone project.
- **Types:** Basic types used by the API. Dependent on Domain.
- **Forge:** Contains the implementation of the database context. Dependent on Types. Uses Pomelo.EntityFrameworkCore.MySql as an ORM.
- **CQRS:** Commands, queries + handlers. Dependent on Types and Shared. Uses MediatR.
- **WebAPI:** Controllers + application startup. Dependent on CQRS and Forge.

**Endpoints:**

1. **AuthorizationController**
   - *Authorization:*
   ```bash
   curl -X POST -H "Content-Type: application/json" -d '{"username": "your_username", "password": "your_password", "grant_type": "password"}' https://your-api/api/oauth2/token
   
2. **FilesController - Download Java:**
   ```bash
   curl -OJL https://your-api/api/files/java

3. **UsersController - Registration:**
   ```bash
   curl -X POST -H "Content-Type: application/json" -d '{"username": "your_username", "password": "your_password"}' https://your-api.com/api/users/register
