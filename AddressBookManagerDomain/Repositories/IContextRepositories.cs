﻿using AddressBookManagerDomain.Contexts;
using System;
namespace AddressBookManagerDomain.Repositories
{
    public interface IContextRepositories : IDisposable
    {
        IEmailAddressRepository EmailAddressRepository { get; }
        INormalUserRepository NormalUserRepository { get; }
        void Save();
        IAddressBookManagerEntities Context { get; }
    }
}
