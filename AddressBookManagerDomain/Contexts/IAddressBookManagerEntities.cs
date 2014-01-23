using System;
using System.Data.Entity.Infrastructure;
namespace AddressBookManagerDomain.Contexts
{
    public interface IAddressBookManagerEntities : IDisposable
    {
        System.Data.Entity.DbSet<email_address> email_address { get; set; }
        System.Data.Entity.DbSet<mail_template> mail_template { get; set; }
        System.Data.Entity.DbSet<normal_user> normal_user { get; set; }
        System.Data.Entity.DbSet<occupation> occupations { get; set; }
        System.Data.Entity.DbSet<v_user> v_user { get; set; }
        int SaveChanges();
        DbEntityEntry Entry(Object entity);
    }
}
