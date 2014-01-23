using AddressBookManagerDomain.Contexts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookManagerDomain.Repositories
{
    public abstract class AbstractRepository : IDisposable
    {
        protected IAddressBookManagerEntities db;

        public void Dispose()
        {
            Debug.WriteLine("AbstractRepository#Dispose is called");
        }
    }

}
