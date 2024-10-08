# CheckPoint5 

## Aluno: 
•	Jean Carlos RM 550430 

## Descrição do Projeto
O **CheckPoint5** é uma aplicação web construída utilizando a tecnologia .NET Core, com uma arquitetura baseada em uma WebAPI que realiza operações CRUD (Create, Read, Update, Delete) para gerenciar dados de clientes em um banco de dados MongoDB. O projeto também inclui chamadas assíncronas e testes unitários utilizando o framework xUnit.

## Tecnologias Utilizadas
- **.NET Core 8**: Framework utilizado para desenvolver a API.
- **MongoDB**: Banco de dados NoSQL utilizado para armazenar os dados dos clientes.
- **xUnit**: Framework de testes unitários utilizado para garantir a confiabilidade do código.
- **Swagger**: Ferramenta de documentação e teste da API.
- **Docker**: Utilizado para rodar o ambiente de desenvolvimento.

## Funcionalidades
- **Cadastro de Clientes**: Permite adicionar novos clientes ao sistema.
- **Consulta de Clientes**: Recupera a lista de clientes cadastrados.
- **Atualização de Dados**: Atualiza informações de clientes existentes.
- **Remoção de Clientes**: Remove clientes do banco de dados.
- **Validação de E-mail**: Validação de formato de e-mail utilizando expressões regulares.
- **Testes Unitários**: Cobertura de testes unitários para validação dos métodos da API.

## Estrutura do Projeto
O projeto está organizado da seguinte maneira:

CheckPoint5/ │ ├── CheckPoint5/ │ ├── Controllers/ │ ├── Models/ │ ├── Services/ │ ├── Settings/ │ └── Program.cs │ ├── CheckPoint5.Tests/ │ └── MongoDbServiceTests.cs │ └── ClienteModelTests.cs │ ├── docker-compose.yml ├── CheckPoint5.sln └── README.md

### Principais Componentes
1. **Models**: Contém as classes que representam as entidades do projeto, como `ClienteModel`.
2. **Services**: Contém a lógica de negócio e a integração com o MongoDB, como a classe `MongoDbService`.
3. **Controllers**: Define os endpoints da API.
4. **Settings**: Contém as configurações relacionadas ao MongoDB.
5. **Tests**: Contém os testes unitários para validar a funcionalidade do sistema.

## Requisitos para Rodar o Projeto
- .NET Core SDK 8.0 ou superior
- Docker (para rodar MongoDB em container)
- MongoDB (instalado localmente ou em um container)
- Visual Studio ou Visual Studio Code (para desenvolvimento)

## Configurar as Dependências:
- Instalar as dependências do projeto: dotnet restore
- Rodar MongoDB com Docker (opcional, caso não tenha o MongoDB instalado): docker-compose up -d
- Configurar as Variáveis de Ambiente: Verifique o arquivo appsettings.json e ajuste as configurações de conexão com o MongoDB:
{
  "MongoDbSettings": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "CheckPoint5DB",
    "CollectionName": "Clientes"
  }
}
- Executar a Aplicação: dotnet run --project CheckPoint5

## Executar Testes Unitários
Para rodar os testes unitários, execute o comando abaixo na raiz do projeto: dotnet test

## Contribuição
Contribuições são bem-vindas! Se você deseja contribuir com o projeto, siga os passos abaixo:

- Faça um fork do repositório.
- Crie uma branch para a nova feature (git checkout -b feature/MinhaFeature).
- Commit suas alterações (git commit -m 'Adiciona nova feature').
- Faça o push para a branch (git push origin feature/MinhaFeature).
- Abra um Pull Request.

## Licença
Este projeto está licenciado sob a Licença MIT. Consulte o arquivo LICENSE para obter mais informações.









