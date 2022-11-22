SQL server klargøring:


USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [api]    Script Date: 22-11-2022 17:49:32 ******/
CREATE LOGIN [api] WITH PASSWORD=N'api', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO

ALTER LOGIN [api] DISABLE
GO

USE [BookStore-Demo1]
GO

/****** Object:  User [api]    Script Date: 22-11-2022 17:50:35 ******/
CREATE USER [api] FOR LOGIN [api] WITH DEFAULT_SCHEMA=[dbo]
GO

==========================================

Docker: 
Højreklik på Dockerfile og vælg Build Docker Image

Bemærk servernavn: host.docker.internal

docker run -it -p 33333:80 -p :33334:443 -e "ConnectionStrings:BookStoreConnection"="Server=host.docker.internal;Database=BookStore-Demo1;User Id=api; Password=api;MultipleActiveResultSets=true" dockerapidemoapi

=========================================== 
Swagger:

http://localhost:33333/swagger/index.html