using AbpFilter.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpFilter.Permissions;

public class AbpFilterPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AbpFilterPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AbpFilterPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpFilterResource>(name);
    }
}
