using BackGroundService_Client.Models.Dto;
using BackGroundService_Client.Services.IServices;
using BackGrundTask_Utility;

namespace BackGroundService_Client.Services
{
    public class UserService : BaseService, IUserService
    {
        public readonly IHttpClientFactory _httpClient;
        private string _usernameUrl;
        public UserService(IHttpClientFactory httpClient, IConfiguration configuration) : base(httpClient)
        {
            _httpClient = httpClient;
            _usernameUrl = configuration.GetValue<string>("ServiceUrls:API_URL");
        }
        public Task<T> Login<T>(LoginRequestDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                APITipo = DS.APITipo.POST,
                Data = dto,
                Url = new Uri(new Uri(_usernameUrl), "api/Usuario/login").ToString()
            });
        }

        public Task<T> SingUp<T>(RegistroRequestDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                APITipo = DS.APITipo.POST,
                Data = dto,
                Url = new Uri(new Uri(_usernameUrl), "api/Usuario/registrar").ToString()
            });
        }
    }
}
