using BackGroundService_Client.Models.Dto;
using BackGroundTask_Client.Modelos;

namespace BackGroundService_Client.Services.IServices
{
    public interface IBaseService
    {
        public APIResponse responseModel { get; set; }

        Task<T> SendAsync<T>(APIRequest apiRequest);
    }
}
