using System;
namespace AddressBookManagerDomain.Repositories
{
    public interface IOccupationRepository : IDisposable
    {
        System.Collections.Generic.IEnumerable<AddressBookManagerDomain.Contexts.occupation> All();
        AddressBookManagerDomain.Contexts.occupation Find(int code);
        System.Collections.Generic.Dictionary<int, string> GetOccupationCodeNames();
    }
}
