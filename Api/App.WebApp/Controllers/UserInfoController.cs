using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using App.Core;
using App.Core.Dto;
using App.Tools;
using App.Core.Data;
using App.Service.Interface;

namespace Appapp.Controllers
{
    /// <summary>
    /// 测试接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly ILogger<UserInfoController> logger;
        private ISystemUserService systemUserService;
        private readonly IMapper _mapper;

        public UserInfoController(ISystemUserService _systemUserService, ILogger<UserInfoController> _logger,IMapper mapper)
        {
            this.systemUserService = _systemUserService;

            this.logger = _logger;

            this._mapper = mapper;
        }
        /// <summary>
        /// 得到当前用户的总数
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<int> Get()
        {
            return systemUserService.GetAllUser().Count;
        }

        //GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<SysUserInfoDto> Get(int id)
        {
            SysUserInfoDto dto = new SysUserInfoDto();
            dto.UserID = Guid.NewGuid().ToString();
            dto.UserName = "YY";
            return Ok(dto);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] SysUserInfo model)
        {
            model.Id = Guid.NewGuid().ToString();
            model.UserName = "zhangsan";
            model.ReallyName = "张三";
            model.DepartmentID = "11223";
            model.CreateTime = DateTime.Now;
            model.UpdateTime = null;
            model.Password = Md5Helper.Md5("000000");
            systemUserService.AddUser(model);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SysUserInfo model)
        {
            systemUserService.UpdateUserInfo(model);
        }

        // DELETE api/values/5
        [HttpDelete("{id},{name}")]
        public void Delete(string id)
        {
            systemUserService.DelUser(id);
        }
    }
}
