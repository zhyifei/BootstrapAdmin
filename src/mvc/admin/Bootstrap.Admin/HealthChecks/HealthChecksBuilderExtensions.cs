﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the LGPL License, Version 3.0. See License.txt in the project root for license information.
// Website: https://admin.blazor.zone

using Bootstrap.Admin.HealthChecks;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 健康检查扩展类
    /// </summary>
    public static class HealthChecksBuilderExtensions
    {
        /// <summary>
        /// 添加 BootstrapAdmin 健康检查
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAdminHealthChecks(this IServiceCollection services)
        {
            var builder = services.AddHealthChecks();
            builder.AddCheck<DBHealthCheck>("db");
            builder.AddBootstrapAdminHealthChecks();

            var config = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            var checkGitee = config.GetValue("GiteeHealthChecks", false);
            if (checkGitee) builder.AddCheck<GiteeHttpHealthCheck>("Gitee");
            return services;
        }
    }
}
