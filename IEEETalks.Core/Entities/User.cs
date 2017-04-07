using IEEETalks.Core.Enums;
using System.Collections.Generic;

namespace IEEETalks.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public string IdentityNumber { get; set; }
        //public MemberType MemberType { get; set; }
        public int MemberNumer { get; set; }
        public string ShortBiography { get; set; }
        public UserState State { get; set; }
        public string Country { get; set; }
        public string University { get; set; }
        public string DegreeName { get; set; }
        public bool IsGraduated { get; set; }
        public List<UserPermission> EnabledEntities { get; set; }
    }
}
