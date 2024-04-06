using DesafioBackEndVonBraun.Service.DTOs.Auth;
using DesafioBackEndVonBraun.Service.DTOs.Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackEndVonBraun.Service.Interfaces.Device
{
    public interface IDeviceService
    {
        Task CreateDevice(DeviceDTO authRequestDTO);
        Task<DeviceDTO> GetDevice(string Cpf);
        Task<DeviceDTO[]> GetDevices();
    }
}
