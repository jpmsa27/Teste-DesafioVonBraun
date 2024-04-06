using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackEndVonBraun.Service.Interfaces.Telnet
{
    public interface ITelnetCommandService
    {
        Task<string> ExecuteCommand(string url, string command);
    }
}
