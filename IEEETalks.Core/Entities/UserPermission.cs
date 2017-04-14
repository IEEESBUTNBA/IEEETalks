using IEEETalks.Core.Enums;
using System.Collections.Generic;

namespace IEEETalks.Core.Entities
{
    public class UserPermission
    {
        public int EntityId { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}