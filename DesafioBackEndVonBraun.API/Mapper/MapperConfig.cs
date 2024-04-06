using AutoMapper;
using DesafioBackEndVonBraun.Infraestructure.DatabaseEntity;
using DesafioBackEndVonBraun.Service.DTOs.Auth;
using DesafioBackEndVonBraun.Service.DTOs.Device;

namespace DesafioBackEndVonBraun.API.Mapper
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<DeviceEntity, DeviceDTO>();
            CreateMap<DeviceDTO, DeviceEntity>();

            CreateMap<Comando, ComandoDTO>();
            CreateMap<ComandoDTO, Comando>();

            CreateMap<Comandos, ComandosDTO>();
            CreateMap<ComandosDTO, Comandos>();

            CreateMap<UserEntity, UserDTO>();
            CreateMap<UserDTO, UserEntity>();
        }
    }
}
