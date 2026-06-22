using System.Collections.Generic;
using AqualLifeStyle.Roles.Dto;

namespace AqualLifeStyle.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}