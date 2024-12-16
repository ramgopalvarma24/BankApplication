CREATE TABLE Accounts (
    AccountNumber INT IDENTITY(1,1)  constraint pk_accountNumber PRIMARY KEY,      
    AccountHolderName NVARCHAR(100),   
    Balance DECIMAL(18, 2)      
);