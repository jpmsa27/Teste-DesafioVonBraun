using AutoMapper;
using DesafioBackEndVonBraun.Infraestructure.DatabaseEntity;
using DesafioBackEndVonBraun.Infraestrutura.ContextDb;
using DesafioBackEndVonBraun.Service.DTOs.Auth;
using DesafioBackEndVonBraun.Service.DTOs.Device;
using DesafioBackEndVonBraun.Service.Interfaces.ColaborativeIoT;
using DesafioBackEndVonBraun.Service.Interfaces.Device;
using DesafioBackEndVonBraun.Service.Interfaces.Telnet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackEndVonBraun.Service.Services
{
    public class DeviceService(DesafioVonBraunDbContext dbContext, IMapper mapper, IColaborativeIoTClient ioTClient, ITelnetCommandService telnetCommandService): IDeviceService
    {
        private readonly DesafioVonBraunDbContext _DbContext = dbContext;
        private readonly IColaborativeIoTClient _IoTClient = ioTClient;
        private readonly ITelnetCommandService _TelnetCommandService = telnetCommandService;


        private readonly IMapper _Mapper = mapper;

        public async Task CreateDevice(DeviceDTO deviceDTO)
        {
            if(deviceDTO.Manufacturer != "PredictWeater")
            {
                throw new Exception("Fabricante Invalido.");
            }
            var transaction = _DbContext.Database.BeginTransaction();

            var device = await _DbContext.Devices.AddAsync(_Mapper.Map<DeviceEntity>(deviceDTO));

            await transaction.CommitAsync();
            await _DbContext.SaveChangesAsync();
            return;
        }

        public async Task<DeviceDTO> GetDevice(string DeviceId)
        {
            var device = await _DbContext.Devices.Include(x => x.Commands).ThenInclude(x=>x.comand)
                .Where(x => x.Id == DeviceId && x.Manufacturer == "PredictWeater").FirstAsync();

            return _Mapper.Map<DeviceDTO>(device);
        }

        public async Task<DeviceDTO[]> GetDevices()
        {
            var devices = await _DbContext.Devices.Where(x => x.Manufacturer == "PredictWeater").Include(x => x.Commands).ThenInclude(x => x.comand).ToArrayAsync();

            foreach(var item in devices)
            {
                foreach (var command in item.Commands)
                {
                    command.Result = await _TelnetCommandService.ExecuteCommand(item.Url, command.comand.Command);
                }
            }

            return _Mapper.Map<DeviceDTO[]>(devices);
        }
    }
}
