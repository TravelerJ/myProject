using Spring.Datas.Sql.Queries;
using Spring.Datas.Sql.Queries.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Infrastructure
{
    /// <summary>
    /// 创建Sql生成器
    /// </summary>
    public class OracleQuery:SqlQueryBase
    {
        /// <summary>
        /// 创建Sql生成器
        /// </summary>
        protected override ISqlBuilder CreateSqlBuilder()
        {
            return new OracleBuilder();
        }

    }
}
