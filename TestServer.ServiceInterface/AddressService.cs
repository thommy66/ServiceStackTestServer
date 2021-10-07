using System;
using System.Linq;
using ServiceStack;
using TestServer.ServiceInterface.Data;
using TestServer.ServiceModel;

namespace TestServer.ServiceInterface
{
    public class AddressService : Service
    {
        public object Get(GetAddressList request)
        {
            var addresses = TryResolve<AddressData>();

            throw new Exception("This is a fake EXCEPTION for testing error handling in DART");
            
            return new GetAddressListResponse()
            {
                //Addresses = addresses.Addresses,
                Status = new ResponseStatus("500", "This is a fake message for testing!"),
            };
        }

    }
}
