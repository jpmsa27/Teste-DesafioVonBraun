using DesafioBackEndVonBraun.Service.DTOs;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackEndVonBraun.Service.Interfaces.ColaborativeIoT
{
    public interface IColaborativeIoTClient
    {
        [Get("/device")]
        public Task<string[]> GetDeviceList();

        [Post("/device")]
        public Task PostDevice(string[] devices);

        [Get("/device/{id}")]
        public Task GetDeviceById(string[] devices);

        [Put("/device/{id}")]
        public Task UpdateDevice();

        [Delete("/device/{id}")]
        public Task DeleteDevice();
    }
}
