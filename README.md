# TestEMI
# Describe how you would implement authentication and authorization in this API.
To implement authentication in the API I will use JWT tokens because it provides security and scalability.
For authorization I will use policies that allow me to delimit the access to the API's depending on the role of the user that consumes them.

# Explain the concept of middleware in ASP.NET Core.
Defines how HTTP requests are handled in the application. It refers to the components in the request-response pipeline that process requests and responses. Middleware components are invoked sequentially to perform various operations, such as logging, authentication, authorization, routing, and response modification.

# What are some common performance issues in .NET applications and how can you address them?
The performance problems I have encountered are:
- Inefficient Database Operations. Solution: Use ORM tools like Entity Framework efficiently by avoiding lazy loading when unnecessary. Optimize SQL queries and add appropriate indexes.
- Bad Asynchronous Code. Solution: Use async/await correctly and avoid blocking threads.
- Bad LINQ Queries. Solution: Avoid unnecessary .ToList() calls and materializing queries prematurely.

# Describe how you would profile and optimize a slow-running query in an ASP.NET Core application.
To identify slow queries you must first identify them using tools such as Application Insights to look for metrics such as query execution time, request duration, and database call counts. Add logs to the application. From the database you can use SQL Server Profiler to identify slow queries. After identifying the query you can analyze if it is missing indexes or has inefficient joins. You should also check the filters. Return only the columns that are going to be used.
