using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace BZM.SCRM.Domain.Common.Redis
{
    /// <summary>
    /// redis
    /// </summary>
    public class RedisHelper
    {
        /// <summary>
        /// 建立redis连接
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public  RedisClient GetRedisClient(int db)
        {
            var pwd = "twArSv1CuKH9Qd2atn17FGkE9Uh7eyLUujivl7Ji8gOAmOF5K7CoApUQ4Hc2Hu56";
            return new RedisClient("118.31.228.108", 7018, pwd, db);

        }
    }
}
