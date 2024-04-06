using DesafioBackEndVonBraun.Infraestrutura.DatabaseEntity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackEndVonBraun.Service.DTOs.Device
{
    public class DeviceDTO
    {
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string Url { get; set; }
        public List<ComandosDTO> Commands { get; set; }
    }

    public class ComandosDTO
    {
        public string Operation { get; set; }
        public string Description { get; set; }
        public ComandoDTO comand { get; set; }
        public string Result { get; set; }
        public string Format { get; set; }
    }

    public class ComandoDTO
    {
        public string Command { get; set; }
    }
}
