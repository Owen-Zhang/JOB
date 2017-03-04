using System;
using System.Net;
using System.Text;

namespace Job_FrameWork.Common
{
    public class HttpRestClient
    {
        WebHeaderCollection Header;
        public string responseStr;

        public HttpRestClient(WebHeaderCollection header)
        {
            this.Header = header;
        }

        public T PostByStrService<T>(string url, string method, object body = null, string encoding = "Utf-8")
            where T : class
        {
            var requestStr = GetRequestBodyStr(body);
            string responseStr = string.Empty;
            try
            {
                responseStr =
                new RequestHelper()
                    .GetHttpResponseStr(
                        new RequestInfo { 
                            Url = url,
                            Body = Encoding.GetEncoding(encoding).GetBytes(requestStr),
                            Method = method,
                            Header = this.Header
                        });
            }
            catch (Exception e)
            { 
                
            }
            return 
                SerializeManager.Deserialize<T>(responseStr, this.Header["Accept"]);
        }

        public T PostByteService<T>(string url, string method, byte[] byteContent)
            where T : class
        {
            string responseStr = string.Empty;

            try
            {
                responseStr = 
                new RequestHelper()
                   .GetHttpResponseStr(
                        new RequestInfo
                        {
                            Url = url,
                            Body = byteContent,
                            Method = method,
                            Header = this.Header
                        });
            }
            catch (Exception e)
            { 
                
            }
            return SerializeManager.Deserialize<T>(responseStr, this.Header["Accept"]);
        }

        public byte[] GetByteService(string url, string method, object body = null, string encoding = "Utf-8")
        {
            var requestStr = GetRequestBodyStr(body);
            try
            {
                return
                new RequestHelper()
                    .GetHttpResponseByte(
                        new RequestInfo
                        {
                            Url = url,
                            Body = Encoding.GetEncoding(encoding).GetBytes(requestStr),
                            Method = method,
                            Header = this.Header
                        });
            }
            catch (Exception e)
            { 
            
            }
            return null;
        }

        private string GetRequestBodyStr(object body)
        {
            if (body == null)
                return string.Empty;
            return SerializeManager.Serialize(body, this.Header["Content-Type"]);
        }
    }
}
