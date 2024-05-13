using Mango.Web.Models;
using Mango.Web.Services.IService;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
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

                // Set request URI
                message.RequestUri = new Uri(requestDto.Url);

                // Create HttpContent for request data
                HttpContent requestData = null;
                if (requestDto.Data != null)
                {
                    requestData = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }

                // Set method and content
                switch (requestDto.Apitype)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        message.Content = requestData;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        message.Content = requestData;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                // Set Content-Type header on HttpContent object
                if (requestData != null)
                {
                    requestData.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                }

                HttpResponseMessage? apiResponse = await httpClient.SendAsync(message);

                // Handle response
                switch (apiResponse.StatusCode)
                {
                    // Handle various status codes
                }

                // Return response if no exception occurred
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                return apiResponseDto;
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
