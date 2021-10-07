using System;
using System.Collections.Generic;
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
            // this is a forced crash to test if ResponseStatus is working with a natural created exception.
            //var addrCrash = addresses.Addresses[10];

            //throw new Exception("This is a fake EXCEPTION for testing error handling in DART");

            //The following code generates an exception in flutter:
            // "type 'Null' is not a subtype of type 'ResponseError' of 'value'"
            var rs = new ResponseStatus();
            rs.ErrorCode = "666";
            rs.Message = "This is a FAKE error message for testing";
            
            var errors = new List<ResponseError>(3);
            for (int i = 0; i < 3; i++)
            {
                var err = new ResponseError
                {
                    ErrorCode = "333",
                    Message = $"Fake error message #{i+1}",
                    FieldName = "Some field name",
                };
                errors.Add(err);
            }

            rs.Errors = errors;

            /*
            var metaTest = new Dictionary<string, string>(3);
            for (int i = 0; i < 3; i++)
            {
                metaTest.Add($"Property-{i+1}", "some text as value");
            }

            rs.Meta = metaTest;
            */
            
            return new GetAddressListResponse()
            {
                //Addresses = addresses.Addresses,
                //This is still NULL on Dart
                //ResponseStatus = new ResponseStatus("500", "This is a fake message for testing!"),
                ResponseStatus = rs,
            };
        }

    }
}
