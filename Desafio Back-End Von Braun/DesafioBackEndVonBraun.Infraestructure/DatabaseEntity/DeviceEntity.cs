using DesafioBackEndVonBraun.Infraestrutura.DatabaseEntity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackEndVonBraun.Infraestructure.DatabaseEntity
{
    public class DeviceEntity : Entity
    {
        public string Description {  get; set; }
        public string Manufacturer {  get; set; }
        public string Url {  get; set; }
        public List<Comandos> Commands { get; set; }
    }

    public class Comandos : Entity
    {
        public string Operation { get; set; }
        public string Description { get; set; }
        public Comando comand { get; set; }
        public string Result { get; set; }
        public string Format { get; set; }
    }

    public class Comando : Entity
    {
        public string Command { get; set; }
    }
}
