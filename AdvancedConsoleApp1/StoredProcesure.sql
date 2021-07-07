Create Procedure Kj_Payment_SelectBy_Date
(@Date Date
) as 

select PaymentCD,Title,Date,Price 
from Payment with(nolock)
where Date = @Date

Go


sp_helptext Kj_Payment_SelectBy_Date

exec Kj_Payment_SelectBy_Date '2021-6-30'

