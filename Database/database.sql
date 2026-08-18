CREATE DATABASE XYZ_Cartoes;
USE XYZ_Cartoes;

-- 1. Tabela principal de transações com campos obrigatórios
CREATE TABLE Transacoes (
    Id_Transacao BIGINT IDENTITY(1,1) PRIMARY KEY,
    Numero_Cartao VARCHAR(16) NOT NULL,
    Valor_Transacao DECIMAL(18,2) NOT NULL,
    Data_Transacao DATETIME NOT NULL DEFAULT GETDATE(),
    Descricao VARCHAR(255) NOT NULL,
    Status_Transacao VARCHAR(20) NOT NULL,
    CONSTRAINT CK_Valor_Positivo CHECK (Valor_Transacao > 0),
    CONSTRAINT CK_Status_Valido CHECK (Status_Transacao IN ('Aprovada', 'Pendente', 'Cancelada')),
    CONSTRAINT CK_Numero_Cartao_Len CHECK (LEN(Numero_Cartao) = 16)
);
GO

-- 2. Stored Procedure
CREATE OR ALTER PROCEDURE sp_TotalizarTransacoes
    @Data_Inicial DATETIME,
    @Data_Final DATETIME,
    @Status_Transacao VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        Numero_Cartao,
        SUM(Valor_Transacao) AS Valor_Total,
        COUNT(1) AS Quantidade_Transacoes,
        Status_Transacao
    FROM Transacoes
    WHERE Data_Transacao >= @Data_Inicial
      AND Data_Transacao <= @Data_Final
      AND (@Status_Transacao IS NULL OR Status_Transacao = @Status_Transacao)
    GROUP BY Numero_Cartao, Status_Transacao
    ORDER BY Valor_Total DESC;
END;
GO

-- 3. Scalar Function
CREATE OR ALTER FUNCTION dbo.fn_CategorizarTransacao (@Valor DECIMAL(18,2))
RETURNS VARCHAR(20)
AS
BEGIN
    DECLARE @Categoria VARCHAR(20);

    IF @Valor > 2000.00
        SET @Categoria = 'Premium';
    ELSE IF @Valor >= 1000.00
        SET @Categoria = 'Alta';
    ELSE IF @Valor >= 500.00
        SET @Categoria = 'Média';
    ELSE
        SET @Categoria = 'Baixa';

    RETURN @Categoria;
END;
GO

-- 3. Table-Valued Function (TVF)
CREATE OR ALTER FUNCTION dbo.fn_ObterTransacoesCategorizadas (
    @Data_Inicial DATETIME,
    @Data_Final DATETIME
)
RETURNS TABLE
AS
RETURN (
    SELECT 
        Id_Transacao,
        Numero_Cartao,
        Valor_Transacao,
        Data_Transacao,
        Descricao,
        Status_Transacao,
        dbo.fn_CategorizarTransacao(Valor_Transacao) AS Categoria
    FROM Transacoes
    WHERE Data_Transacao >= @Data_Inicial 
      AND Data_Transacao <= @Data_Final
);
GO

-- 4. View consolidada
CREATE OR ALTER VIEW vw_TransacoesConsolidadas
AS
SELECT 
    T.Id_Transacao,
    T.Numero_Cartao,
    T.Valor_Transacao,
    T.Data_Transacao,
    T.Status_Transacao,
    T.Descricao,
    dbo.fn_CategorizarTransacao(T.Valor_Transacao) AS Categoria,
    YEAR(T.Data_Transacao) AS Ano,
    MONTH(T.Data_Transacao) AS Mes
FROM Transacoes T;
GO

-- Índice para otimizar filtros de busca e paginação
CREATE NONCLUSTERED INDEX IX_Transacoes_Filtros 
ON Transacoes (Data_Transacao, Status_Transacao, Numero_Cartao)
INCLUDE (Valor_Transacao, Descricao);
GO


-- Paginação para o Grid
CREATE OR ALTER PROCEDURE sp_ListarTransacoesPaginadas
    @Numero_Cartao VARCHAR(16) = NULL,
    @Data_Inicial DATETIME = NULL,
    @Data_Final DATETIME = NULL,
    @Valor_Transacao DECIMAL(18,2) = NULL,
    @Status_Transacao VARCHAR(20) = NULL,
    @PageNumber INT = 1,
    @PageSize INT = 20,
    @TotalRegistros INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT @TotalRegistros = COUNT(1)
    FROM Transacoes
    WHERE (@Numero_Cartao IS NULL OR Numero_Cartao = @Numero_Cartao)
      AND (@Data_Inicial IS NULL OR Data_Transacao >= @Data_Inicial)
      AND (@Data_Final IS NULL OR Data_Transacao <= @Data_Final)
      AND (@Valor_Transacao IS NULL OR Valor_Transacao = @Valor_Transacao)
      AND (@Status_Transacao IS NULL OR Status_Transacao = @Status_Transacao);

    SELECT 
        Id_Transacao,
        Numero_Cartao,
        Valor_Transacao,
        Data_Transacao,
        Descricao,
        Status_Transacao
    FROM Transacoes
    WHERE (@Numero_Cartao IS NULL OR Numero_Cartao = @Numero_Cartao)
      AND (@Data_Inicial IS NULL OR Data_Transacao >= @Data_Inicial)
      AND (@Data_Final IS NULL OR Data_Transacao <= @Data_Final)
      AND (@Valor_Transacao IS NULL OR Valor_Transacao = @Valor_Transacao)
      AND (@Status_Transacao IS NULL OR Status_Transacao = @Status_Transacao)
    ORDER BY Data_Transacao DESC, Id_Transacao DESC
    OFFSET (@PageNumber - 1) * @PageSize ROWS
    FETCH NEXT @PageSize ROWS ONLY;
END;
GO



-- Dados iniciais
INSERT INTO Transacoes (Numero_Cartao, Valor_Transacao, Data_Transacao, Descricao, Status_Transacao)
VALUES 
('1234567890123456', 150.00, DATEADD(DAY, -2, GETDATE()), 'Supermercado Central', 'Aprovada'),
('1234567890123456', 2500.00, DATEADD(DAY, -5, GETDATE()), 'Notebook Gamer', 'Aprovada'),
('9876543210987654', 750.50, DATEADD(DAY, -10, GETDATE()), 'Revisao Veicular', 'Pendente'),
('9876543210987654', 1200.00, DATEADD(DAY, -15, GETDATE()), 'Passagem Aerea', 'Cancelada'),
('5555444433332222', 320.00, DATEADD(DAY, -25, GETDATE()), 'Jantar Restaurante', 'Aprovada');
GO