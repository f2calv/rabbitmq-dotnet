# RabbitMQ with .NET

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=f2calv_rabbitmq-dotnet&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=f2calv_rabbitmq-dotnet)

A .NET playground for learning RabbitMQ producer and consumer patterns.

## Projects

| Project | Purpose |
| --- | --- |
| `ProducerApp` | Publishes example messages. |
| `ConsumerApp` | Consumes example messages. |
| `SharedLibrary` | Contains shared messaging behavior. |

## Prerequisites

- A .NET 10 SDK
- Docker with Compose

## Run locally

The Compose stack builds both applications and starts RabbitMQ:

```pwsh
docker compose up --build
```

The broker listens on `localhost:5672`; its management port is exposed on `localhost:15672` when the
selected RabbitMQ image provides the management UI.

To build without containers:

```pwsh
dotnet restore .\rabbitmq-dotnet.slnx
dotnet build .\rabbitmq-dotnet.slnx --no-restore
```

Stop and remove the local containers when finished:

```pwsh
docker compose down
```

Use synthetic messages and local-only credentials in this playground.

## Resources

- [RabbitMQ .NET tutorial](https://www.rabbitmq.com/tutorials/tutorial-one-dotnet)
- [OpenTelemetry](https://opentelemetry.io/)
