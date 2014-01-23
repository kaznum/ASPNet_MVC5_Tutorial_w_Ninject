using System;
namespace AddressBookManagerDomain.Repositories
{
    public interface IEmailAddressRepository
    {
        AddressBookManagerDomain.Contexts.email_address Find(string logonID, int generation);
    }
}
