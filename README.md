📅 AgendaWeb

Um sistema web completo para gerenciamento de eventos e agenda pessoal, desenvolvido em ASP.NET Core 6.0 com arquitetura em camadas e interface responsiva.

🚀 Sobre o Projeto

O AgendaWeb é uma aplicação web robusta que permite aos usuários gerenciar seus eventos de forma eficiente e organizada. O sistema oferece funcionalidades completas de CRUD (Create, Read, Update, Delete) para eventos, sistema de autenticação seguro, dashboard com estatísticas e geração de relatórios em múltiplos formatos.

✨ Principais Funcionalidades

•
Sistema de Autenticação: Login e registro de usuários com sessões seguras

•
Dashboard Interativo: Visão geral dos eventos com estatísticas por prioridade e status

•
Gerenciamento de Eventos: CRUD completo com validações robustas

•
Sistema de Prioridades: Classificação de eventos em alta, média e baixa prioridade

•
Filtros Avançados: Consulta de eventos por período e status (ativo/inativo)

•
Geração de Relatórios: Exportação em PDF e Excel com dados filtrados

•
Interface Responsiva: Design moderno e adaptável para diferentes dispositivos

•
Arquitetura Escalável: Separação clara de responsabilidades em camadas

🛠️ Tecnologias Utilizadas

Backend

•
ASP.NET Core 6.0: Framework principal para desenvolvimento web

•
Entity Framework Core: ORM para acesso a dados

•
C#: Linguagem de programação principal

Frontend

•
Bootstrap 5: Framework CSS para interface responsiva

•
HTML5/CSS3: Estrutura e estilização das páginas

•
JavaScript: Interatividade do lado cliente

Relatórios

•
iTextSharp/PDF: Geração de relatórios em PDF

•
EPPlus/Excel: Geração de relatórios em Excel

Arquitetura

•
MVC Pattern: Padrão Model-View-Controller

•
Repository Pattern: Abstração da camada de dados

•
Dependency Injection: Inversão de controle e injeção de dependências

📁 Estrutura do Projeto

O projeto segue uma arquitetura em camadas bem definida, promovendo separação de responsabilidades e facilidade de manutenção:

Plain Text


    AgendaWeb/
    ├── 1 - Presentation
    |   ├── AgendaWeb.Presentation/         
    │   |  ├── Connected Services/
    |   |  |   ├── Banco de Dados
    │   |  ├── Dependências/
    │   |  ├── Properties/
    |   |  |   ├── PublishProfiles
    |   |  |   |   └── FolderProfile.pubxml
    |   |  |   ├── launchSettings.json
    │   |  ├── wwwroot/
    |   |  |   ├── CSS
    |   |  |   |   ├── bootstrap.css
    |   |  |   |   ├── bootstrap-grid.css
    |   |  |   |   ├── bootstrap-reboot.css
    |   |  |   |   └── bootstrap-utilities.css
    |   |  |   ├── img
    |   |  |   |   └── perfil.jpg
    |   |  |   ├── js
    |   |  |   |   └── bootstrap.js
    │   |  ├── Controllers/                 
    │   |  │   ├── AccountController.cs     
    │   |  │   ├── AgendaController.cs      
    │   |  │   └── HomeController.cs        
    │   |  ├── Models/                      
    |   |  |   ├── AccountLoginViewModel.cs
    |   |  |   ├── AccountRegisterViewModel.cs
    |   |  |   ├── DashboardViewModel.cs
    |   |  |   ├── EventoCadastroViewModel.cs
    |   |  |   ├── EventoConsultaViewModel.cs
    |   |  |   ├── EventoEdicaoViewModel.cs
    |   |  |   ├── EventoEdicaoViewModel.cs
    |   |  |   └── UserIdentityModel.cs
    │   |  ├── Views/                       
    |   |  |   └── Account
    |   |  |   |   ├── Login.cshtml
    |   |  |   |   ├── Register.cshtml
    |   |  |   |   └── UserData.cshtml
    |   |  |   └── Agenda
    |   |  |   |   ├── Cadastro.cshtml
    |   |  |   |   ├── Consulta.cshtml
    |   |  |   |   ├── Edicao.cshtml
    |   |  |   |   └── Relatorio.cshtml
    |   |  |   └── Home
    |   |  |   |   └── Index.cshtml
    |   |  |   └── Shared
    |   |  |   └── Layout.cshtml
    |   |   └── _ViewStart.cshtml
    |   └── appsettings.json
    |   |   └── appsettings.Development.json
    |   └── Program.cs
    ├── 2 - Repository
    |   ├── AgendaWeb.InfraData/ 
    │   |  ├── Dependências/
    |   |  ├── Entities/
    |   |  |   ├── Evento.cs
    |   |  |   └── Usuario.cs
    |   |  ├── Interfaces/
    |   |  |   ├── IBaseRepository.cs
    |   |  |   ├── IEventoRepository.cs
    |   |  |   └── IusuarioRepository.cs
    |   |  ├── Repositories/
    |   |  |   ├── EventoRepository.cs
    |   |  |   └── UsuarioRepository.cs
    |   |  ├── Repositories/
    |   |  |   └── CriptografiaUtil.cs
    ├── 3 - Reports
    |   ├── AgendaWeb.Reports/ 
    │   |  ├── Dependências/
    |   |  ├── Interfaces/
    |   |  |   └── IEventoReportService.cs
    |   |  ├── Services/
    |   |  |   ├── EventoReportServiceExcel.cs
    |   |  |   └── EventoReportServicePdf.cs      


🎯 Responsabilidades das Camadas

Presentation Layer (AgendaWeb.Presentation)
Esta camada é responsável pela interface do usuário e controle de fluxo da aplicação. Contém os controladores MVC que processam as requisições HTTP, as views que renderizam o HTML para o usuário, e os ViewModels que transportam dados entre as camadas. A camada de apresentação não contém lógica de negócio, apenas orquestra as chamadas para as camadas inferiores.

Infrastructure Layer (AgendaWeb.Infra.Data)
A camada de infraestrutura encapsula todo o acesso a dados da aplicação. Implementa o padrão Repository para abstrair as operações de banco de dados, define as entidades que representam o modelo de domínio, e configura o contexto do Entity Framework. Esta separação permite que a lógica de negócio seja independente da tecnologia de persistência utilizada.

Reports Layer (AgendaWeb.Reports)
Uma camada especializada para geração de relatórios, implementando o padrão Strategy para permitir diferentes formatos de exportação. Esta separação facilita a adição de novos formatos de relatório e mantém a responsabilidade de geração de documentos isolada do resto da aplicação.

🔧 Pré-requisitos

Antes de executar o projeto, certifique-se de ter instalado:

•
.NET 6.0 SDK ou superior

•
Visual Studio 2022 ou Visual Studio Code

•
SQL Server ou SQL Server Express (ou configure para usar outro banco de dados)

•
Git para controle de versão

📥 Instalação e Configuração

1. Clone o Repositório

Bash


git clone https://github.com/TrajanoDeveloper/AgendaWeb.git
cd AgendaWeb


2. Restaurar Dependências

Bash


dotnet restore


3. Configurar String de Conexão

Edite o arquivo appsettings.json na pasta AgendaWeb.Presentation e configure sua string de conexão:

JSON


{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=AgendaWebDB;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}


4. Executar Migrações do Banco de Dados

Bash


cd AgendaWeb.Presentation
dotnet ef database update


5. Executar a Aplicação

Bash


dotnet run


A aplicação estará disponível em https://localhost:5001 ou http://localhost:5000.

🎮 Como Usar

Primeiro Acesso

1. Registro: Acesse a página de registro e crie uma nova conta

2. Login: Faça login com suas credenciais

3. Dashboard: Visualize o painel principal com estatísticas dos seus eventos

Gerenciamento de Eventos

Cadastrar Novo Evento

1. Navegue para "Agenda" → "Cadastro"

2. Preencha os campos obrigatórios:

• Nome do evento

• Data e hora

• Descrição

• Prioridade (Alta, Média, Baixa)



3. Clique em "Salvar"

Consultar Eventos

1. Acesse "Agenda" → "Consulta"

2. Defina o período de consulta

3. Escolha o status (Ativo/Inativo)

4. Visualize os resultados em uma tabela organizada

Editar Evento

1. Na consulta de eventos, clique no ícone de edição

2. Modifique os campos necessários

3. Salve as alterações
 
Excluir Evento

1. Na consulta de eventos, clique no ícone de exclusão

2. Confirme a operação

Geração de Relatórios

Relatório PDF

1. Acesse "Agenda" → "Relatório"

2. Selecione o período desejado

3. Escolha o status dos eventos

4. Selecione "PDF" como formato

5. Clique em "Gerar Relatório"

Relatório Excel

1. Siga os mesmos passos acima

2. Selecione "Excel" como formato

3. O arquivo será baixado automaticamente

🏗️ Arquitetura e Padrões

Padrões de Design Implementados

Repository Pattern
O projeto implementa o padrão Repository para abstrair o acesso a dados, proporcionando uma interface limpa entre a lógica de negócio e a camada de persistência. Cada entidade possui seu próprio repositório com operações CRUD específicas.

Dependency Injection
Utiliza o container de DI nativo do ASP.NET Core para gerenciar dependências, promovendo baixo acoplamento e facilitando testes unitários.

Strategy Pattern
Implementado na geração de relatórios, permitindo diferentes algoritmos de exportação (PDF, Excel) através de uma interface comum.

MVC Pattern
Segue rigorosamente o padrão Model-View-Controller, separando responsabilidades de apresentação, controle e modelo de dados.

Modelo de Dados

Entidade Evento

Plain Text


public class Evento
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public DateTime Data { get; set; }
    public TimeSpan Hora { get; set; }
    public string Descricao { get; set; }
    public int Prioridade { get; set; }  // 1=Baixa, 2=Média, 3=Alta
    public DateTime DataInclusao { get; set; }
    public DateTime DataAlteracao { get; set; }
    public int Ativo { get; set; }       // 0=Inativo, 1=Ativo
    public Guid IdUsuario { get; set; }
    
    // Relacionamento
    public Usuario Usuario { get; set; }
}


Entidade Usuario

Plain Text


public class Usuario
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public DateTime DataInclusao { get; set; }
    
    // Relacionamento
    public List<Evento> Eventos { get; set; }
}


🔒 Segurança

O sistema implementa várias camadas de segurança:

•
Autenticação por Sessão: Controle de acesso baseado em sessões HTTP

•
Autorização: Decorators [Authorize] protegem rotas sensíveis

•
Validação de Dados: ModelState validation em todos os formulários

•
Sanitização: Prevenção contra ataques de injeção

•
Isolamento de Dados: Cada usuário acessa apenas seus próprios eventos

📊 Dashboard e Métricas

O dashboard principal oferece uma visão consolidada dos eventos:

•
Eventos por Prioridade: Contadores visuais para alta, média e baixa prioridade

•
Status dos Eventos: Separação entre eventos ativos e inativos

•
Período Atual: Foco no mês corrente com possibilidade de navegação

•
Indicadores Visuais: Cores diferenciadas para facilitar identificação rápida

🧪 Testes e Qualidade

Estrutura de Testes Recomendada

Plain Text


AgendaWeb.Tests/
├── Unit/                    # Testes unitários
│   ├── Controllers/         # Testes dos controladores
│   ├── Repositories/        # Testes dos repositórios
│   └── Services/           # Testes dos serviços
├── Integration/            # Testes de integração
└── E2E/                   # Testes end-to-end





⭐ Se este projeto foi útil para você, considere dar uma estrela no repositório! ⭐

Desenvolvido com ❤️ usando ASP.NET Core

⬆ Voltar ao Topo

</div>

