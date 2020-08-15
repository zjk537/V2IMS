using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace Vogue2_IMS.Business
{
    class WebServiceHelper
    {
        private static string _tokenName = "V2AUTHTOKEN";
        private static string _baseUrl = "http://120.27.21.93:8080/api.php/pc";
        public static string Token { get; set; }
        /// <summary>
        /// POST &=&
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string Post(string url, Dictionary<string, string> dic)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(_baseUrl + url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            #region 添加Post 参数
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in dic)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }
            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容  
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        public static T1 HttpPost<T, T1>(string url, T t)
        {
            var retusnStr = string.Empty;
            var jsonPams = JsonConvert.SerializeObject(t, Formatting.Indented);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_baseUrl + url);
            request.Method = "POST";
            request.ContentType = "application/json";
            //request.ContentLength = Encoding.UTF8.GetByteCount(jsonPams);

            request.Headers.Add(_tokenName, Token);

            using (Stream myRequestStream = request.GetRequestStream())
            {
                StreamWriter myStreamWriter = new StreamWriter(myRequestStream);
                myStreamWriter.Write(jsonPams);
                myStreamWriter.Close();
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream myResponseStream = response.GetResponseStream())
            {
                using (StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8")))
                {
                    retusnStr = myStreamReader.ReadToEnd();
                    myStreamReader.Close();
                }
                myResponseStream.Close();
            }

            var respone = (ResponseMsgBase<T1>)JsonConvert.DeserializeObject(retusnStr, typeof(ResponseMsgBase<T1>));


            if (respone.code == 200)
            {
                return respone.data;
            }
            else
            {
                throw new Exception(string.Format("{0} 操作失败,原因：{1}-{2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm"), respone.code, respone.msg));
            }

        }
    }

    public class ResponseMsgBase<T>
    {
        public int code
        {
            get;
            set;
        }

        public string msg
        {
            get;
            set;
        }

        public T data { get; set; }
    }

}
