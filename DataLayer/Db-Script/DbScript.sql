--added on 20-12-2023 by PP-------------------------------------------START---------------------------------------------

Create database RS_ERP

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

insert into UserMst values('11','pushti.prajapati@reynasolutions.com','abc','1','0','1','2023-20-22 15:46:41.133','0','2023-20-22 15:46:41.133');

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


--added on 22-12-2023 by PP-------------------------------------------START---------------------------------------------

drop table UserMst;

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'UserMst')
BEGIN 
	Create table dbo.UserMst(
			ID int IDENTITY(1,1) Primary Key NOT NULL,
			EmployeeID int NOT NULL,
			Image nvarchar(MAX) NULL,
			FirstName nvarchar(50) NOT NULL,
			MiddleName nvarchar(50) NOT NULL,
			LastName nvarchar(50) NOT NULL,
			Email nvarchar(50) NOT NULL,
			Gender nvarchar(30) NOT NULL,
			DateOfBirth DateTime NOT NULL,
			EmergencyContactName nvarchar(50) NOT NULL,
			EmergencyContactNo nvarchar(30) NOT NULL,
			Password nvarchar(50) NOT NULL,
			MartialStatus nvarchar(50) NOT NULL,
			PermanentAddress nvarchar(100) NOT NULL,
			PermanentAddressPostalCode nvarchar(10)  NULL,
			CurrentAddress nvarchar(100) NOT NULL,
			CurrentAddressPostalCode nvarchar(10)  NULL,
			EmployeeTypeId int  Null,
			CompanyName nvarchar(100)  NULL,
			DepartmentId int  NULL,
			DesignationId int  NULL,
			OfferDate DateTime Null,
			ExitDate DateTime Null,
			ComapanyAddress  nvarchar(100)  NULL,
			ProbationPeriod int NULL,
			NoticePeriod int NULL,
			RoleId int NULL,
			ReportingManagerId int NULL,
			BankName  nvarchar(50)  NULL,
			NameOnTheAccount nvarchar(50)  NULL,
			AccountNo nvarchar(50) NULL,
			BankBranch nvarchar(50) NULL,
			BankIfsc nvarchar(50)  NULL,
			PFAccountNo nvarchar(50)  NULL,
			AadharNo nvarchar(50)  NULL,
			PANNO nvarchar(50)  NULL,
			MonthlySalary decimal(13, 2) Null,
			PFAmount decimal(13, 2) Null,
			ESIAmount decimal(13, 2) Null,
			PTAmount decimal(13, 2)  Null,
			PF_Applicable bit NULL,
			PT_Applicable bit NULL,
			ESI_Applicable bit NULL,
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
			TABLE_NAME = 'EmployeeTypeMst')
BEGIN 
	Create table dbo.EmployeeTypeMst(
			EmployeeTypeId int identity(1,1) primary key NOT NULL,
			EmployeeType nvarchar(50) NOT NULL,
			IsActive bit NOT NULL,
			IsDelete bit  null,
			CreatedBy int NOT NULL,
			CreatedDate datetime NOT NULL,
			UpdatedBy int  null,
			UpdatedDate datetime  null,
			);
	PRINT 'EmployeeTypeMst Table Created' 
END
ELSE
BEGIN 
	PRINT 'EmployeeTypeMst Table Already Exist' 
END


IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  
			TABLE_NAME = 'RoleMst')
BEGIN 
	Create table dbo.RoleMst(
			RoleId int identity(1,1) primary key NOT NULL,
			RoleType nvarchar(50) NOT NULL,
			IsActive bit NOT NULL,
			IsDelete bit  null,
			CreatedBy int NOT NULL,
			CreatedDate datetime NOT NULL,
			UpdatedBy int  null,
			UpdatedDate datetime  null,
			);
	PRINT 'RoleMst Table Created' 
END
ELSE
BEGIN 
	PRINT 'RoleMst Table Already Exist' 
END

INSERT INTO [dbo].[UserMst]
           ([EmployeeID],[Image],[FirstName],[MiddleName],[LastName],[Email],[Gender],[DateOfBirth],[EmergencyContactName],[EmergencyContactNo],[Password],[MartialStatus],[PermanentAddress],[PermanentAddressPostalCode],[CurrentAddress],[CurrentAddressPostalCode],[EmployeeTypeId],[CompanyName],[DepartmentId],[DesignationId],[OfferDate],[ExitDate],[ComapanyAddress],[ProbationPeriod],[NoticePeriod],[RoleId],[ReportingManager],[BankName],[NameOnTheAccount],[AccountNo],[BankBranch],[BankIfsc],[PFAccountNo],
		   [AadharNo],[PANNO],[MonthlySalary] ,[PFAmount],[ESIAmount],[PTAmount],[PF_Applicable],[PT_Applicable] ,[ESI_Applicable] ,[IsActive],[IsDelete],[CreatedBy],[CreatedDate] ,[UpdatedBy],[UpdatedDate])
     VALUES
          ('11','C:\Users\Reyna\Pictures\Saved Pictures\11.jpg','abc','abc','abc','pushti.prajapati@reynasolutions.com','Female','2023-12-22 14:40:32.640','abc','123456','abc','unmarried','vadodara','345678','vadodara','345678','1','arche softronix','1','1','2023-12-22 14:40:32.640','2023-12-22 14:40:32.640','vadodara','0','0','1','abc','xyz','abc','123456','vadodara','1234','1234',
		  '11234','1234','20000','123','123','123',1,1,1,1,0,'1','2023-12-22 14:40:32.640','0','');



--added on 22-12-2023 by PP-------------------------------------------END-----------------------------------------------
--executed on local by PP on 22-12-2023---------------------------------------------------------------------------------


--added on 26-12-2023 by PP-------------------------------------------START---------------------------------------------


IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  
			TABLE_NAME = 'ReportingManagerMst')
BEGIN 
	Create table dbo.ReportingManagerMst(
			ReportingManagerId int identity(1,1) primary key NOT NULL,
			ReportingManagerName nvarchar(100) NOT NULL,
			IsActive bit NOT NULL,
			IsDelete bit  null,
			CreatedBy int NOT NULL,
			CreatedDate datetime NOT NULL,
			UpdatedBy int  null,
			UpdatedDate datetime  null,
			);
	PRINT 'ReportingManagerMst Table Created' 
END
ELSE
BEGIN 
	PRINT 'ReportingManagerMst Table Already Exist' 
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  
			TABLE_NAME = 'ResignMst')
BEGIN 
	Create table dbo.ResignMst(
			ResignId int identity(1,1) primary key NOT NULL,
			EmployeeId int NOT NULL,
			DateOfResignation datetime NOT NULL,
			AttritionId int not null,
			Reason nvarchar(100) null,
			Region nvarchar(50) null,
			FinalDate  datetime  NULL,
			FinalStatus nvarchar(50) null,
			CreatedBy int NOT NULL,
			CreatedDate  datetime NOT NULL
			);
	PRINT 'ResignMst Table Created' 
END
ELSE
BEGIN 
	PRINT 'ResignMst Table Already Exist' 
END

IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  
			TABLE_NAME = 'AttritionTypeMst')
BEGIN 
	Create table dbo.AttritionTypeMst(
			AttritionTypeId int identity(1,1) primary key NOT NULL,
			AttritionTypeName nvarchar(30) NOT NULL,
			IsActive bit NOT NULL,
			IsDelete bit  NULL,
			CreatedBy int NOT NULL,
			CreatedDate datetime NOT NULL,
			UpdatedBy int  NULL,
			UpdatedDate datetime NULL
			);
	PRINT 'AttritionTypeMst Table Created' 
END
ELSE
BEGIN 
	PRINT 'AttritionTypeMst Table Already Exist' 
END




IF NOT EXISTS (SELECT * FROM   sys.columns WHERE  object_id = OBJECT_ID(N'dbo.UserMst') AND name = 'ContactNumber')
BEGIN
	ALTER TABLE UserMst add ContactNumber nvarchar(50) NULL;
END
ELSE
BEGIN
	PRINT 'ContactNumber Column Already Exist' 
END

IF NOT EXISTS (SELECT * FROM   sys.columns WHERE  object_id = OBJECT_ID(N'dbo.UserMst') AND name = 'EmployeeStatus')
BEGIN
	  ALTER TABLE UserMst add EmployeeStatus bit NULL;
END
ELSE
BEGIN
	PRINT 'EmployeeStatus Column Already Exist' 
END

IF NOT EXISTS (SELECT * FROM   sys.columns WHERE  object_id = OBJECT_ID(N'dbo.UserMst') AND name = 'JoiningDate')
BEGIN
	   ALTER TABLE UserMst add JoiningDate datetime NULL;
END
ELSE
BEGIN
	PRINT 'JoiningDate Column Already Exist' 
END


--added on 26-12-2023 by PP-------------------------------------------END-----------------------------------------------
--executed on local by PP on 26-12-2023---------------------------------------------------------------------------------


--added on 27-12-2023 by PP-------------------------------------------START---------------------------------------------


IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  
			TABLE_NAME = 'HolidaysMst')
BEGIN 
	Create table dbo.HolidaysMst(
			HolidayId int IDENTITY(1,1) Primary Key NOT NULL,
			Name nvarchar(100) not null,
			Date datetime not null,
			Day nvarchar(50) not null,
			IsActive bit NOT NULL,
			IsDelete bit  NULL,
			CreatedBy int NOT NULL,
			CreatedDate datetime NOT NULL,
			UpdatedBy int  NULL,
			UpdatedDate datetime NULL
			);
	PRINT 'HolidaysMst Table Created' 
END
ELSE
BEGIN 
	PRINT 'HolidaysMst Table Already Exist' 
END

--added on 27-12-2023 by PP-------------------------------------------END-----------------------------------------------
--executed on local by PP on 27-12-2023---------------------------------------------------------------------------------