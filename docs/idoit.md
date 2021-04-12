# idoit namespace 

This namespace helps you to search for objects by using the method `Search` as well as opening and closing a user session
by using `Login` and `Logout` methods.

## Code examples

### Search

```cs
using System;
using Idoit.API.Client.Idoit;

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
            var idoit = new IdoitInstance(idoitClient);
            var result = idoit.Search("Printer 1");
            foreach (var v in result)
            {
                Console.WriteLine("The Link is: " + "'" + v.link + "'");
                Console.WriteLine("The Source is: " + "'" + v.key + "'");
                Console.WriteLine("The Object name is: " + "'" + v.value + "'");
            }
        }
    }
}
```

### Login and logout

```cs
using System;
using Idoit.API.Client;

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
            var login = idoitClient.Login();
            Console.WriteLine("Logging in i-doit: " + "'" + login.result + "'");     
            Console.WriteLine("Your userId is: " + "'" + login.userId + "'");

            var logout = idoitClient.Logout();
            Console.WriteLine("logging out i-doit: " + "'" + logout.result + "'");
            Console.WriteLine("Message from i-doit, you have: " + "'" + logout.message + "'");
        }
    }
}
```