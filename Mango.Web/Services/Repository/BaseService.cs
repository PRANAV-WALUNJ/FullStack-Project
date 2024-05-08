using Mango.Web.Models;
using Mango.Web.Services.IService;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static Mango.Web.Utility.StaticData;

namespace Mango.Web.Services.Repository
{
    public class BaseService : IBaseService
    {
        IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            try
            {
            HttpClient httpClient = _httpClientFactory.CreateClient("MangoAPI");
            HttpRequestMessage message = new();
            message.Headers.Add("Content-Type", "application/json");
            //token

            message.RequestUri = new Uri(requestDto.Url);
            if (requestDto.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
            }
            HttpResponseMessage? apiResponse = null;

            switch (requestDto.Apitype)
            {
                case ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break;

            }

            apiResponse = await httpClient.SendAsync(message);

            switch (apiResponse.StatusCode)
            {
                case HttpStatusCode.OK:
                    return new() { Success = false, Message = "Not Found" };

                case HttpStatusCode.Forbidden:
                    return new() { Success = false, Message = "Access Denied" };

                case HttpStatusCode.Unauthorized:
                    return new() { Success = false, Message = "Unauthorized" };

                case HttpStatusCode.InternalServerError:
                    return new() { Success = false, Message = "InternalServerError" };

                default:
                    var apiContent = await apiResponse.Content.ReadAsStringAsync();
                    var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);

                    return apiResponseDto;  
            }
            }
            catch (Exception ex)
            {
                var response = new ResponseDto
                {
                    Message = ex.Message,
                    Success = false,
                };
                return response;
            }


        }
    }
}
