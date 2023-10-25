using BackGroundTask.Modelos;
using BackGroundTask.Modelos.Dto;

namespace BackGroundTask.Repositorio.IRepositorio
{
    public interface IUsuarioRepositorio
    {
        bool IsUsuarioUnico(string userName);

        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);

        Task<UsuarioDto> Registrar(RegistroRequestDTO registroRequestDTO);
    }
}
