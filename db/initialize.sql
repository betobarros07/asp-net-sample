CREATE TABLE [PersonType](
	[Id] SMALLINT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Code] VARCHAR(128) UNIQUE NOT NULL,
	[Description] VARCHAR(256) NOT NULL
);

INSERT INTO [PersonType]([Code], [Description])
VALUES ('Person', 'Person'), ('Company', 'Company');

CREATE TABLE [Person](
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[FullName] VARCHAR(512) NOT NULL,
	[DocumentNumber] VARCHAR(14) NOT NULL,
	[PersonTypeId] SMALLINT FOREIGN KEY REFERENCES [PersonType]([Id]) NOT NULL,
	[CreatedAt] DATETIME DEFAULT(GETDATE()) NOT NULL,
	[CreatedByUserId] INT NOT NULL,
	[UpdatedAt] DATETIME NULL,
	[UpdatedByUserId] INT NULL,
	[DeletedAt] DATETIME NULL,
	[DeletedByUserId] INT NULL,
);

CREATE TABLE [CompanyType](
	[Id] SMALLINT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Code] VARCHAR(128) UNIQUE NOT NULL,
	[Description] VARCHAR(256) NOT NULL
);

INSERT INTO [CompanyType]([Code], [Description])
VALUES ('ContractOwner', 'Contract Owner'), ('ContractEmployee', 'Contract Employee');

CREATE TABLE [Company](
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[CompanyTypeId] SMALLINT FOREIGN KEY REFERENCES [CompanyType]([Id]) NOT NULL,
	[CreatedAt] DATETIME DEFAULT(GETDATE()) NOT NULL,
	[CreatedByUserId] INT NOT NULL,
	[UpdatedAt] DATETIME NULL,
	[UpdatedByUserId] INT NULL,
	[DeletedAt] DATETIME NULL,
	[DeletedByUserId] INT NULL
);

CREATE TABLE [User](
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[PersonId] INT FOREIGN KEY REFERENCES [Person]([Id]) NOT NULL,
	[CompanyId] INT FOREIGN KEY REFERENCES [Company]([Id]) NULL,
	[Username] VARCHAR(64) UNIQUE NOT NULL,
	[Password] VARCHAR(256) NOT NULL,
	[CreatedAt] DATETIME DEFAULT(GETDATE()) NOT NULL,
	[CreatedByUserId] INT FOREIGN KEY REFERENCES [User]([Id]) NOT NULL,
	[UpdatedAt] DATETIME NULL,
	[UpdatedByUserId] INT FOREIGN KEY REFERENCES [User]([Id]) NULL,
	[DeletedAt] DATETIME NULL,
	[DeletedByUserId] INT FOREIGN KEY REFERENCES [User]([Id]) NULL
);

ALTER TABLE [Person]
ADD FOREIGN KEY ([CreatedByUserId]) REFERENCES [User]([Id]);

ALTER TABLE [Person]
ADD FOREIGN KEY ([UpdatedByUserId]) REFERENCES [User]([Id]);

ALTER TABLE [Person]
ADD FOREIGN KEY ([DeletedByUserId]) REFERENCES [User]([Id]);

ALTER TABLE [Company]
ADD FOREIGN KEY ([CreatedByUserId]) REFERENCES [User]([Id]);

ALTER TABLE [Company]
ADD FOREIGN KEY ([UpdatedByUserId]) REFERENCES [User]([Id]);

ALTER TABLE [Company]
ADD FOREIGN KEY ([DeletedByUserId]) REFERENCES [User]([Id]);

CREATE TABLE [CompanyContract](
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[CompanyId] INT  FOREIGN KEY REFERENCES [Company]([Id]) NOT NULL,
	[ContractId] INT  FOREIGN KEY REFERENCES [Company]([Id]) NOT NULL,
	[DueDay] SMALLINT NOT NULL,
	[PaymentDay] SMALLINT NOT NULL,
	[EarnsPerHour] DECIMAL NOT NULL,
	[ClosedHours] SMALLINT NULL,
	[AllowExtraHours] BIT DEFAULT(0) NOT NULL,
	[CreatedAt] DATETIME DEFAULT(GETDATE()) NOT NULL,
	[CreatedByUserId] INT FOREIGN KEY REFERENCES [User]([Id]) NOT NULL,
	[DeletedAt] DATETIME NULL,
	[DeletedByUserId] INT FOREIGN KEY REFERENCES [User]([Id]) NULL
);

CREATE TABLE [CompanyContractPaymentStatus](
	[Id] SMALLINT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[Code] VARCHAR(128) UNIQUE NOT NULL,
	[Description] VARCHAR(256) NOT NULL
);

INSERT INTO [CompanyContractPaymentStatus]([Code], [Description])
VALUES ('Opened', 'Opened'), ('Closed', 'Closed'), ('Overdue', 'Overdue'), ('WaitingResponse', 'WaitingResponse'), ('Approved', 'Approved'), ('Rejected', 'Rejected');

CREATE TABLE [CompanyContractPayment](
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[CompanyContractId] INT FOREIGN KEY REFERENCES [CompanyContract]([Id]) NOT NULL,
	[CompanyContractPaymentStatusId] SMALLINT FOREIGN KEY REFERENCES [CompanyContractPaymentStatus]([Id]) NOT NULL,
	[DueDay] SMALLINT NOT NULL,
	[PaymentDay] SMALLINT NOT NULL,
	[EarnsPerHour] DECIMAL NOT NULL,
	[ClosedHours] SMALLINT NULL,
	[AllowExtraHours] BIT DEFAULT(0) NOT NULL,
	[MonthSalary] DECIMAL NULL,
	[PreviewSalary] DECIMAL NOT NULL,
	[UpdatedAt] DATETIME NULL,
	[UpdatedByUserId] INT FOREIGN KEY REFERENCES [User]([Id]) NULL
);
