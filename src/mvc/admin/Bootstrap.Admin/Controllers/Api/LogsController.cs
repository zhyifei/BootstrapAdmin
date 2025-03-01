﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the LGPL License, Version 3.0. See License.txt in the project root for license information.
// Website: https://admin.blazor.zone

using Bootstrap.Admin.Query;
using Bootstrap.DataAccess;
using Longbow.Web;
using Longbow.Web.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Bootstrap.Admin.Controllers.Api
{
    /// <summary>
    /// 操作日志控制器
    /// </summary>
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class LogsController : ControllerBase
    {
        /// <summary>
        /// 前台获取操作日志数据调用
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpGet]
        public QueryData<Log> Get([FromQuery] QueryLogOption value)
        {
            return value.RetrieveData();
        }

        /// <summary>
        /// 操作日志记录方法
        /// </summary>
        /// <param name="ipLocator"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> Post([FromServices] IIPLocatorProvider ipLocator, [FromBody] Log value)
        {
            value.UserAgent = Request.Headers["User-Agent"];
            var agent = new UserAgent(value.UserAgent);
            value.Ip = HttpContext.Connection.RemoteIpAddress?.ToIPv4String() ?? "";
            value.Browser = $"{agent.Browser?.Name} {agent.Browser?.Version}";
            value.OS = $"{agent.OS?.Name} {agent.OS?.Version}";
            value.City = await ipLocator.Locate(value.Ip);
            value.UserName = User.Identity?.Name ?? string.Empty;
            return LogHelper.Save(value);
        }
    }
}
