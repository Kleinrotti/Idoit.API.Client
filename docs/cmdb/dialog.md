# CMDB.dialog namespace

This namespace helps you to set new values in the dialog fields by using the method `Create` as well as
updating them with the method `Update`, deleting with the method `Delete` and reading with the method `Read`  

## Code examples

### Create

```cs
using Idoit.API.Client;
using Idoit.API.Client.Contants;
using Idoit.API.Client.CMDB.Dialog;

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
            var request = new IdoitDialogInstance(idoitClient);
            request.Value = "Athlon XP";
            request.Category = IdoitCategory.CPU;
            request.Property = Cpu.Type;
            var objID = request.Create();
            Console.WriteLine("The Id is" + "'" + Id + "'");
        }
    }
}
```

### Update

```cs
using Idoit.API.Client;
using Idoit.API.Client.CMDB.Dialog;
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
            var request = new IdoitDialogInstance(idoitClient);
            //Create some object
            request.Value = "WLAN23";
            request.Category = IdoitCategory.PORT;
            request.Property = Port.PortType;
            var objID = request.Create();
            //Update the object
            request.EntryId = objID; //set entryId with the id you got e.g. from the newly created object
            request.Value = "WLAN32";
            request.Update();
            var result = request.Read();
            foreach (var v in result)
            {
                Console.WriteLine("The Id is" + "'" + result.id + "'");
                Console.WriteLine("The new title is" + "'" + result.title + "'");
            }
        }
    }
}

```

### Delete

```cs
using Idoit.API.Client;
using Idoit.API.Client.CMDB.Dialog;
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
            var request = new IdoitDialogInstance(idoitClient);
            request.Value = "Athlon XP";
            request.Category = IdoitCategory.CPU;
            request.Property = Cpu.Type;
            var objID = request.Create();

            //Delete the Value
            request.EntryId = objID; //set entryId with the id you got e.g. from the newly created object
            request.Delete();
        }
    }
}
```

### Read

```cs
using Idoit.API.Client;
using Idoit.API.Client.CMDB.Dialog;
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
            var request = new IdoitDialogInstance(idoitClient);
            //Act:Read
            request.Category = IdoitCategory.GLOBAL;
            request.Property = Global.Category;
            var result = request.Read();
            foreach (var v in result)
            {
                Console.WriteLine("The Id is" + "'" + result.id + "'");
                Console.WriteLine("The title is" + "'" + result.title + "'");
            }
        }
    }
}
```
