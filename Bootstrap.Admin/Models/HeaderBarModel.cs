﻿using Bootstrap.Security;
using System.Security.Principal;

namespace Bootstrap.Admin.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class HeaderBarModel : ModelBase
    {
        public HeaderBarModel(IIdentity identity)
        {
            var user = BootstrapUser.RetrieveUserByUserName(identity.Name);
            Icon = user.Icon;
            DisplayName = user.DisplayName;
            UserName = user.UserName;
            if (!string.IsNullOrEmpty(user.Css)) Theme = user.Css;
        }
        public string UserName { get; }
        /// <summary>
        /// 
        /// </summary>
        public string DisplayName { get; }
        /// <summary>
        /// 获得/设置 用户头像地址
        /// </summary>
        public string Icon { get; }
    }
}