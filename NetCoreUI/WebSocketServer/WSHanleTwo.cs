using Microsoft.AspNetCore.Http;
using NetCoreHelp;
using NetCoreModel;
using Newtonsoft.Json.Linq;
using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreUI.WebSocketServer
{
    public class WSHanleTwo
    {
        private WebSocket socket = null;
        //创建链接  
        public async Task Connect(HttpContext context, Func<Task> n)
        {
            try
            {              
                //执行接收  
                WebSocket socket = await context.WebSockets.AcceptWebSocketAsync();
                this.socket = socket;
                //执行监听  
                await EchoLoop();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>  
        /// 响应处理  
        /// </summary>  
        /// <returns></returns>  
        async Task EchoLoop()
        {           
            var buffer = new byte[1024];
            var seg = new ArraySegment<byte>(buffer);
            while (this.socket.State == WebSocketState.Open)
            {
                var incoming = await this.socket.ReceiveAsync(seg, CancellationToken.None);
                var Receive = System.Text.UTF8Encoding.Default.GetString(seg.Array);
                byte[] backInfo = System.Text.UTF8Encoding.Default.GetBytes($"格式有误，请检查{DateTime.Now}");
                if (Receive.Contains("&"))
                {
                    var ReceiveMessige= System.Text.UTF8Encoding.Default.GetString(seg.Array).Split('&');
                    //解析Json字符串为JObject
                    var  result = JsonHelper.DeserializeJsonToObject<WebSocketBaseModel>(ReceiveMessige[0],out WebSocketBaseModel model);
                    if (result)
                    {
                        Thread.Sleep(model.SleepTime);                       
                        backInfo = System.Text.UTF8Encoding.Default.GetBytes("服务端相应内容:OK");                                      
                    }                  
                }               
                var ErrorOutgoing = new ArraySegment<byte>(backInfo, 0, backInfo.Length);
                await this.socket.SendAsync(ErrorOutgoing, WebSocketMessageType.Text, true, CancellationToken.None);              
            }
        }
    }
}
