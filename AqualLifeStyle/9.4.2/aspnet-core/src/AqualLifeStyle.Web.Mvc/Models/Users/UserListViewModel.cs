using System.Collections.Generic;
using AqualLifeStyle.Roles.Dto;

namespace AqualLifeStyle.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
