# RabbitMQ hello world

A hello using RabbitMQ with C# 11 &amp; .NET 7

- C# 11
- .NET 7
- RabbitMQ
- Docker

this application is just to make a communication and log the results using RabbitMQ.

### Configure environment

this application uses docker. so, you have to install it.

after you have docker on your machine go to the repo root folder and type:

```shell
docker compose up -d
```

so, all services you need will just work.

when you want to stop, run:

```shell
docker compose down
```

you can access the rabbit mq managent dashboard on your navigator at: [http://localhost:8080](http://localhost:8080)

### running the `Producer` project

- go to producer project folder
  ```shell
  cd ./Application/Producer
  ```
- run project with dotnet
  ```shell
  dotnet run
  ```
- enter any username
- send any message you want

### running the `Consumer` project

- go to consumer project folder
  ```shell
  cd ./Application/Consumer
  ```
- run project with dotnet

you will see that when some message is published the consumer project will log the publisher name and the message it self
