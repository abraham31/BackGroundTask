using BackGroundService_Client.Models;
using BackGroundService_Client.Models.Dto;

namespace BackGroundService_Client.Services.IServices
{
    public interface IBaseService
    {
        public APIResponse responseModel { get; set; }

        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
