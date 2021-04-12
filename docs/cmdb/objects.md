## CMDB.Objects namespace

This namespace helps you to read objects from i-doit by using the method `Read`.

```cs
using Idoit.API.Client;
using Idoit.API.Client.CMDB;
using Idoit.API.Client.CMDB.Objects;
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
            var request = new IdoitObjectsInstance(idoitClient);
            var filter = new IdoitObjectsFilter();

            //Apply some filter if needed
            filter.type = IdoitObjectTypes.SERVICE;
            filter.title = "SystemService";
            request.Filter = filter;
            request.OrderBy = IdoitOrderBy.Title; //optional
            request.Sort = IdoitSort.Acsending; //optional
            request.Limit = "0,10"; //optional
            var result = request.Read();

            foreach (var v in result)
            {
                Console.WriteLine(v.title);
                Console.WriteLine(v.id);
            }
        }
    }
}
```
