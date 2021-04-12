# CMDB.object namespace

This namespace helps you to create objects in i-doit by using the method `Create` as well as updating them with the method `Update`,
deleting with the method `Delete`, archiving with the method `Archive`, quick purging with the method `Purge` and
reading with the method `Read`.


### Create Object 

```cs
using Idoit.API.Client;
using Idoit.API.Client.CMDB.Object;
using Idoit.API.Client.Contants;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var idoitClient = new IdoitClient("URL", "APIKEY", "EN")
            {
                Username = "admin",
                Password = "admin"
            };
            var result = new IdoitObjectResult();
            var request = new IdoitObjectInstance(idoitClient);
            //Create the Object
            request.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            request.Type = IdoitObjectTypes.SERVER;
            request.Value = "Server 01";
            var objID = request.Create();
            Console.WriteLine("The objectId is: " + "'" + objId + "'");
        }
    }
}
```

### Delete Object 

```cs
using Idoit.API.Client;
using Idoit.API.Client.CMDB.Object;
using Idoit.API.Client.Contants;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var idoitClient = new IdoitClient("URL", "APIKEY", "EN")
            {
                Username = "admin",
                Password = "admin"
            };
            var result = new IdoitObjectResult();
            var request = new IdoitObjectInstance(idoitClient);
            //Create the Object
            request.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            request.Type = IdoitObjectTypes.CLIENT;
            request.Value = "Client 01";
            var objID = request.Create();
            request.ObjectId = objID; //set the object id
            //Delete
            request.Delete();
            var result = request.Read();
            if (result.status == IdoitStatusTypes.Deleted)
            {
                Console.WriteLine("The object "+ "'" + request.title + "'" +  " with the objectId " + "'" 
                    + objId + "'" + " has been deleted");
            }
        }
    }
}
```
### Archive Object 

```cs
using Idoit.API.Client;
using Idoit.API.Client.CMDB.Object;
using Idoit.API.Client.Contants;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var idoitClient = new IdoitClient("URL", "APIKEY", "EN")
            {
                Username = "admin",
                Password = "admin"
            };
            var result = new IdoitObjectResult();
            var request = new IdoitObjectInstance(idoitClient);
            //Create the Object
            request.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            request.Type = IdoitObjectTypes.CITY;
            request.Value = "City 01";
            var objID = request.Create();
            request.ObjectId = objID; //set the object id
            //Archive
            request.Archive();
            var result = request.Read();
            if (result.status == IdoitStatusTypes.Archived)
            {
                Console.WriteLine("The object "+ "'" + request.title + "'" +  " with the objectId " + "'" 
                    + objId + "'" + " has been archived");
            }
        }
    }
}
```

### purge Object 

```cs
using Idoit.API.Client;
using Idoit.API.Client.CMDB.Object;
using Idoit.API.Client.Contants;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var idoitClient = new IdoitClient("URL", "APIKEY", "EN")
            {
                Username = "admin",
                Password = "admin"
            };
            var request = new IdoitObjectInstance(idoitClient);
            //Create the Object
            request.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            request.Type = IdoitObjectTypes.CITY;
            request.Value = "City 01";
            var objID = request.Create();
            request.ObjectId = objID; //set the object id
            //Purge
            request.Purge(); //purged objects are completely removed from the database!
        }
    }
}
```

### Update Object 

```cs
using Idoit.API.Client;
using Idoit.API.Client.CMDB.Object;
using Idoit.API.Client.Contants;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var idoitClient = new IdoitClient("URL", "APIKEY", "EN")
            {
                Username = "admin",
                Password = "admin"
            };
            var request = new IdoitObjectInstance(idoitClient);
            //Create the Object
            request.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            request.Type = IdoitObjectTypes.CITY;
            request.Value = "City 01";
            var objID = request.Create();
            request.ObjectId = objID; //set the object id
            request.Value = "City 02"; //change the title
            request.Update();
        }
    }
}
```

### Read Object 

```cs
using Idoit.API.Client;
using Idoit.API.Client.CMDB.Object;
using Idoit.API.Client.Contants;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var idoitClient = new IdoitClient("URL", "APIKEY", "EN")
            {
                Username = "admin",
                Password = "admin"
            };
            var request = new IdoitObjectInstance(idoitClient);
            //Create the Object
            request.CmdbStatus = IdoitCmdbStatus.PLANNED;
            request.Type = IdoitObjectTypes.SERVER;
            request.Value = "Ceph Storage";
            var objID = request.Create();
            //Read the Object
            request.ObjectId = objID;
            var result = request.Read();
            Console.WriteLine("The objectId is " + "'" + objId + "'");
            Console.WriteLine("The object title is " + "'" + result.title + "'");
            Console.WriteLine("The object type is " + "'" + result.typeTitle + "'");
            Console.WriteLine("The object CMDB-Status is " + "'" + result.cmdbStatusTitle + "'");
        }
    }
}
```
