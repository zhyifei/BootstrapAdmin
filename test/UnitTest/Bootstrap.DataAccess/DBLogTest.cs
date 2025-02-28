﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the LGPL License, Version 3.0. See License.txt in the project root for license information.
// Website: https://admin.blazor.zone

using System;
using Xunit;

namespace Bootstrap.DataAccess
{
    [Collection("Login")]
    public class DBLogTest
    {
        [Fact]
        public virtual void Save_Ok()
        {
            var log = new DBLog()
            {
                Id = "",
                LogTime = DateTime.Now,
                SQL = "UnitTest",
                UserName = "UniTest"
            };
            Assert.True(log.Save(log));
        }

        [Fact]
        public void Save_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new DBLog().Save(null));
        }
    }
}
