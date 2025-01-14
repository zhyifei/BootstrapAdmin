﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the LGPL License, Version 3.0. See License.txt in the project root for license information.
// Website: https://admin.blazor.zone

using System;
using Xunit;

namespace Bootstrap.DataAccess
{
    [Collection("Login")]
    public class MessagesTest
    {
        [Fact]
        public void Retrieves_Ok()
        {
            var msg = new Message()
            {
                Content = "UnitTest",
                From = "Admin",
                Label = "Test",
                IsDelete = 0,
                Flag = 0,
                Period = "1",
                SendTime = DateTime.Now,
                Status = "0",
                Title = "Test",
                To = "User",
                LabelName = "UnitTest",
                FromDisplayName = "UnitTest",
                FromIcon = "Default.jpg"
            };
            Assert.True(MessageHelper.Save(msg));
            Assert.NotEmpty(MessageHelper.Retrieves("User"));
        }
    }
}
