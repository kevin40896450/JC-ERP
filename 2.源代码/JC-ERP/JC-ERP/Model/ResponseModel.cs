using Nancy;

namespace JC_ERP
{
    public class ResponseModel
    {
        public HttpStatusCode StatusCode { get; set; }
        /// <summary>
        /// 提示消息
        /// </summary>
        public string Message { get; set; }
        
    }
    
}
