using AddressBookManagerDomain.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookManagerDomain.Repositories
{
    public class ContextRepositories : IContextRepositories
    {
        private IAddressBookManagerEntities db;
        private bool disposed;

        private Dictionary<Type, AbstractRepository> repos;

        public ContextRepositories(IAddressBookManagerEntities db)
        {
            this.db = db;
            this.repos = new Dictionary<Type, AbstractRepository>();
            this.disposed = false;
        }

        public IAddressBookManagerEntities Context
        {
            get { return db; }
        }

        public INormalUserRepository NormalUserRepository
        {
            get
            {
                return SingletonRepository<NormalUserRepository>() as INormalUserRepository;
            }
        }

        public IEmailAddressRepository EmailAddressRepository
        {
            get
            {
                return SingletonRepository<EmailAddressRepository>() as IEmailAddressRepository;
            }
        }
        public IOccupationRepository OccupationRepository
        {
            get
            {
                return SingletonRepository<OccupationRepository>() as IOccupationRepository;
            }
        }

        private AbstractRepository SingletonRepository<T>() where T : class
        {
            if (!repos.ContainsKey(typeof(T)))
            {
                AbstractRepository repo = Activator.CreateInstance(typeof(T), db) as AbstractRepository;
                repos.Add(typeof(T), repo);
                return repo;
            }
            else
            {
                return repos[typeof(T)];
            }

        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing)
        {
            if (!this.disposed && isDisposing)
            {
                db.Dispose();
            }

            this.disposed = true;
        }
    }
}
