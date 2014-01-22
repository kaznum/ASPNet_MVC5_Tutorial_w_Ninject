using AddressBookManagerDomain.Contexts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Models
{
    public class NormalUserViewModel
    {
        [Required(ErrorMessage = "メールアドレスを入力してください。")]
        [EmailAddress]
        [DisplayName("Email")]
        public string EmailAddress { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{0,5}$",ErrorMessage="世代は最大5ケタの数値を入力してください。")]
        [DisplayName("世代")]
        public int? Generation { get; set; }
        [Required]
        [DisplayName("ユーザーID")]
        public int? UserID { get; set; }
        [Required]
        [DisplayName("氏")]
        public string FamilyName { get; set; }
        [Required]
        [DisplayName("名")]
        public string GivenName { get; set; }
        [Required]
        [StringLength(7,MinimumLength=7,ErrorMessage="ログオンIDは7文字でなければなりません。")]
        [DisplayName("ログオンID")]
        public string LogonID { get; set; }
        [Range(0,150)]
        [DisplayName("年齢")]
        public int? Age { get; set; }
        [Required]
        [DisplayName("職業")]
        public int? OccupationCode { get; set; }

        public NormalUserViewModel() { }

        public NormalUserViewModel(normal_user normalUser, email_address email)
        {
            UserID = normalUser.user_id;
            LogonID = normalUser.logon_id;
            FamilyName = normalUser.family_name;
            GivenName = normalUser.given_name;
            Generation = normalUser.generation;
            Age = normalUser.age;
            OccupationCode = normalUser.occupation_code;

            if (email != null)
                EmailAddress = email.address;
        }

        public email_address GetEmailAddressEntity()
        {
            var email = new email_address();
            email.address = EmailAddress;
            email.logon_id = LogonID;
            email.generation = (int)Generation;
            return email;
        }

        public normal_user GetNormalUserEntity()
        {
            var normalUser = new normal_user();
            normalUser.user_id = (int)UserID;
            normalUser.logon_id = LogonID;
            normalUser.family_name = FamilyName;
            normalUser.given_name = GivenName;
            normalUser.generation = (int)Generation;
            normalUser.age = Age;
            normalUser.occupation_code = OccupationCode;
            return normalUser;
        }

        public Dictionary<int, string> Occupations
        { 
            get {
                var occus = new Dictionary<int, string>();
                var entities = (IAddressBookManagerEntities)DependencyResolver.Current.GetService(typeof(IAddressBookManagerEntities));
                entities.occupations.ToList().ForEach(o => occus.Add(o.code, o.name));
                return occus;
            } 
        }

        [DisplayName("職業")]
        public string OccupationName
        {
            get
            {
                if (this.OccupationCode == null)
                {
                    return null;
                }
                else
                {
                    var entities = (IAddressBookManagerEntities)DependencyResolver.Current.GetService(typeof(IAddressBookManagerEntities));
                    var occ = entities.occupations.Where(o => o.code == this.OccupationCode).First();
                    return occ.name;
                }
            }
        }
    }
}