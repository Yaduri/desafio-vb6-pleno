USE XYZ_Cartoes;
GO

SET NOCOUNT ON;

-- Gera 256 linhas seguras combinando cross joins
WITH L0 AS (SELECT 1 AS C UNION ALL SELECT 1),
     L1 AS (SELECT 1 AS C FROM L0 AS A CROSS JOIN L0 AS B),
     L2 AS (SELECT 1 AS C FROM L1 AS A CROSS JOIN L1 AS B),
     L3 AS (SELECT 1 AS C FROM L2 AS A CROSS JOIN L2 AS B),
     Numeros AS (SELECT TOP (256) ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS N FROM L3)
INSERT INTO Transacoes (Numero_Cartao, Valor_Transacao, Data_Transacao, Descricao, Status_Transacao)
SELECT 
    RIGHT('4000000000000000' + CAST(ABS(CHECKSUM(NEWID())) % 1000000000000 AS VARCHAR(16)), 16) AS Numero_Cartao,
    
    CAST(ROUND((ABS(CHECKSUM(NEWID())) % 4935) + 15 + (ABS(CHECKSUM(NEWID())) % 100) / 100.0, 2) AS DECIMAL(18,2)) AS Valor_Transacao,
    
    DATEADD(MINUTE, -(ABS(CHECKSUM(NEWID())) % (180 * 1440)), GETDATE()) AS Data_Transacao,
    
    CASE (ABS(CHECKSUM(NEWID())) % 10)
        WHEN 0 THEN 'Supermercado Central'
        WHEN 1 THEN 'Posto de Combustivel Shell'
        WHEN 2 THEN 'Restaurante e Churrascaria'
        WHEN 3 THEN 'Assinatura Servico Streaming'
        WHEN 4 THEN 'Passagem Aerea Latam'
        WHEN 5 THEN 'Farmacia Drogasil'
        WHEN 6 THEN 'Eletronicos Kabum'
        WHEN 7 THEN 'Loja de Roupas Zara'
        WHEN 8 THEN 'Oficina Mecanica AutoCar'
        ELSE 'Hospedagem Booking.com'
    END AS Descricao,
    
    CASE (ABS(CHECKSUM(NEWID())) % 3)
        WHEN 0 THEN 'Aprovada'
        WHEN 1 THEN 'Pendente'
        ELSE 'Cancelada'
    END AS Status_Transacao
FROM Numeros;
GO