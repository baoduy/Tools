using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsAuthorizationManager.Entities;

namespace WindowsAuthorizationManager.Common
{
    public static class AzManHelper
    {
        //public static IEnumerable<UserEntity> GetUserInfo(this AzManService azMan, string application)
        //{
        //    foreach (var user in azMan.GetAllUsers(application))
        //    {
        //        var userInfo = new UserEntity()
        //        {
        //            UserName = user,
        //            Roles = azMan.GetRolesForUser(application, user),
        //            Groups = azMan.GetScopesForUser(application, user),
        //        };

        //        yield return userInfo;
        //    }
        //}
    }
}
