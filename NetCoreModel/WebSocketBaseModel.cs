using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreModel
{
    /// <summary>
    /// WebSocket模型基类
    /// </summary>
   public class WebSocketBaseModel
    {
        /// <summary>
        /// 请求消息体Key
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 请求消息体Value
        /// </summary>
        public long Value { get; set; }
        /// <summary>
        /// 线程睡眠时间
        /// </summary>
        public int SleepTime { get; set; }
    }
}
