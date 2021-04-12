# Idoit.API.Client

Make your i-doit API calls in C#

## Project Details

The `Idoit.API.Client` is going to make your work faster and more efficient, especially in the work relating to Visual studio.
You will be able to open a user session, which will help you to save resources on the server side and will 
additionally allow to perform more calls in a shorter time frame. 

By using the request and response HTTP headers, the `Idoit.API.Client` will help you to search for objects and 
furthermore to get the current version of i-doit.

Relating to objects, this library will help you to search for them as well as
`create`, `delete`, `archive`, `purge`, `update` and `read` objects and `read` object types.

In addition you will be able to `create`, `delete`, `archive`, `purge`, `update` and `read` 
multi-value categories and single-value categories.

## Requirements 

The following requirements are necessary before installing or using the `Idoit.API.Client`.

- A running instance of [i-doit](https://www.i-doit.com/en/i-doit/trial-version/) pro or open, version 1.15 or higher
- i-doit [API add-on](https://www.i-doit.com/en/i-doit/add-ons/api-add-on/), version 1.11.0 or higher
- Windows 10
- Visual Studio 2017 version 15.9 or higher
- .Net 5 or higher

## Available types and methods
| Namespace                      | Remote Procedure Call (RPC)           | Class in API Client Library           | Method                                               |
| ------------------------------ | ------------------------------------- | ------------------------------------- | ---------------------------------------------------- |
|`Idoit.API.Client`              | `idoit.login`                         | `IdoitClient`                         | `Login()`                                            |
|                                | `idoit.logout`                        |                                       | `Logout()`                                           |
|`Idoit.API.Client.Idoit`        | `idoit.constants`                     | `IdoitConstantsInstance`              | `ReadGlobalCategories()`, `ReadSpecificCategories()` |
|                                |                                       |                                       | `ReadObjectTypes()`, `ReadRecordStates()`            |
|                                |                                       |                                       | `ReadRelationTypes()`, `ReadStaticObjects()`         |
|                                | `idoit.search`                        | `IdoitInstance`                       | `Search()`                                           |
|                                | `idoit.version`                       |                                       | `Version()`                                          |
|`Idoit.API.Client.CMDB.Object`  | `cmdb.object.create`                  | `IdoitObjectInstance`                 | `Create()`                                           |
|                                | `cmdb.object.read`                    |                                       | `Read()`                                             |
|                                | `cmdb.object.update`                  |                                       | `Update()`                                           |
|                                | `cmdb.object.archive`                 |                                       | `Archive()`                                          |
|                                | `cmdb.object.delete`                  |                                       | `Delete()`                                           |
|                                | `cmdb.object.purge`                   |                                       | `Purge()`                                            |
|`Idoit.API.Client.CMDB.Objects` | `cmdb.objects.read`                   | `IdoitObjectsInstance`                | `Read()`                                             |
|`Idoit.API.Client.CMDB.Category`| `cmdb.category.delete`                | `IdoitMvcInstance`                    | `Delete()`                                           |
|                                | `cmdb.category.read`                  | `IdoitMvcInstance`, `IdoitSvcInstance`| `Read()`                                             |
|                                | `cmdb.category.update`                |                                       | `Update()`                                           |
|                                | `cmdb.category.archive`               |                                       | `Archive()`                                          |
|                                | `cmdb.category.create`                |                                       | `Create()`                                           |
|                                | `cmdb.category.purge`                 |                                       | `Purge()`                                            |
| `Idoit.API.Client.CMDB.Dialog` | `cmdb.dialog.create`                  | `IdoitDialogInstance`                 | `Create()`                                           |
|                                | `cmdb.dialog.read`                    |                                       | `Read()`                                             |
|                                | `cmdb.dialog.delete`                  |                                       | `Delete()`                                           |
|                                | `cmdb.dialog.update`                  |                                       | `Update()`                                           |

## A simple example

```cs
using Idoit.API.Client.Idoit;
using Idoit.API.Client;
using Idoit.API.Client.Idoit.Response;

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
            var login = idoitClient.Login(); //Not needed, but usefull if you wan't to keep a session open instead of using new ones
            var idoit = new IdoitInstance(idoitClient);
            var idoitVersion = idoit.Version();
            Console.WriteLine("The  currently i-doit version is: " + "'"+ idoitVersion.version +"'");
            Console.WriteLine("The currently i-doit type is: " + "'" + idoitVersion.type + "'" );
            Console.WriteLine("Your userId is: " + "'" + idoitVersion.Login.userId + "'" );
            Console.WriteLine("The name is: " + "'" + idoitVersion.Login.name + "'" );
            Console.WriteLine("The username is: " + "'" + idoitVersion.Login.userName + "'" );
            Console.WriteLine("The mandator is: " + "'" + idoitVersion.Login.mandator + "'" );
            var logout = idoitClient.Logout();
        }
    }
}
```
## Documentation
 
 If you want to see more examples, click on the following links

- Under [idoit](docs/idoit.md) you can search for objects, 
  it is possible to login or logout and it shows you the currently version of  your i-doit.

- Under [cmdb](docs/cmdb/README.md) you can easily work with the objects, object types, categories and
  dialog fields.


## License
Forked from https://github.com/OKT90/Idoit.API.Client

[MIT license](LICENSE)
