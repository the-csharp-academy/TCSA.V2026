using TCSA.V2026.Data.Enums;
using TCSA.V2026.Data.Models;
using TCSA.V2026.Data.Models.LanguageModels;

namespace TCSA.V2026.Data.Helpers.ProjectsSubHelpers;

public class DockerProjectsHelper
{
    internal static List<Project> GetProjects()
    {
        return new List<Project>
        {
             new Project
             {
                Id = (int)ArticleName.DockerIntro,
                Title = "Intro to Docker",
                IconUrl = "icons8-container-64.png",
                BannerUrl = "intro-docker-banner.jpg",
                Slug = "intro-docker",
                LanguageHeadings = new EnglishHeadings(),
                Description = "Make your applications able to run anywhere with Docker containers",
                Area = Area.Docker,
                Level = Level.Black,
                ExperiencePoints = 50,
                DisplayOrder= 1,
                RepositoryLink = "https://github.com/TheCSharpAcademy/CodeReviews.Docker.Containers",
                Introduction = new List<Paragraph>
                {
                    new Paragraph
                    {
                        Body="Welcome to the your first Docker project! One of the coolest latest concepts popularized in the world of software development is containerization, a technique for bundling an application along with all its necessary dependencies and configurations into a single, self-contained unit: the so-called container. This container can run reliably across different computing environments, whether it's on a developer’s laptop, a test server, or in production on the cloud."
                    },
                    new Paragraph
                    {
                        Body="What makes it powerful is that containers share the host system's operating system kernel, which makes them lightweight and fast compared to traditional virtual machines. They ensure that \"it works on my machine\" becomes a thing of the past."
                    },
                    new Paragraph
                    {
                        Body="Docker is the tool that pushed containerization from a niche concept into the mainstream of modern development. With intuitive commands and a vast ecosystem, Docker allows developers to create, manage, and deploy containers effortlessly. Whether you're building microservices or deploying full-stack applications, Docker simplifies the process and empowers teams to iterate quickly with confidence."
                    }

                },
                Requirements = new List<string>
                {
                    @"You need to containerize a console app with Docker.",
                    @"The goal is to demonstrate a working application inside a container. You do NOT need to use external databases, volumes, or advanced Docker features. The Math Game is ideal for this project, since it doesn't contain any dependencies.",
                    @"You must create a Dockerfile that defines how your application is containerized. Include instructions to restore, build, and run your project.",
                    @"Your Docker image should be buildable using the 'docker build' command, and the container should be runnable with 'docker run'.",
                    @"You should include a brief README explaining how to build and run your container. Mention any dependencies or setup steps.",
                },
                Resources = new List<string>
                {

                    "<a target='_blank' href='https://learn.microsoft.com/en-us/dotnet/core/docker/build-container?tabs=windows&pivots=dotnet-9-0'>Microsoft Tutorial: Containerize a .NET app</a>",
                    "<a target='_blank' href='https://www.youtube.com/watch?v=HvNR1LHxboM'>Youtube: C# Docker Console Application (short video)</a>",
                    "<a target='_blank' href='https://www.youtube.com/watch?v=cWMztQwIQNs'>Youtube: Docker Full Course (in-depth video)</a>",
                },
                Tips = new List<string>
                {
                    "You'll realise it's easy to get a container going without really understanding what's going on. Make sure you write notes as you go and write down questions that will inevitably arise. Use that list of questions to close knowledge gaps. It will serve as a rich reference in the future.",
                    "Don't rush through the steps, make sure you understand each step. Write your thought process (including doubts) in your Readme.",
                    "It's ok to use Docker Desktop at first, but if you do, we recommend you replicate the same actions using the CLI.",
                    "Make sure you REALLY understand what each of these are: Container, Image, Container Registry. How does a Container Relate to an Image?",
                    "On the same token, don't move on before understanding each line of your Docker file."
                },
                Challenges = new List<string>
                {
                    "Update your Dockerfile to accept command-line arguments when running the container. For example, the user could pass a difficulty level or username to the math game.",
                    "Tag your Docker image with a custom version label (e.g. 'mathgame:v1') and use that tag when running the container. This helps build awareness of image versioning and future maintainability."
                }
            },
             new Project
             {
                 Id = (int)ArticleName.DockerCompose,
                 Title = "Docker Compose",
                 IconUrl = "icons8-composing-64.png",
                 BannerUrl = "dockercomposer-banner.jpg",
                 Slug = "docker-compose",
                 LanguageHeadings = new EnglishHeadings(),
                 Description = "Learn how to run multi-container applications with Docker Compose",
                 Area = Area.Docker,
                 Level = Level.Black,
                 ExperiencePoints = 75,
                 DisplayOrder = 2,
                 RepositoryLink = "https://github.com/TheCSharpAcademy/CodeReviews.Docker.Compose",
                 Introduction = new List<Paragraph>
                 {
                     new Paragraph
                     {
                         Body = "In the previous project, you learned how to containerize a simple console application. That was a great first step, but real-world applications usually depend on more than one service. A web application might need a database, a cache, a background worker, or another API."
                     },
                     new Paragraph
                     {
                         Body = "Running all of these pieces manually can quickly become painful. Docker Compose solves this by allowing you to describe your application services in a single YAML file. With one command, you can build, start, stop and remove the containers that make up your local development environment."
                     },
                     new Paragraph
                     {
                         Body = "In this project, you'll use Docker Compose to run a .NET application and a database together. The goal is to understand how containers communicate, how environment variables are passed, and how Compose makes local development more predictable."
                     }
                 },
                 Requirements = new List<string>
                 {
                     @"You need to create a simple ASP.NET Core Web API.",
                     @"Your application needs to use a database. You can use SQL Server, PostgreSQL or another relational database image supported by Docker.",
                     @"You need to create a Dockerfile for your .NET application.",
                     @"You need to create a docker-compose.yml file that runs both your .NET application and your database.",
                     @"Your application needs to connect to the database using a connection string provided through Docker Compose.",
                     @"You need to seed test data so it's clear the app is successfully communicating with the database container.",
                     @"Your docker-compose.yml file should expose the necessary ports so the app can be accessed from the browser or an API client.",
                     @"You should include a README explaining how to build and run the application using Docker Compose.",
                     @"Your README should explain the purpose of each service in your docker-compose.yml file.",
                 },
                 Resources = new List<string>
                 {
                     "<a target='_blank' href='https://learn.microsoft.com/en-us/visualstudio/containers/tutorial-multicontainer?view=visualstudio'>Microsoft Tutorial: Create a multi-container app with Docker Compose</a>",
                     "<a target='_blank' href='https://learn.microsoft.com/en-us/aspnet/core/security/docker-compose-https'>Microsoft Docs: Hosting ASP.NET Core images with Docker Compose over HTTPS</a>",
                     "<a target='_blank' href='https://docs.docker.com/compose/'>Docker Compose Documentation</a>",
                 },
                 Tips = new List<string>
                 {
                     "Start with only two services: your .NET app and your database. Once that works, you can experiment with additional services.",
                     "Pay close attention to service names. In Docker Compose, your app usually connects to the database using the database service name, not localhost.",
                     "Don't hard-code the connection string in your application. Use environment variables so your app behaves like a real deployed application.",
                     "Make sure you understand the difference between build context, image name, container name, ports and environment variables.",
                     "Practice running docker compose up, docker compose down and docker compose logs from the CLI."
                 },
                 Challenges = new List<string>
                 {
                     "Add a volume so the database data persists after the containers are stopped.",
                     "Add a health check to the database service.",
                     "Add a second .NET service, such as a small background worker or a second API.",
                     "Create separate docker-compose files for development and production-like configuration."
                 }
             },
             new Project
             {
                 Id = (int)ArticleName.DockerFullStack,
                 Title = "Containerized Full-Stack App",
                 IconUrl = "icons8-containers-100.png",
                 BannerUrl = "dockercontainers-banner.png",
                 Slug = "containerized-full-stack-app",
                 LanguageHeadings = new EnglishHeadings(),
                 Description = "Containerize a full-stack application with a frontend, API and database",
                 Area = Area.Docker,
                 Level = Level.Black,
                 ExperiencePoints = 100,
                 DisplayOrder = 3,
                 RepositoryLink = "https://github.com/TheCSharpAcademy/CodeReviews.Docker.FullStack",
                 Introduction = new List<Paragraph>
                 {
                     new Paragraph
                     {
                         Body = "Now that you know how to run a .NET app and a database with Docker Compose, it's time to move closer to a realistic production-style application. Many modern apps are split into separate frontend, backend and database layers."
                     },
                     new Paragraph
                     {
                         Body = "In this project, you'll containerize a full-stack application. The frontend can be React, Angular, Blazor WebAssembly or another client-side solution. The backend will be a .NET Web API, and the data will be stored in a database container."
                     },
                     new Paragraph
                     {
                         Body = "This project will help you understand how separate applications communicate in a containerized environment. You'll also practice configuring CORS, environment variables, database persistence and multi-service startup."
                     }
                 },
                 Requirements = new List<string>
                 {
                     @"You need to create a full-stack application with a frontend, a .NET Web API and a database.",
                     @"The frontend and backend should be separate services and the frontend needs to consume the Web API.",
                     @"The database needs to run in its own container.",
                     @"You need to use Dockerfiles for the frontend and backend projects.",
                     @"You need to use Docker Compose to run the frontend, backend and database together.",
                     @"You need to configure CORS correctly so the frontend can communicate with the API.",
                     @"You need to use environment variables for API URLs, database connection strings and any other environment-specific values.",
                     @"You need to use a volume so database data can persist between container restarts.",
                     @"You should include a README explaining how the containers communicate with each other. It should include commands to build, run, stop and remove the application containers."
                 },
                 Resources = new List<string>
                 {
                     "<a target='_blank' href='https://learn.microsoft.com/en-us/dotnet/core/docker/build-container'>Microsoft Tutorial: Containerize a .NET app</a>",
                     "<a target='_blank' href='https://learn.microsoft.com/en-us/visualstudio/containers/tutorial-multicontainer?view=visualstudio'>Microsoft Tutorial: Multi-container apps with Docker Compose</a>",
                     "<a target='_blank' href='https://docs.docker.com/compose/'>Docker Compose Documentation</a>",
                     "<a target='_blank' href='https://docs.docker.com/build/building/multi-stage/'>Docker Docs: Multi-stage builds</a>"
                 },
                 Tips = new List<string>
                 {
                     "Keep the business case simple. This project is about containerization, not complex domain modelling.",
                     "Build and test the backend first, then the frontend, then containerize each part separately.",
                     "Once each container works on its own, bring everything together with Docker Compose.",
                     "Use browser dev tools and docker compose logs to debug connection issues between the frontend and backend.",
                     "Be careful with localhost. Inside a container, localhost means the container itself, not your host machine or another container."
                 },
                 Challenges = new List<string>
                 {
                     "Add Nginx as a reverse proxy in front of the frontend and API.",
                     "Add HTTPS support for local development.",
                     "Add a Redis container for caching.",
                     "Create a production-ready Dockerfile using multi-stage builds.",
                     "Add integration tests that can run against the containerized API and database."
                 }
             },
             new Project
             {
                 Id = (int)ArticleName.DockerK8s,
                 Title = "Intro to Kubernetes",
                 IconUrl = "icons8-kubernetes-96.png",
                 BannerUrl = "introk8s-banner.jpg",
                 Slug = "intro-to-kubernetes",
                 LanguageHeadings = new EnglishHeadings(),
                 Description = "Deploy a containerized .NET application to Kubernetes",
                 Area = Area.Docker,
                 Level = Level.Black,
                 ExperiencePoints = 125,
                 DisplayOrder = 4,
                 RepositoryLink = "https://github.com/TheCSharpAcademy/CodeReviews.Docker.Kubernetes",
                 Introduction = new List<Paragraph>
                 {
                     new Paragraph
                     {
                         Body = "Docker helps us package applications into containers, and Docker Compose helps us run multiple containers locally. But what happens when an application needs to run reliably in a production-like environment, restart automatically, scale to multiple instances and expose services to other applications?"
                     },
                     new Paragraph
                     {
                         Body = "This is where Kubernetes enters the picture. Kubernetes is a container orchestration platform that helps deploy, scale and manage containerized applications. It introduces concepts such as Pods, Deployments, Services, ConfigMaps and Secrets."
                     },
                     new Paragraph
                     {
                         Body = "In this project, you'll take a simple containerized .NET application and deploy it to a local Kubernetes cluster. The objective isn't to master Kubernetes in one project, but to understand the core building blocks and how a container becomes a running application inside a cluster."
                     }
                 },
                 Requirements = new List<string>
                 {
                     @"You need to use a containerized ASP.NET Core Web API.",
                     @"You need to run the application in a local Kubernetes cluster. You can use Docker Desktop Kubernetes, Minikube or Kind.",
                     @"You need to create Kubernetes YAML manifests for your application.",
                     @"You need to create a Deployment for your .NET application.",
                     @"You need to create a Service to expose your application inside or outside the cluster.",
                     @"Your Deployment should run at least two replicas of your application.",
                     @"You need to demonstrate that Kubernetes can restart your application if a pod is deleted.",
                     @"You need to use a ConfigMap for non-sensitive configuration.",
                     @"You need to use a Secret for at least one sensitive configuration value.",
                     @"You need to document the kubectl commands used to apply, inspect and delete your Kubernetes resources.",
                     @"Your README should explain, in your own words, the difference between a Docker container, a Kubernetes Pod, a Deployment and a Service.",
                 },
                 Resources = new List<string>
                 {
                     "<a target='_blank' href='https://kubernetes.io/docs/home/'>Kubernetes Documentation</a>",
                     "<a target='_blank' href='https://kubernetes.io/docs/concepts/workloads/controllers/deployment/'>Kubernetes Docs: Deployments</a>",
                     "<a target='_blank' href='https://kubernetes.io/docs/concepts/services-networking/service/'>Kubernetes Docs: Services</a>",
                     "<a target='_blank' href='https://docs.docker.com/guides/kube-deploy/'>Docker Docs: Deploy to Kubernetes</a>",
                     "<a target='_blank' href='https://learn.microsoft.com/en-us/dotnet/core/docker/build-container'>Microsoft Tutorial: Containerize a .NET app</a>"
                 },
                 Tips = new List<string>
                 {
                     "Don't try to learn all of Kubernetes at once. Focus on Pods, Deployments and Services first.",
                     "Before writing Kubernetes YAML, make sure your Docker image builds and runs correctly by itself.",
                     "Use kubectl get pods, kubectl describe pod and kubectl logs frequently. These commands will help you understand what Kubernetes is doing.",
                     "Use a simple app for this project. The complexity should come from learning Kubernetes, not from the application itself.",
                     "Write down every command you use. Kubernetes has a steep learning curve, and your README will become an important reference."
                 },
                 Challenges = new List<string>
                 {
                     "Add a database to your Kubernetes setup using a separate Deployment and Service.",
                     "Add a readiness probe and a liveness probe to your application Deployment.",
                     "Create separate Kubernetes manifests for development and production-like configuration.",
                     "Use kubectl scale to increase and decrease the number of running replicas.",
                     "Push your Docker image to Docker Hub or another container registry and deploy Kubernetes using the remote image."
                 }
             },
        };

    }
}
