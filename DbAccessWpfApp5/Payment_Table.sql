--新しくデータを作成してコピーする
select * into Payment_20201019 from Payment

--新しく作ったテーブルのデータを確認する
select * from Payment_20201019

Drop Table Payment
Go

CREATE TABLE Payment
(PaymentCD uniqueidentifier NOT NULL
,Title nvarchar(100) NOT NULL
,Date date NOT NULL
,Price int NOT NULL
,Constraint Payment_PrimaryKey Primary Key NonClustered(PaymentCD)
) 
GO

select * from Payment

insert into Payment(PaymentCD,Title,Date,Price)
select PaymentCD,Title,Date,Price from Payment_20201019

select * from Payment

