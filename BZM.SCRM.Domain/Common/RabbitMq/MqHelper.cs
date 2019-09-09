using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace BZM.SCRM.Domain.Common.RabbitMq
{
    /// <summary>
    /// mq
    /// </summary>
    public class MqHelper
    {
        /// <summary>
        /// mq连接
        /// </summary>
        private static IConnection _connection;
        /// <summary>
        /// 配置管理
        /// </summary>
        public IConfiguration _configuration { get; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="configuration"></param>
        public MqHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 获取连接对象
        /// </summary>
        /// <returns></returns>
        public IConnection GetConnection()
        {
            if (_connection != null) return _connection;
            _connection = GetNewConnection();
            return _connection;
        }

        /// <summary>
        /// 创建mq链接
        /// </summary>
        /// <returns></returns>
        public IConnection GetNewConnection()
        {
            try
            {
                //从工厂中拿到实例 本地host、用户admin
                var factory = new ConnectionFactory()
                {
                    HostName = _configuration["RabbitMQ:HostName"],
                    UserName = _configuration["RabbitMQ:UserName"],
                    Password = _configuration["RabbitMQ:Password"],
                    Port = AmqpTcpEndpoint.UseDefaultPort,
                    VirtualHost = "/",
                    Protocol = Protocols.DefaultProtocol,
                    AutomaticRecoveryEnabled = true
                };
                _connection = factory.CreateConnection();
                

            }
            catch (Exception ex)
            {
               
            }

            return _connection;
        }
    }
}