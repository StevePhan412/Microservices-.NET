# Microservices-.NET
Build with .Net 7.0, MongoDB for Database

ROADMAP
![image](https://github.com/StevePhan412/Microservices-.NET/assets/43378561/7a94de4a-9831-4f49-94cd-b16f7579c6d3)

Note

In this project, what I have learned is:
- How a ASP.NET MVC project is built
- How to effectively creating microservices with a template Play.Common
and using Nuget Package Manager to package it and referring it throughout the rest of the ecosystem
- Using docker script to build MongoDB
- Handling partial failures between services by adding timeouts for requests to a service, perform call retries number of times with a longer wait between each retry using Polly
- Using RabbitMQ as the message broker to convert the microservices communication method from synchronous to asynchronous


Installation
- Install .NET SDK 7
- Make sure to refer Play.Common package in your Nuget Package Manager
- In Play.Catalog.Service and Play.Inventory.Service folder, do "dotnet restore"
- In Play.Infra, use command "docker-compose up" to start MongoDB (Make sure you don't have one running already)