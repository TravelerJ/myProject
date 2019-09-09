using Spring.Datas.Sql.Queries.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Infrastructure
{
   public class OracleBuilder: SqlBuilderBase
    {
        protected override string GetParamPrefix()
        {
            return ":";
        }
        /// <summary>
        /// 获取Sql
        /// </summary>
        protected override string GetSql(StringBuilder result)
        {
            if (Pager == null)
                CreateNoPagerSql(result);
            else
                CreatePagerSql(result);
            return result.ToString();
        }

        /// <summary>
        /// 创建不分页Sql
        /// </summary>
        private void CreateNoPagerSql(StringBuilder result)
        {
            result.Append(GetSelect());
            AppendSqlBody(result);
            result.Append(GetOrderBy());
        }

        /// <summary>
        /// 添加Sql共享子句
        /// </summary>
        protected void AppendSqlBody(StringBuilder result)
        {
            result.Append(GetFrom());
            result.Append(GetWhere());
            result.Append(GetGroupBy());
        }

        /// <summary>
        /// 创建分页Sql
        /// </summary>
        protected virtual void CreatePagerSql(StringBuilder result)
        {
            result.Append(GetSelect());
            AppendSqlBody(result);
            result.Append(GetOrderBy());
            result.Insert(0, "select * from(select tt.*,rownum rn from (");
            var start = (Pager.Page - 1) * Pager.PageSize;
            var end = Pager.Page * Pager.PageSize + 1;
            result.Insert(result.Length, ") tt where rownum < " + end + ") where rn>" + start + "");
            //result.AppendFormat("limit {0} , {1}", Pager.GetStartNumber() - 1, Pager.PageSize);
        }
    }
}
