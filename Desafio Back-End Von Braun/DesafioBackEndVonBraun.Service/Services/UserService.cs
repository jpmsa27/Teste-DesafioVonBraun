using AutoMapper;
using DesafioBackEndVonBraun.Infraestructure.DatabaseEntity;
using DesafioBackEndVonBraun.Infraestrutura.ContextDb;
using DesafioBackEndVonBraun.Service.DTOs.Auth;
using DesafioBackEndVonBraun.Service.Interfaces.Auth;
using DesafioBackEndVonBraun.Service.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackEndVonBraun.Service.Services
{
    public class UserService(DesafioVonBraunDbContext context, IMapper mapper) : IUserService
    {
        private readonly DesafioVonBraunDbContext _DbContext = context;
        private readonly IMapper _Mapper = mapper;

        public async Task CreateUser(UserDTO userRequestDTO)
        {
            var transaction = _DbContext.Database.BeginTransaction();
            if(CpfValidator.IsCpf(userRequestDTO.Cpf) ==  false)
            {
                throw new Exception("Cpf Invalido.");
            }
            var user = await _DbContext.Users.AddAsync(_Mapper.Map<UserEntity>(userRequestDTO));
            await transaction.CommitAsync();
            await _DbContext.SaveChangesAsync();
            return;
        }

        public async Task<UserDTO> GetUser(string Cpf)
        {
            var user = await _DbContext.Users.Where(x=>x.Cpf == Cpf).FirstAsync();

            if (user == null) { throw new Exception("User não encontrado."); }

            return _Mapper.Map<UserDTO>(user);
        }
    }
}
