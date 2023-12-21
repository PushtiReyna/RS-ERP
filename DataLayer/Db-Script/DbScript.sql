--added on 20-12-2023 by PP-------------------------------------------START---------------------------------------------

Create database RS_ERP

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'UserMst')
BEGIN 
	Create table dbo.UserMst(
			ID int IDENTITY(1,1) Primary Key NOT NULL,
			EmployeeID int NOT NULL,
			Image nvarchar(MAX) NOT NULL,
			FullName nvarchar(100) NOT NULL,
			Email nvarchar(50) NOT NULL,
			Gender nvarchar(30) NOT NULL,
			DateOfBirth DateTime NOT NULL,
			EmergencyContactName nvarchar(50) NOT NULL,
			EmergencyContactNo nvarchar(30) NOT NULL,
			Password nvarchar(50) NOT NULL,
			PermanentAddress nvarchar(100) NOT NULL,
			PermanentAddressPostalCode nvarchar(10)  NULL,
			CurrentAddress nvarchar(100) NOT NULL,
			CurrentAddressPostalCode nvarchar(10)  NULL,
			CompanyName nvarchar(50) NOT NULL,
			OfferDate DateTime Null,
			ExitDate DateTime Null,
			ComapanyAddress  nvarchar(100) NOT NULL,
			ProbationPeriod int NULL,
			NoticePeriod int NULL,
			ReportingManager int NULL,
			BankName  nvarchar(50) NOT NULL,
			NameOnTheAccount nvarchar(50) NOT NULL,
			PFAccountNo nvarchar(50) NOT NULL,
			AadharNo nvarchar(50) NOT NULL,
			MonthlySalary decimal(13, 2) Null,
			PFAmount decimal(13, 2) Null,
			ESIAmount decimal(13, 2) Null,
			PF_Applicable bit NULL,
			PT_Applicable bit NULL,
			ESI_Applicable bit NULL,
			DepartmentId int NOT NULL,
			DesignationId int NOT NULL,
			IsActive bit NOT NULL,
			IsDelete bit NULL,
			CreatedBy int NOT NULL,
			CreatedDate DateTime NOT NULL,
			UpdatedBy int NULL,
			UpdatedDate DateTime NULL,
	);
	PRINT 'UserMst Table Created' 
END
ELSE
BEGIN 
	PRINT 'UserMst Table Already Exist' 
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  
			TABLE_NAME = 'TokenMst')
BEGIN 
	Create table dbo.TokenMst(
			TokenId int identity(1,1) primary key NOT NULL,
			EmployeeId int NOT NULL,
			Token nvarchar(max) NOT NULL,
			TokenExpiryTime datetime NOT NULL,
			RefreshToken nvarchar(max) NOT NULL,
			RefreshTokenExpiryTime datetime NOT NULL,
			CreatedDate datetime NOT NULL,
			UpdatedDate datetime NULL
			);
	PRINT 'TokenMst Table Created' 
END
ELSE
BEGIN 
	PRINT 'TokenMst Table Already Exist' 
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  
			TABLE_NAME = 'DesignationMst')
BEGIN 
	Create table dbo.DesignationMst(
			DesignationId int identity(1,1) primary key NOT NULL,
			DesignationName nvarchar(30) NOT NULL,
			IsActive bit NOT NULL,
			IsDelete bit  NULL,
			CreatedBy int NOT NULL,
			CreatedDate datetime NOT NULL,
			UpdatedBy int  NULL,
			UpdatedDate datetime NULL
			);
	PRINT 'DesignationMst Table Created' 
END
ELSE
BEGIN 
	PRINT 'DesignationMst Table Already Exist' 
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  
			TABLE_NAME = 'DepartmentMst')
BEGIN 
	Create table dbo.DepartmentMst(
	        DepartmentId int identity(1,1) primary key NOT NULL,
			DepartmentName nvarchar(30) NOT NULL,
			IsActive bit NOT NULL,
			IsDelete bit NULL,
			CreatedBy int NOT NULL,
			CreatedDate datetime NOT NULL,
			UpdatedBy int NOT NULL,
			UpdatedDate datetime NULL
			);
	PRINT 'DepartmentMst Table Created' 
END
ELSE
BEGIN 
	PRINT 'DepartmentMst Table Already Exist' 
END

--added on 20-12-2023 by PP-------------------------------------------END-----------------------------------------------
--executed on local by PP on 20-12-2023---------------------------------------------------------------------------------




IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'UserMst')
BEGIN 
	Create table dbo.UserMst(
			ID int IDENTITY(1,1) Primary Key NOT NULL,
			EmployeeID int NOT NULL,
			Email nvarchar(50) NOT NULL,
			Password nvarchar(50) NOT NULL,
			IsActive bit  NULL,
			IsDelete bit NULL,
			CreatedBy int  NULL,
			CreatedDate DateTime  NULL,
			UpdatedBy int NULL,
			UpdatedDate DateTime NULL
			);
	PRINT 'UserMst Table Created' 
END
ELSE
BEGIN 
	PRINT 'UserMst Table Already Exist' 
END

insert into UserMst values('11','pushti.prajapati@reynasolutions.com','abc','1','0','1',GETDATE(),'0',GETDATE());