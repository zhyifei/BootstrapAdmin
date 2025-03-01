﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the LGPL License, Version 3.0. See License.txt in the project root for license information.
// Website: https://admin.blazor.zone

using Bootstrap.DataAccess;
using Longbow.Web.Mvc;
using System;

namespace Bootstrap.Admin.Query
{
    /// <summary>
    /// Query trace options.
    /// </summary>
    public class QueryTraceOptions : PaginationOption
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime? OperateTimeStart { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? OperateTimeEnd { get; set; }

        /// <summary>
        /// 请求IP地址
        /// </summary>
        public string? AccessIP { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public QueryData<Trace> RetrieveData()
        {
            var data = TraceHelper.Retrieves(this, OperateTimeStart, OperateTimeEnd, AccessIP);

            var ret = new QueryData<Trace>();
            ret.total = data.TotalItems;
            ret.rows = data.Items;
            return ret;
        }
    }
}
