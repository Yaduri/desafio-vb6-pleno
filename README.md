# XYZ Administradora de Cartões - Gestão de Transações Financeiras

Solução desenvolvida para o Desafio Técnico de Desenvolvedor Pleno. O sistema realiza o gerenciamento completo (CRUD), paginação eficiente, categorização em banco de dados e exportação de relatórios consolidados em Excel.

---

## 🛠️ Tecnologias e Recursos Utilizados

- **Linguagem / Framework:** VB.NET (.NET 10 / Windows Forms)
- **Banco de Dados:** Microsoft SQL Server
- **Acesso a Dados:** ADO.NET (`Microsoft.Data.SqlClient`) com Stored Procedures otimizadas
- **Manipulação de Planilhas:** `ClosedXML` (Geração nativa de arquivos `.xlsx` sem dependência de automação COM/Office)
- **Log de Erros:** Módulo de auditoria com gravação de stack trace em arquivo de log diário

---

## 🏛️ Arquitetura e Decisões de Projeto

- **Separação de Camadas:** Interface desacoplada da camada de persistência (`TransacaoRepository.vb`) e rotinas de log centralizadas (`Logger.vb`).
- **Performance & Paginação:** A paginação de dados é realizada diretamente na camada de banco de dados (`sp_ListarTransacoesPaginadas`) via `OFFSET / FETCH`, trafegando apenas o conjunto de registros da página ativa para evitar sobrecarga de memória.
- **Regras de Negócio e Integridade:**
  - Validação de 16 dígitos obrigatórios no cartão e valores monetários positivos.
  - Bloqueio rígido de edição para transações com status **Aprovada**, aplicado tanto na interface (bloqueio visual de campos) quanto na camada de persistência.
  - Confirmação explícita de exclusão via modal.

---

## 🗄️ Estrutura do Banco de Dados

- **Tabela:** `Transacoes` (com constraints de integridade e índices não-clusterizados cobrindo filtros).
- **Scalar Function (`fn_CategorizarTransacao`):** Categoriza transações por faixa de valor (`Premium`, `Alta`, `Média`, `Baixa`).
- **Table-Valued Function (`fn_ObterTransacoesCategorizadas`):** Retorna transações categorizadas por período consumindo a Scalar Function.
- **Stored Procedure (`sp_TotalizarTransacoes`):** Agrupamento por cartão/status com agregação de soma e contagem.
- **Stored Procedure (`sp_ListarTransacoesPaginadas`):** Busca com múltiplos filtros opcionais e retorno de totalizador via parâmetro `OUTPUT`.
- **View (`vw_TransacoesConsolidadas`):** Consolidação com campos derivados de ano, mês e categoria para relatórios.

---

## 🚀 Como Executar o Projeto

### 1. Pré-requisitos
- Visual Studio 2022+ com suporte a .NET Desktop.
- Microsoft SQL Server (2016 ou superior).

### 2. Configuração do Banco de Dados
1. Abra o arquivo `Database/script_database.sql` no SQL Server Management Studio (SSMS).
2. Execute o script para criar o banco de dados `XYZ_Cartoes`, tabelas, procedures, funções e carga inicial de testes.

### 3. Configuração da Conexão
Verifique o arquivo `App.config` na raiz do projeto e ajuste a connection string caso utilize uma instância nomeada (ex: `localhost\SQLEXPRESS`):

```xml
<connectionStrings>
  <add name="SqlConnectionString" 
       connectionString="Server=localhost;Database=XYZ_Cartoes;Trusted_Connection=True;TrustServerCertificate=True;" 
       providerName="Microsoft.Data.SqlClient" />
</connectionStrings>