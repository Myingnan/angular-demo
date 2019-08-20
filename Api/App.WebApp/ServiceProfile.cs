using AutoMapper;
using App.Core.Dto;
using App.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Appapp.Controllers.UserInfoController;

namespace App.WebApp
{
    public class ServiceProfile: Profile
    {
        public ServiceProfile()
        {
            CreateMap<SysUserInfo, SysUserInfoDto>();
            CreateMap<SysUserInfoDto, SysUserInfo>().ForMember(d => d.Id, u => u.MapFrom(s => s.UserID));

        }
    }
}
