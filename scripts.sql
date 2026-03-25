-- ============================================
-- Criar banco de dados
-- ============================================
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'UserManagerDb')
BEGIN
    CREATE DATABASE UserManagerDb;
END
GO

USE UserManagerDb;
GO

-- ============================================
-- Criar tabela Usuario
-- ============================================
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Usuario' AND xtype='U')
BEGIN
    CREATE TABLE Usuario (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Nome NVARCHAR(150) NOT NULL,
        ValorHora DECIMAL(10,2) NOT NULL,
        DataCadastro DATETIME NOT NULL DEFAULT GETDATE(),
        Ativo BIT NOT NULL
    );
END
GO

-- ============================================
-- Inserir dados de exemplo (opcional)
-- ============================================
IF NOT EXISTS (SELECT 1 FROM Usuario)
BEGIN
    INSERT INTO Usuario (Nome, ValorHora, Ativo)
    VALUES 
        ('Marcelo Souza', 80.25, 1),
        ('Camila Ribeiro', 76.00, 1),
        ('Bárbara Silva', 20.17, 1);
END
GO