﻿using Bootstrap.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Bootstrap.Admin.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    public class NewController : Controller
    {
        /// <summary>
        /// 通知管理页面获得所有新用户方法调用
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<object> Get()
        {
            return UserHelper.RetrieveNewUsers().Select(user => new
            {
                user.Id,
                user.UserName,
                user.DisplayName,
                user.Description,
                user.RegisterTime
            });
        }
        /// <summary>
        /// 登录页面注册新用户提交按钮调用
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public bool Post([FromBody] User user)
        {
            var ret = UserHelper.SaveUser(user);
            if (ret) NotificationHelper.PushMessage(new MessageBody() { Category = "Users", Message = string.Format("{0}-{1}", user.UserName, user.Description) });
            return ret;
        }
        /// <summary>
        /// 新用户授权/拒绝接口
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public bool Put([FromBody]User value)
        {
            var ret = false;
            if (value.UserStatus == UserStates.ApproveUser)
            {
                ret = UserHelper.ApproveUser(value.Id, User.Identity.Name);
            }
            else if (value.UserStatus == UserStates.RejectUser)
            {
                ret = UserHelper.RejectUser(value.Id, User.Identity.Name);
            }
            return ret;
        }
    }
}