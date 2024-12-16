-- Transaction Table
CREATE TABLE Transactions (
	Id INT IDENTITY(1,1) constraint pk_tranNumber PRIMARY KEY,
    From_Account VARCHAR(50),
    To_Account VARCHAR(50),
    Transaction_Time DATETIME,
    Amount_Debited DECIMAL(10, 2),
    From_Account_Balance DECIMAL(10, 2),
    To_Account_Balance DECIMAL(10, 2),
    Details_Link VARCHAR(255)
);
