using System;
namespace AddressBookManagerDomain.Repositories
{
    public interface INormalUserRepository
    {
        AddressBookManagerDomain.Contexts.normal_user Find(int userID, int generation);
    }
}
