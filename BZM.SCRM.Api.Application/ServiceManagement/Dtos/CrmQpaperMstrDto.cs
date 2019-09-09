using SCRM.Domain.ServiceManagement.Entitys;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCRM.Application.ServiceManagement.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CrmQpaperMstrDto
    {
        /// <summary>
        /// 套卷题目
        /// </summary>
        [Display(Name = "套卷题目")]
        public List<CrmQpaperQuDto> QuList { get; set; }
    }
}