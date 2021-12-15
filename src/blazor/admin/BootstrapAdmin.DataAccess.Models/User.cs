﻿using System.ComponentModel;

namespace BootstrapAdmin.DataAccess.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class User
    {
        /// <summary>
        /// 获得/设置 系统登录用户名
        /// </summary>
        public string UserName { get; set; } = "";

        /// <summary>
        /// 获得/设置 用户显示名称
        /// </summary>
        public string DisplayName { get; set; } = "";

        /// <summary>
        /// 获得/设置 用户头像图标路径
        /// </summary>
        public string Icon { get; set; } = "";

        /// <summary>
        /// 获得/设置 用户设置样式表名称
        /// </summary>
        public string Css { get; set; } = "";

        /// <summary>
        /// 获得/设置 用户默认登陆 App 标识
        /// </summary>
        public string App { get; set; } = "";

        /// <summary>
        /// 获得/设置 用户主键ID
        /// </summary>
        public string? Id { get; set; }

        /// <summary>
        /// 获取/设置 密码
        /// </summary>
        [DisplayName("登录密码")]
        public string Password { get; set; } = "";

        /// <summary>
        /// 获取/设置 密码盐
        /// </summary>
        public string PassSalt { get; set; } = "";

        /// <summary>
        /// 获取/设置 角色用户关联状态 checked 标示已经关联 '' 标示未关联
        /// </summary>
        public string Checked { get; set; } = "";

        /// <summary>
        /// 获得/设置 用户注册时间
        /// </summary>
        [DisplayName("注册时间")]
        public DateTime RegisterTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 获得/设置 用户被批复时间
        /// </summary>
        [DisplayName("授权时间")]
        public DateTime? ApprovedTime { get; set; }

        /// <summary>
        /// 获得/设置 用户批复人
        /// </summary>
        [DisplayName("授权人")]
        public string? ApprovedBy { get; set; }

        /// <summary>
        /// 获得/设置 用户的申请理由
        /// </summary>
        [DisplayName("说明")]
        public string Description { get; set; } = "";

        /// <summary>
        /// 获得/设置 用户当前状态 0 表示管理员注册用户 1 表示用户注册 2 表示更改密码 3 表示更改个人皮肤 4 表示更改显示名称 5 批复新用户注册操作
        /// </summary>
        public UserStates UserStatus { get; set; }

        /// <summary>
        /// 获得/设置 通知描述 2分钟内为刚刚
        /// </summary>
        public string? Period { get; set; }

        /// <summary>
        /// 获得/设置 新密码
        /// </summary>
        [DisplayName("确认密码")]
        public string NewPassword { get; set; } = "";

        /// <summary>
        /// 获得/设置 是否重置密码
        /// </summary>
        public int IsReset { get; set; }

        /// <summary>
        /// 获得/设置 默认格式为 UserName (DisplayName)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} ({1})", UserName, DisplayName);
        }
    }

    /// <summary>
    /// 用户状态枚举类型
    /// </summary>
    public enum UserStates
    {
        /// <summary>
        /// 更改密码
        /// </summary>
        ChangePassword,
        /// <summary>
        /// 更改样式
        /// </summary>
        ChangeTheme,
        /// <summary>
        /// 更改显示名称
        /// </summary>
        ChangeDisplayName,
        /// <summary>
        /// 审批用户
        /// </summary>
        ApproveUser,
        /// <summary>
        /// 拒绝用户
        /// </summary>
        RejectUser,
        /// <summary>
        /// 保存默认应用
        /// </summary>
        SaveApp
    }
}