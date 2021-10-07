using System.Collections.Generic;
using ServiceStack;
using TestServer.ServiceModel.Types;

namespace TestServer.ServiceModel
{
    [Route("/addresses")]
    public class GetAddressList : IReturn<GetAddressListResponse>
    {
    }

    public class GetAddressListResponse
    {
        public List<Address> Addresses { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }

}
