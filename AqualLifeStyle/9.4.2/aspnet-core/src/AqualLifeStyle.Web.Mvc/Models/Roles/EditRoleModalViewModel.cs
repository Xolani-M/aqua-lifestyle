using Abp.AutoMapper;
using AqualLifeStyle.Roles.Dto;
using AqualLifeStyle.Web.Models.Common;

namespace AqualLifeStyle.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
