using AddressBookManagerDomain.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookManagerDomain.Repositories
{
    public class NormalUserRepository : AbstractRepository, INormalUserRepository
    {
        public NormalUserRepository(IAddressBookManagerEntities db)
        {
            this.db = db;
        }

        public normal_user Find(int userID, int generation)
        {
            return db.normal_user.Where(nu => nu.user_id == userID && nu.generation == generation).FirstOrDefault();
        }

        public IEnumerable<normal_user> All()
        {
            return db.normal_user;
        }
    }
}
