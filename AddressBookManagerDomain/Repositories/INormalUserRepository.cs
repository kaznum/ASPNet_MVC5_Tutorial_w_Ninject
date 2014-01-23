using AddressBookManagerDomain.Contexts;
using System;
using System.Collections.Generic;
namespace AddressBookManagerDomain.Repositories
{
    public interface INormalUserRepository : IDisposable
    {
        normal_user Find(int userID, int generation);
        IEnumerable<normal_user> All();
    }
}
