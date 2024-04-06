using DesafioBackEndVonBraun.Infraestrutura.ContextDb;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace DesafioBackEndVonBraun.Service.Services
{
    public class BasicAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        Microsoft.AspNetCore.Authentication.ISystemClock clock,
        DesafioVonBraunDbContext desafioVonBraunDb) : AuthenticationHandler<AuthenticationSchemeOptions>(options, logger, encoder, clock)
    {
        private readonly DesafioVonBraunDbContext _desafioVonBraunDbContext = desafioVonBraunDb;
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // Extrai o header de autorização
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Cabeçalho de autorização ausente");
            }

            try
            {
                // Decodifica o valor do header de autorização
                var authenticationHeaderValue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var decodedAuthenticationHeader = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationHeaderValue.Parameter));
                var credentials = decodedAuthenticationHeader.Split(':', 2);

                // Verifica as credenciais
                var username = credentials[0];
                var password = credentials[1];

                var user = _desafioVonBraunDbContext.Users.Where(x=>x.UserName == username && x.Password == password).FirstOrDefault();

                // Verifica as credenciais (substitua esta lógica pela sua própria lógica de verificação de credenciais)
                if (user!=null)
                {
                    var claims = new[] {
                    new Claim(ClaimTypes.NameIdentifier, username),
                    new Claim(ClaimTypes.Name, username)
                };

                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    return AuthenticateResult.Success(ticket);
                }
                else
                {
                    return AuthenticateResult.Fail("Credenciais inválidas");
                }
            }
            catch
            {
                return AuthenticateResult.Fail("Erro ao processar as credenciais");
            }
        }
    }
}
