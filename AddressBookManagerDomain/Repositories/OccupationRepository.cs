using AddressBookManagerDomain.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookManagerDomain.Repositories
{
    public class OccupationRepository : AbstractRepository, IOccupationRepository
    {
        public OccupationRepository(IAddressBookManagerEntities db)
        {
            this.db = db;
        }

        public occupation Find(int code)
        {
            return db.occupations.Where(o => o.code == code).FirstOrDefault();
        }

        public IEnumerable<occupation> All()
        {
            return db.occupations;
        }

        public Dictionary<int, string> GetOccupationCodeNames()
        {
            var codeNames = from o in db.occupations
                             select new { id = o.code, name = o.name };
            var dict = new Dictionary<int, string>();
            codeNames.ToList().ForEach(cn => dict.Add(cn.id, cn.name));
            return dict;
        }
    }
}
