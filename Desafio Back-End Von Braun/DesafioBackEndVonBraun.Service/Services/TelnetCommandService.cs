using DesafioBackEndVonBraun.Infraestructure.DatabaseEntity;
using DesafioBackEndVonBraun.Infraestrutura.ContextDb;
using DesafioBackEndVonBraun.Service.Interfaces.Telnet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DesafioBackEndVonBraun.Service.Services
{
    public class TelnetCommandService() : ITelnetCommandService
    {
        public Task<string> ExecuteCommand(string url, string command)
        {
            try
            {
                string server = url;
                int port = 23;

                TcpClient client = new TcpClient(server, port);

                NetworkStream stream = client.GetStream();
                StreamReader reader = new StreamReader(stream);
                StreamWriter writer = new StreamWriter(stream);

                string initialResponse = reader.ReadLine();
                Console.WriteLine("Resposta inicial do servidor: " + initialResponse);

                writer.Write(command);
                writer.Flush();

                string response = reader.ReadLine();

                client.Close();

                return Task.FromResult(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                return Task.FromResult("null");
            }
        }
    }
}
