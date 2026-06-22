using System.Collections.Generic;
using AqualLifeStyle.Roles.Dto;

namespace AqualLifeStyle.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
