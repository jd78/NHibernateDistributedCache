NHibernateDistributedCache
==========================

NHibernate 2nd level cache using Couchbase

The project is a distributed cache example using all the power of NHibernate to manage the Second Level Cache.
I'm using Couchbase as distributed cache provider, my favourite NO-SQL DB.

In order to run the project you need to:

- Visual Studio 2012+
- Install Couchbase (http://www.couchbase.com/)
- If you don't have it, install SQL Server Express
- Create the database CouchbaseTest.
- Run the following script: 
  USE [CouchbaseTest]
  GO
  
  /****** Object:  Table [dbo].[TestTable]    Script Date: 28/06/2014 14:07:30 ******/
  SET ANSI_NULLS ON
  GO
  
  SET QUOTED_IDENTIFIER ON
  GO
  
  CREATE TABLE [dbo].[TestTable](
  	[Id] [int] IDENTITY(1,1) NOT NULL,
  	[Description] [nvarchar](50) NOT NULL,
   CONSTRAINT [PK_TestTable] PRIMARY KEY CLUSTERED 
  (
  	[Id] ASC
  )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
  ) ON [PRIMARY]
  
  GO

  Insert into TestTable (description) values('test')
  
- Change the database connection string in ProgOne, ProgTwo and ProgThree App.config.
- Right click on the solution -> Properties -> Common Properties -> Startup Project -> Multiple startup projects and choose to start ProgOne, ProgTwo and ProgThree
- Enjoy.

Note:

The application uses the "Default" Couchbase bucket.
Three different applications will share the same DataAccess. Each application has its own SessionFactory.
Each application will interact with the same second level cache.
When an update occurs, the first application which read the new data will update the cache.


