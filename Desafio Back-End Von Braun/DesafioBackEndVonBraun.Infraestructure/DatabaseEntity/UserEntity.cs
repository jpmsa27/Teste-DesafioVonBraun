using DesafioBackEndVonBraun.Infraestrutura.DatabaseEntity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackEndVonBraun.Infraestructure.DatabaseEntity
{
    public class UserEntity: Entity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Cpf { get; set; }
    }
}
