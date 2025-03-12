# Microservices-.NET
Build with .Net 7.0, MongoDB for Database

ROADMAP
![image](https://github.com/StevePhan412/Microservices-.NET/assets/43378561/7a94de4a-9831-4f49-94cd-b16f7579c6d3)

Note

In this project, what I have learned:
- How a ASP.NET MVC project is built
- How to effectively creating microservices with a template Play.Common
and using Nuget Package Manager to package it and referring it throughout the rest of the ecosystem
- Using docker script to build MongoDB
- Handling partial failures between services by adding timeouts for requests to a service, perform call retries number of times with a longer wait between each retry using Polly
- Using RabbitMQ as the message broker to convert the microservices communication method from synchronous to asynchronous
- How to easily deploy a simple authentication system using ASP.NET Core Identity

Installation
- Install .NET SDK 7 & 8
- Make sure to refer Play.Common package as PlayEconomy as a source in your Nuget Package Manager
- Play.Infra, use command "docker-compose up -d" to start MongoDB and RabbitMQ (Make sure you don't have one running already)
- Play.Frontend run "npm install" then either use "npm start" or configured launch settings in VS Code Debugger
- Play.Catalog.Service, Play.Inventory.Service and Play.Identity.Service should be restored first then run
