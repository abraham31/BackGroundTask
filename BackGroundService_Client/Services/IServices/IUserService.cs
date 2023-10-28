using BackGroundService_Client.Models.Dto;

namespace BackGroundService_Client.Services.IServices
{
    public interface IUserService
    {
        Task<T> Login<T>(LoginRequestDTO dto);
        Task<T> SingUp<T>(RegistroRequestDTO dto);
    }
}
