using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.WebApp.Startup
{
    public class JwtSettings
    {
        /// <summary>
        /// token是谁颁发的
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// token可以给哪些客户使用
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// 加密的Key
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool Isenable { get; set; }
    }
}
