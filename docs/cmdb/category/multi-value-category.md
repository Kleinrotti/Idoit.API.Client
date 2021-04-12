## MultiValueCategory namespace

This namespace helps you to create a multi-value category in i-doit by using the method `Create` as well as 
updating it with the method `Update`, deleting with the method `Delete`, quick purging with the method `Purge` and 
reading with the method `Read`  

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
            var idoitClient = new IdoitClient("URL", "APIKEY", "EN")
            {
                Username = "admin",
                Password = "admin"
            };
            var objectRequest = new IdoitObjectInstance(idoitClient);
            var categoryRequest = new AccessRequest();
            //This is a generic class which can be used for all objects which implemented IMultiValueResponse
            var access = new IdoitMvcInstance<AccessResponse>(idoitClient);

            //Create the Object
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectRequest.Type = IdoitObjectTypes.CLIENT;
            objectRequest.Value = "My Client";
            var objectId = objectRequest.Create();

            //Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.type = " ES";
            categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
            access.ObjectId = objectId; //set the id
            access.ObjectRequest = categoryRequest; //set the AccessRequest
            var cateId = access.Create();
            Console.WriteLine("You have created a category with the id  '" + cateId + "'");

            //Read the Category
            var list = access.Read();
            foreach (var v in list)
            {
                Console.WriteLine(v.title);
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
            var idoitClient = new IdoitClient("URL", "APIKEY", "EN")
            {
                Username = "admin",
                Password = "admin"
            };
            var objectRequest = new IdoitObjectInstance(idoitClient);
            var categoryRequest = new AccessRequest();
            var access = new IdoitMvcInstance<AccessResponse>(idoitClient);

            //Create the Object
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectRequest.Type = IdoitObjectTypes.CLIENT;
            objectRequest.Value = "My Client";
            var objectId = objectRequest.Create();

            //Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.type = " ES";
            categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
            access.ObjectId = objectId;
            access.ObjectRequest = categoryRequest;
            var cateId = access.Create();

            //Purge the category
            access.EntryId = cateId;
            access.Purge();
        }
    }
}
```

### Delete

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
            var idoitClient = new IdoitClient("URL", "APIKEY", "EN")
            {
                Username = "admin",
                Password = "admin"
            };
            var objectRequest = new IdoitObjectInstance(idoitClient);
            var categoryRequest = new IPRequest();
            var IP = new IdoitMvcInstance<IPResponse>(idoitClient);

            //Create the Object
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectRequest.Type = IdoitObjectTypes.CLUSTER;
            objectRequest.Value = "My Cluster 2";
            var objectId = objectRequest.Create();

            //Create the Category
            categoryRequest.ipv4_address = "1.1.1.2";
            categoryRequest.description = "Web GUI description";
            IP.ObjectId = objectId;
            IP.ObjectRequest = categoryRequest;
            var cateId = IP.Create();
            //Delete the category
            IP.EntryId = objectId;
            IP.Delete();
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
            var categoryRequest = new AccessRequest();
            var access = new IdoitMvcInstance<AccessResponse>(idoitClient);

            //Create the Object
            objectRequest.CmdbStatus = IdoitCmdbStatus.INOPERATION;
            objectRequest.Type = IdoitObjectTypes.CLIENT;
            objectRequest.Value = "My Client";
            var objectId = objectRequest.Create();

            //Create the Category
            categoryRequest.title = "Web GUI";
            categoryRequest.description = "Web GUI description";
            categoryRequest.type = " ES";
            categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
            access.ObjectId = objectId;
            access.ObjectRequest = categoryRequest;
            var cateId = access.Create();

            //Update the Category
            categoryRequest.title = "Web GUI 2";
            categoryRequest.description = "Web GUI 2 description";
            categoryRequest.type = " SE";
            categoryRequest.formatted_url = "https://swsan.admin.acme-it.example/";
            categoryRequest.category_id = cateId; //set the id
            access.ObjectRequest = categoryRequest;
            access.Update();
        }
    }
}
```
