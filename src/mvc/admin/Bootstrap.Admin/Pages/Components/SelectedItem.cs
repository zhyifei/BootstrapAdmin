﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the LGPL License, Version 3.0. See License.txt in the project root for license information.
// Website: https://admin.blazor.zone

namespace Bootstrap.Admin.Pages.Components
{
    /// <summary>
    /// 选项类
    /// </summary>
    public class SelectedItem
    {
        /// <summary>
        /// 获得/设置 显示名称
        /// </summary>
        public string Text { get; set; } = "";

        /// <summary>
        /// 获得/设置 选项值
        /// </summary>
        public string Value { get; set; } = "";

        /// <summary>
        /// 获得/设置 是否选中
        /// </summary>
        public bool Active { get; set; }
    }
}
