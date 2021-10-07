using System;
using System.Collections.Generic;
using TestServer.ServiceModel.Types;

namespace TestServer.ServiceInterface.Data
{
    public class AddressData
    {
        public List<Address> Addresses { get; private set; }

        public AddressData()
        {
            BuildList();
        }

        private void BuildList()
        {
            var numEntries = 10;
            Addresses = new List<Address>(numEntries);
            for (int i = 0; i < numEntries; i++)
            {
                var addr = new Address
                {
                    AddrId = Guid.NewGuid().ToString(),
                    Street = $"Paradise Hill {i+1}",
                    Zip = "PA-5435",
                    City = "Reality"
                };
                Addresses.Add(addr);
            }
        }
    }
}