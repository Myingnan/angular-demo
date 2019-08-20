﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using App.Core;
using App.Tools;
using App.Core.Data;
using App.Service.Interface;
using App.WebApp.Startup;

namespace App.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogInController : ControllerBase
    {
        private JwtSettings _jwtSettings;
        private readonly ILogger<LogInController> logger;
        private ISystemUserService systemUserService;

        public LogInController(JwtSettings _jwtSettingsAccesser, ISystemUserService _systemUserService, ILogger<LogInController> _logger)
        {
            _jwtSettings=_jwtSettingsAccesser;
            this.systemUserService = _systemUserService;
            this.logger = _logger;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]SysUserInfo model) {
            RespondResult result = new RespondResult();
            model.UserName = "zhangsan";
            SysUserInfo userInfo = systemUserService.GetLoginUserInfo(model.UserName);
            //用户不存在
            if (userInfo == null)
            {
                result.is_success = false;
                result.msg = "用户不存在";
                result.result = null;
            }

            //判断密码
            string md5Password = Md5Helper.Md5(model.Password);
            //密码错误
            if (!userInfo.Password.Equals(md5Password))
            {
                result.is_success = false;
                result.msg = "密码错误";
                result.result = null;
            }
            var tokenStr = AuthConfiguer.GetJWT(model, _jwtSettings);

            result.is_success = true;
            result.msg = "";
            result.result = tokenStr;
            return Ok(result);
        }


    }
}