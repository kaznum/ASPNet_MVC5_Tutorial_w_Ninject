﻿//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはテンプレートから生成されました。
//
//     このファイルを手動で変更すると、アプリケーションで予期しない動作が発生する可能性があります。
//     このファイルに対する手動の変更は、コードが再生成されると上書きされます。
// </auto-generated>
//------------------------------------------------------------------------------

namespace AddressBookManagerDomain.Contexts
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AddressBookManagerEntities : DbContext
    {
        public AddressBookManagerEntities()
            : base("name=AddressBookManagerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<email_address> email_address { get; set; }
        public virtual DbSet<normal_user> normal_user { get; set; }
        public virtual DbSet<mail_template> mail_template { get; set; }
        public virtual DbSet<v_user> v_user { get; set; }
    }
}