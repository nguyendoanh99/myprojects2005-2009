

select * from mastercard
select * from visacard

select * from mastercardbalance
select * from visacardbalance

Select * From MasterCard  
Where Code = 0x4f8d58c3ae4a1f46cc334c3f50477db1aba12469 
And datediff(s, ExpiredDate, @ngayhethan) = 0 
And datediff(s, ExpiredDate, getDate()) < 0


declare @a varchar
set @a = N'0xa12e913284be46e89e7961adbe5843050485c80c'

select cast(0xa12e913284be46e89e7961adbe5843050485c80c as varbinary)
SELECT CAST(CAST(0x41 AS nvarchar) AS varbinary)

SELECT CAST(CAST(@a AS nvarchar) AS varbinary)

SELECT CAST('a12e913284be46e89e7961adbe5843050485c80c' AS varbinary)

Select * From VISACARD
Where Code = 0xEBCDCA01C986FE84D65B88B4CF9635FDBF11476E

Select * From Mastercard Where Code = 0x4f8d58c3ae4a1f46cc334c3f50477db1aba12469 
and datediff(s, ExpiredDate, '20090101') = 0 
And datediff(s, ExpiredDate, getDate()) < 0 

Select * From MasterCard Where Code = 0x4f8d58c3ae4a1f46cc334c3f50477db1aba12469
And datediff(s, ExpiredDate,'20090101') < 0 
And datediff(s, ExpiredDate, getDate()) < 0

Select * From MasterCard Where Code = 0x4f8d58c3ae4a1f46cc334c3f50477db1aba12469 
And datediff(s, ExpiredDate,'01/01/2009') = 0 
And datediff(s, ExpiredDate, getDate()) < 0

INSERT INTO [CardSystem].[dbo].[VisaCard]
           ([No]
           ,[Owner]
           ,[Code]
           ,[ExpiredDate])
     VALUES
           (5
           ,'Nguyen Hue Nghi'
           ,0x388390190020399224155114110146462191352241415659127
           ,'20090101')

update mastercard
set code = 0x4f8d58c3ae4a1f46cc334c3f50477db1aba12469
, expireddate = '20091221'
where no = 1

update mastercard
set code = 0x67f0c7649b9574decea8740bb80b15615649e0c0
where no = 2

update mastercard
set code = 0xdc79c154a26888f69157f1361ac16739a753ad0e
where no = 3

update mastercard
set code = 0xabadfa12fd24d58acff89d645efcd25650b26297
where no = 4

update visacard
set code = 0x26535abe00cb63e09b726e922edb87e00e9c3b7f
where no = 1

update visacard
set code = 0x5dd6989e12c3a7d4da7cc5712f0199f7026525ad
where no = 2

update visacard
set code = 0xb8b255e86d57c9fbd58faeac509e40b9d669baec
where no = 3

update visacard
set code = 0x96502878dbbc94af613c46174c592091db45b028
where no = 4


update mastercard
set code = 0x4f8d58c3ae4a1f46cc334c3f50477db1aba12469
, expireddate = '20091221'
where no = 1



--BALANCE SÝTEM
update mastercardBALANCE
set code = 0x4f8d58c3ae4a1f46cc334c3f50477db1aba12469
, expireddate = '20091221'
where no = 1

update mastercardBALANCE
set code = 0x67f0c7649b9574decea8740bb80b15615649e0c0
where no = 2

update mastercardBALANCE
set code = 0xdc79c154a26888f69157f1361ac16739a753ad0e
where no = 3

update mastercardBALANCE
set code = 0xabadfa12fd24d58acff89d645efcd25650b26297
where no = 4

update visacardBALANCE
set code = 0x26535abe00cb63e09b726e922edb87e00e9c3b7f
where no = 1

update visacardBALANCE
set code = 0x5dd6989e12c3a7d4da7cc5712f0199f7026525ad
where no = 2

update visacardBALANCE
set code = 0xb8b255e86d57c9fbd58faeac509e40b9d669baec
where no = 3

update visacardBALANCE
set code = 0x96502878dbbc94af613c46174c592091db45b028
where no = 4
