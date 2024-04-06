
# Bom dia, Caro(a) avaliador(a) 
  Vou guiá-lo(s) pela minha linha de raciocínio ao codar esse teste requisitado por vocês e citar alguns obstáculos que tive pelo caminho.
  Eu recebi esse briefing tanto pelo Linkedin, quanto pelo e-mail, mas acredito que ambos vieram com alguma falta de informação. Tive que ajustar o arquivo da API que enviaram, mas sem o link para essa API.
  Logo, considerei essa API como uma API fictícia e segui meu trabalho para atender aos pontos requisitados.

## Arquitetura 
  O estilo da arquitetura foi a primeira coisa que decidi. O foco sempre é manter o sistema o mais limpo possível, então segui o padrão Clean Architecture. Este consiste em 3 camadas geralmente, sendo elas API, serviços e infra. Ela é uma arquitetura que facilita novas implementações e a inclusão de novos devs, o que já pode suprir a necessidade desse projeto.
### Startup
  O arquivo Startup é onde boa parte das decisões que fui tomando estão presentes, então irei pontuar diversos serviços que adicionei, para poder acelerar a entrega desse teste. 
### .Net 8.0
  Já trabalhei com versões legado do .Net, mas tenho preferência por manter os projetos cobertos pelo suporte LTS da Microsoft, pois evitamos falhas de seguranças e temos acessos à diversas otimizações. 
### EntityFramework
  Uma ORM quase que nativa para o .Net, uma das ferramentas mais poderosas para esse ecossistema. Deleguei a ela toda a gestão das entidades, seguindo a prática do code-first.
### PostgresSQL
  Aqui há diversos dilemas que podem ser levantados: "Porque não NoSQL?", "Porque não o SQLServer?", "Ah, mas o DynamoDB". Sempre trabalho em prol do custo-benefício. Nos projetos que trabalhei, o mongoDb sempre foi muito custoso, tanto em custo de processamento, quanto em dinheiro com suas unidades de requisição na AWS. O SqlServer costuma sempre ser a melhor escolha para aplicações comerciais, tiramos muitos benefícios das tecnologias e de suas rápidas consultas e do seu custo fixo por núcleo de processamento. Mas eu decidi utilizar o Postgres, por ser compatível com o EntityFramework, ser gratuito e seu custo prático é ser apenas o custo de armazenamento. Poderia ter usado o Dynamo, pois ele é rapido, aceita desconexão e conexão diversas e poderia utilizá-lo como uma forma de "ORM", mas acredito que ele foge do escopo e da complexidade da entrega.
### Swagger 
  É uma ótima ferramenta para visualizar e testar de pronto a API, utilizo nos projetos do trabalho, até hoje não tive ressalvas e a interface é muito amigável ao utilizador.
### Authenticação: Basic Auth
  Poderia ter abordado usando JWT, seria minha preferência de comunicação entre API ou até mesmo de autenticação de usuário, mas na API de exemplo é citado o Basic Auth, então decidi manter assim. 
### AutoMapper
  Utilizei essa ferramenta para facilitar a conversão de uma entidade para um DTO de forma rápida. O próprio .Net tem uma técnica rápida para isso, mas é inviável para reprodução em sistemas com muitas Classes que transitam informações entre si. Então para manter o padrão mais próximo à realidade, escolhi o AutoMapper.
### Refit
  Instalei o Refit e criei sua interface para poder conectar com a API de IoT citada no arquivo e requisitar seus dados. Ela é visível no código no IColaborativeIoTClient.
 
## Camada de API/Controllers
  Em seguida vou abordar minhas escolhas de endpoints:
### Users
  Dexei a classe de users sem a necessidade de autenticar, pois fica mais fácil para testar. No mundo real, elas seriam fechadas e provavelmente teríamos uma entidade administrativa para cuidar disso.
### Devices
  Aqui já é necessário a autenticação do usuário para poder publicar, requisitar um device e requisitar a lista de devices que atende o item 3 e 4 propostos por vocês. 

## Camada de Serviços
  A camada de Serviços eu mantive "protegida" utilizando a comunicação via interface, para não ter risco de interação entre serviços diferentes. Acredito que não tem muita coisa a dizer, sigo usando arquitetura limpa, então tudo se mantem bem inteligível.
### TelnetService
  Seria o serviço que é executado para conectar ao device IoT e executar um comando via Telnet. Está implementado para cumprir o requisito 4 e 5 do documento, mas como não tive acesso ao endpoint dessa API referência, não consegui requisitar um device com uma URL válida para testar a execução do comando, deixando todo o teste como local.

## Camada de Infraestutura
  É onde a permanência das entidades são mantidas e controladas. Uma coisa boa do Entity Framework é poder acompanhar o histórico de migrações e otimização das entidades do banco. 

# Agradecimento e Considerações Finais.
## Agradecimento
  Obrigado pelo tempo desprendido para analisar meu código.
  
## Considerações finais
  Eu vi esse projeto mais como uma prova de conceito, um MVP para testar se algo funciona para aí sim ser melhorado e implementado. Acredito que minha versão desse teste já é uma API utilizável, o que poderiamos aprimorar mais seria a questão de Autenticação, uma otimização da regra de negócio e talvez até adicionar um código de concorrência na execução do Telnet, mas acredito que por agora seria demais pra um MVP.

  

