﻿using Infrastructure.CommandEventsHandler;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models.CommandModels.User
{
    /// <summary>
    /// 作者：(YJY)
    /// 时间：2021/5/20 17:39:41
    /// 版本：V1.0.1  
    /// 说明：
    /// </summary>
    public abstract class UserCommandModel : Command
    {
        /// <summary>
        /// 用户唯一标识
        /// </summary>
        public Guid UserId { get; protected set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName { get; protected set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; protected set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; protected set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; protected set; }

        public string CreateName { get; protected set; }

       
    }
}
