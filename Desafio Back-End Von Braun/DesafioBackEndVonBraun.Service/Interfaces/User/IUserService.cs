using DesafioBackEndVonBraun.Service.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackEndVonBraun.Service.Interfaces.Auth
{
    public interface IUserService
    {
        Task CreateUser(UserDTO authRequestDTO);
        Task<UserDTO> GetUser(string Cpf);
    }
}
