## SingleValueCategory namespace

This namespace helps you to create a single-value category in i-doit by using the method `Create` as well as
updating it with the method `Update`, quick purging with the method `Purge` and reading with the method `Read`  

## Code examples

### Create and read

```cs
using Idoit.API.Client;
using Idoit.API.Client.CMDB.Category;
using Idoit.API.Client.CMDB.Object;
using Idoit.API.Client.Contants;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var objectRequest = new IdoitObjectInstance(idoitClient);
            var categoryRequest = new LocationRequest();
            //This is a generic class which can be used for all objects which implemented ISingleValueResponse
            var Location = new IdoitSvcInstance<LocationResponse>(idoitClient);

            //Create the Object
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectRequest.Type = IdoitObjectTypes.CLIENT;
            objectRequest.Value = "My IdoitClient";
            var objectId = objectRequest.Create();

            //Create the Category
            categoryRequest.latitude = "12";
            categoryRequest.longitude = "323";
            categoryRequest.snmp_syslocation = "23";
            categoryRequest.description = "Web GUI description";
            Location.ObjectId = objectId;
            Location.ObjectRequest = categoryRequest;
            var cateId = Location.Create();
            Console.WriteLine("You have created a category with the id  '" + cateId + "'");
            
            //Read the category
            var result = Location.Read();
            foreach (var v in result)
            {
                Console.WriteLine(v.description);
            }
        }
    }
}
```

### Quickpurge

```cs
using Idoit.API.Client;
using Idoit.API.Client.CMDB.Category;
using Idoit.API.Client.CMDB.Object;
using Idoit.API.Client.Contants;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var objectRequest = new IdoitObjectInstance(idoitClient);
            var categoryRequest = new LocationRequest();
            var Location = new IdoitSvcInstance<LocationResponse>(idoitClient);

            //Create the Object
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectRequest.Type = IdoitObjectTypes.CLIENT;
            objectRequest.Value = "My IdoitClient";
            var objectId = objectRequest.Create();

            //Create the Category
            categoryRequest.latitude = "12";
            categoryRequest.longitude = "323";
            categoryRequest.snmp_syslocation = "23";
            categoryRequest.description = "Web GUI description";
            Location.ObjectId = objectId;
            Location.ObjectRequest = categoryRequest;
            var cateId = Location.Create();

            //Purge the category
            Location.EntryId = cateId;
            Location.Purge();
        }
    }
}
```

### Update

```cs
using Idoit.API.Client;
using Idoit.API.Client.CMDB.Category;
using Idoit.API.Client.CMDB.Object;
using Idoit.API.Client.Contants;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var objectRequest = new IdoitObjectInstance(idoitClient);
            var categoryRequest = new LocationRequest();
            var Location = new IdoitSvcInstance<LocationResponse>(idoitClient);

            //Act:Create the Object
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectRequest.Type = IdoitObjectTypes.CLIENT;
            objectRequest.Value = "My IdoitClient";
            var objectId = objectRequest.Create();

            //Act: Create the Category
            categoryRequest.latitude = "12";
            categoryRequest.longitude = "323";
            categoryRequest.snmp_syslocation = "23";
            categoryRequest.description = "Web GUI description";

            Location.ObjectId = objectId;
            Location.ObjectRequest = categoryRequest;
            var cateId = Location.Create();

            //Act: Update the Category
            categoryRequest.latitude = "122";
            categoryRequest.longitude = "423";
            categoryRequest.snmp_syslocation = "23";
            categoryRequest.description = "Web GUI 2 description";
            Location.ObjectRequest = categoryRequest;
            Location.Update();
        }
    }
}
```
