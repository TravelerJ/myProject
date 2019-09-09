using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BZM.SCRM.Domain.Common
{
    /// <summary>
    /// 公共字段赋值
    /// </summary>
   public class InitHelper
    {
        /// <summary>
        /// 公共新增方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <param name="userId"></param>
        /// <param name="orgNo"></param>
        /// <param name="bgNo"></param>
        public void InitAdd<T>(T dto,decimal userId,string orgNo,string bgNo)
        {
            Type entity = typeof(T);
            PropertyInfo[] pc = entity.GetProperties();
            foreach (var item in pc)
            {
                if (item.Name.Equals("CREATE_DATE") || item.Name.Equals("UPDATE_DATE"))
                {
                    item.SetValue(dto, DateTime.Now, null);
                }
                if (item.Name.Equals("CREATE_PSN") || item.Name.Equals("UPDATE_PSN"))
                {
                    item.SetValue(dto, userId, null);
                }
                if (item.Name.Equals("CREATE_ORG_NO"))
                {
                    item.SetValue(dto, orgNo, null);
                }
                if (item.Name.Equals("BG_NO"))
                {
                    item.SetValue(dto, bgNo, null);
                }
                if (item.Name.Equals("BU_NO"))
                {
                    item.SetValue(dto, orgNo, null);
                }
                if (item.Name.Equals("DEL_FLAG"))
                {
                    item.SetValue(dto, (decimal)1, null);
                }

            }

        }

        /// <summary>
        /// 公共更新方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dto"></param>
        /// <param name="userId"></param>
        public void InitUpdate<T>(T dto, decimal userId)
        {
            Type entity = typeof(T);
            PropertyInfo[] pc = entity.GetProperties();
            foreach (var item in pc)
            {
                if (item.Name.Equals("UPDATE_DATE"))
                {
                    item.SetValue(dto, DateTime.Now, null);
                }
                if (item.Name.Equals("UPDATE_PSN"))
                {
                    item.SetValue(dto, userId, null);
                }
            }
        }


    }
}
