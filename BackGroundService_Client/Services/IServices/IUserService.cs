using BackGroundTask_Client.Modelos.Dto;

namespace BackGroundService_Client.Services.IServices
{
    public interface IUserService
    {
        Task<T> Loging<T>(LoginRequestDTO dto);
        Task<T> Registrate<T>(RegistroRequestDTO dto);
    }
}
