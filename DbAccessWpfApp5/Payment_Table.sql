CREATE TABLE Payment
(PaymentCD uniqueidentifier NOT NULL
,Title nvarchar(100) NOT NULL
,Date date NOT NULL
,Price int NOT NULL
,Constraint Payment_PrimaryKey Primary Key NonClustered(PaymentCD)

) 
GO

