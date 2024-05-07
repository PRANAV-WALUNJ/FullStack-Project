namespace Mango.Web.Models
{
    public class RequestDto
    {
        public string Apitype { get; set; } = "Get";
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken {  get; set; }    
    }
}
