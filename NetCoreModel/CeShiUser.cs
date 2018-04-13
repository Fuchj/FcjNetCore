using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NetCoreModel
{
  public  class CeShiUser
    {
        /// <summary>
        /// 用户编号
        /// </summary>       
        public int id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Required(ErrorMessage = "用户名称不能为空")]
        [MaxLength(6, ErrorMessage = "用户名称不能超过6个字符")]
        public string name { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string pwd { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        [Display(Name = "年龄")]
        [Range(1, 100, ErrorMessage = "年龄必须介于1到100")]
        public int age { get; set; }
        /// <summary>
        /// 月薪
        /// </summary>
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "月薪需保留两位有效小数")]//保留两位小数
        public double salary { get; set; }
        /// <summary>
        /// 部门编号
        /// </summary>
        public int deptID { get; set; } = 1;
        /// <summary>   
        /// 部门名称
        /// </summary>
        public string DapName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        [DataType(DataType.Date, ErrorMessage = "创建时间不是时间类型")]
        public DateTime createtime { get; set; }
    }
}
