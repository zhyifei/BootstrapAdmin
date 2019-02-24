﻿using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bootstrap.DataAccess.MongoDB
{
    public class App : DataAccess.App
    {
        /// <summary>
        /// 根据角色ID指派部门
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public override IEnumerable<DataAccess.App> RetrievesByRoleId(string roleId)
        {
            var apps = DictHelper.RetrieveApps().Where(d => d.Key.CompareTo("0") > 0).Select(d => new DataAccess.App()
            {
                Id = d.Key,
                AppName = d.Value
            }).ToList();
            var role = RoleHelper.Retrieves().Cast<Role>().FirstOrDefault(r => r.Id == roleId);
            apps.ForEach(p => p.Checked = (role != null && (role.Apps.Contains(p.Id)) || role.RoleName.Equals("Administrators", StringComparison.OrdinalIgnoreCase)) ? "checked" : "");
            return apps;
        }

        /// <summary>
        /// 根据角色ID以及选定的App ID，保到角色应用表
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="appIds"></param>
        /// <returns></returns>
        public override bool SaveByRoleId(string roleId, IEnumerable<string> appIds)
        {
            var ret = DbManager.Roles.UpdateOne(md => md.Id == roleId, Builders<Role>.Update.Set(md => md.Apps, appIds));
            return true;
        }
    }
}
