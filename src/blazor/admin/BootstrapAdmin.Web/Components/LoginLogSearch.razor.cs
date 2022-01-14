﻿using BootstrapAdmin.Web.Models;

namespace BootstrapAdmin.Web.Components;

public partial class LoginLogSearch
{
    /// <summary>
    /// 
    /// </summary>
    [Parameter]
    [NotNull]
    public LoginLogModel? Value { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Parameter]
    [NotNull]
    public EventCallback<LoginLogModel>? ValueChanged { get; set; }
}
