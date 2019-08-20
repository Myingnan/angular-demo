using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core
{
   [Serializable]
   public abstract class BaseEntity<Tkey>
    {
        /// <summary>
        /// 业务主键
        /// </summary>
        public virtual Tkey Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateBy { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        public string UpdateBy { get; set; }
    }
}
