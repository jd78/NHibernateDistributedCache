NHibernateDistributedCache
==========================


The project is a distributed cache example using all the power of NHibernate to manage the Second Level Cache.
I'm using Couchbase as distributed cache provider, my favourite NO-SQL DB.

In order to run the project you need:

- Visual Studio 2012+
- Install Couchbase (http://www.couchbase.com/)
- If you don't have it, install SQL Server Express
- Create the database CouchbaseTest.
- Run the Sql script "CreateDb" located in the root of the project
- Change the database connection string in ProgOne, ProgTwo and ProgThree App.config.
- Right click on the solution -> Properties -> Common Properties -> Startup Project -> Multiple startup projects and choose to start ProgOne, ProgTwo and ProgThree
- Enjoy.

Note:

The application uses the "Default" Couchbase bucket.
Three different applications will share the same DataAccess. Each application has its own SessionFactory.
Each application will interact with the same second level cache.
When an update occurs, the first application which read the new data will update the cache.


