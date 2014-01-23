using AddressBookManagerDomain.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookManagerDomain.Repositories
{
    public class EmailAddressRepository : AbstractRepository, IEmailAddressRepository
    {
        public EmailAddressRepository(IAddressBookManagerEntities db)
        {
            this.db = db;
        }

        public email_address Find(string logonID, int generation)
        {
            return db.email_address.Where(e => e.logon_id == logonID && e.generation == generation).FirstOrDefault();
        }
    }
}
