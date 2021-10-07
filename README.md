# TestServer
## Purpose
This simple test server was built to demonstrate a problem with serializing `Exceptions` and `ResponseStatus` objects when using ServiceStack and the 
References for Dart/Flutter. The problem was detected in a production project using .NETCore 3.1 and ServiceStack 5.2 on a Fedora 34 Workstation and RHEL docker containers.
## Infrastructure
This server was created with the following settings / infrastructure
* Mac running the latest version of BigSur.
* It was built as .NET 5.0 self-hosting Kestrel Console App
* It is using ServiceStack 5.12.1
## What is inside
This project is very primitive and has only **one** service. This service generates a list of 10 addresses and returns them as a list of objects.
## How to produce the errors
In the `AddressService.cs` file comment lines to reproduce the problems:
```c#
    public class AddressService : Service
    {
        public object Get(GetAddressList request)
        {
            var addresses = TryResolve<AddressData>();

            //throw new Exception("This is a fake EXCEPTION for testing error handling in DART");
            
            return new GetAddressListResponse()
            {
                Addresses = addresses.Addresses,
                //Status = new ResponseStatus("500", "This is a fake message for testing!"),
            };
        }

    }
```
* To run **normally without errors** leave the code as shown above. 
* To show an **empty exception** uncomment `//throw new Exception("This is a fake EXCEPTION for testing error handling in DART");`
to throw an exception in the *Flutter* client. You will see the exception but the text `This is a fake EXCEPTION ...` will appear nowhere.
* To show a NULL `ResponseStatus` object in the `GetAddressListResponse` object, comment the code look like
```c#
            //throw new Exception("This is a fake EXCEPTION for testing error handling in DART");
            
            return new GetAddressListResponse()
            {
                //Addresses = addresses.Addresses,
                Status = new ResponseStatus("500", "This is a fake message for testing!"),
            };
```
In the flutter project all members of the `GetAddressListResponse` object are `null`.