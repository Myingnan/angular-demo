using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel;
using App.Core.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace App.WebApp.Startup
{
    public static class AuthConfiguer
    {
        /// <summary>
        /// 配置Auth服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void Configuer(IServiceCollection services, IConfiguration configuration) {

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            var jwtSettings = new JwtSettings();
            configuration.Bind("jwtSettings", jwtSettings);

            if (jwtSettings.Isenable)
            {
                services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = jwtSettings.Issuer,
                        ValidAudience = jwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                    option.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                        //Token expired 过期参数头带 token-Expired 属性
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("Token-Expired", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };
                });
            }
        }

        /// <summary>
        /// 生成JWT字符串
        /// </summary>
        /// <param name="tokenModel"></param>
        /// <param name="jwtModel"></param>
        /// <returns></returns>
        public static string GetJWT(SysUserInfo tokenModel, JwtSettings jwtModel)
        {

            //DateTime utc = DateTime.UtcNow;
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,tokenModel.Id.ToString()),
                new Claim(ClaimTypes.Name,tokenModel.ReallyName),
            };


            // 密钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtModel.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenHandler = new JwtSecurityTokenHandler();

            var jwt = new JwtSecurityToken(
                audience: jwtModel.Audience,
                issuer:jwtModel.Issuer,
                claims: claims,// 声明的集合
                expires: DateTime.Now.AddHours(1), // token的有效时间
                signingCredentials: creds
                );
            var handler = new JwtSecurityTokenHandler();
            // 生成 jwt字符串
            var strJWT = handler.WriteToken(jwt);
            return strJWT;
        }
    }
}
