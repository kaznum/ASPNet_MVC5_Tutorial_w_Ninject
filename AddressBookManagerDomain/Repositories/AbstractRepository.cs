using AddressBookManagerDomain.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookManagerDomain.Repositories
{
    public abstract class AbstractRepository
    {
        protected IAddressBookManagerEntities db;
    }
}
