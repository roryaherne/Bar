/*
* 
* START OF BAR TABLES
*
*/

CREATE TABLE [dbo].[Units] (
    [UnitId] INT IDENTITY (1, 1) NOT NULL,
    [Title] NVARCHAR (128) NOT NULL,
    [ShortTitle] NVARCHAR (10) NULL,
    [Description] NVARCHAR (512) NULL,
    [BaseFactor] FLOAT NOT NULL,
    [DateCreated] DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    [CreatedById] NVARCHAR (128) NOT NULL,
	[DateModified] DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    [ModifiedById] NVARCHAR (128) NOT NULL,

	Constraint Pk_UnitsId PRIMARY KEY ([UnitId]),
	Constraint Fk_Units_CreatedBy FOREIGN KEY ([CreatedById]) REFERENCES AspNetUsers(Id),
	Constraint Fk_Units_ModifiedBy FOREIGN KEY ([ModifiedById]) REFERENCES AspNetUsers(Id)
);

GO

CREATE TABLE [dbo].[Places] (
    [PlaceId] INT IDENTITY (1, 1) NOT NULL,
    [Title] NVARCHAR (128) NOT NULL,
	[Description] NVARCHAR (512) NULL,
    [Capacity] INT NOT NULL,
	[Smoking] BIT NOT NULL DEFAULT 0,
	[DateCreated] DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    [CreatedById] NVARCHAR (128) NOT NULL,
	[DateModified] DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    [ModifiedById] NVARCHAR (128) NOT NULL,
    
	Constraint Pk_PlacesId PRIMARY KEY ([PlaceId]),
	Constraint Fk_Places_CreatedBy FOREIGN KEY ([CreatedById]) REFERENCES AspNetUsers(Id),
	Constraint Fk_Places_ModifiedBy FOREIGN KEY ([ModifiedById]) REFERENCES AspNetUsers(Id)
);

GO

CREATE TABLE [dbo].[ProductTypes] (
    [ProductTypeId] INT IDENTITY (1, 1) NOT NULL,
    [Title] NVARCHAR (128) NOT NULL,
    [Description] NVARCHAR (512) NULL,
	[Margin] FLOAT NOT NULL DEFAULT 0,
    [DateCreated] DATETIME NOT NULL,
    [CreatedById] NVARCHAR (128) NOT NULL,
	[DateModified] DATETIME NOT NULL,
    [ModifiedById] NVARCHAR (128) NOT NULL,
	
	Constraint Pk_ProductTypesId PRIMARY KEY ([ProductTypeId]),
	Constraint Fk_ProductTypes_CreatedBy FOREIGN KEY ([CreatedById]) REFERENCES AspNetUsers(Id),
	Constraint Fk_ProductTypes_ModifiedBy FOREIGN KEY ([ModifiedById]) REFERENCES AspNetUsers(Id)
);

GO

CREATE TABLE [dbo].[ProductStates] (
    [ProductStateId] INT IDENTITY (1, 1) NOT NULL,
    [Title] NVARCHAR (128) NOT NULL,
    [Description] NVARCHAR (512) NULL,
    [DateCreated] DATETIME NOT NULL,
    [CreatedById] NVARCHAR (128) NOT NULL,
	[DateModified] DATETIME NOT NULL,
    [ModifiedById] NVARCHAR (128) NOT NULL,
	
	Constraint Pk_ProductStatesId PRIMARY KEY ([ProductStateId]),
	Constraint Fk_ProductStates_CreatedBy FOREIGN KEY ([CreatedById]) REFERENCES AspNetUsers(Id),
	Constraint Fk_ProductStates_ModifiedBy FOREIGN KEY ([ModifiedById]) REFERENCES AspNetUsers(Id)
);

GO

CREATE TABLE [dbo].[OrderStates] (
    [OrderStateId] INT IDENTITY (1, 1) NOT NULL,
    [Title] NVARCHAR (128) NOT NULL,
    [Description] NVARCHAR (512) NULL,
    [DateCreated] DATETIME NOT NULL,
    [CreatedById] NVARCHAR (128) NOT NULL,
	[DateModified] DATETIME NOT NULL,
    [ModifiedById] NVARCHAR (128) NOT NULL,
	
	Constraint Pk_OrderStatesId PRIMARY KEY ([OrderStateId]),
	Constraint Fk_OrderStates_CreatedBy FOREIGN KEY ([CreatedById]) REFERENCES AspNetUsers(Id),
	Constraint Fk_OrderStates_ModifiedBy FOREIGN KEY ([ModifiedById]) REFERENCES AspNetUsers(Id)
);

GO

CREATE TABLE [dbo].[Stocks] (
    [StockId]     INT            IDENTITY (1, 1) NOT NULL,
    [Amount]      INT            NOT NULL,
    [Expires]     DATETIME       NOT NULL,
    [Delivered]   DATETIME       NOT NULL,
    [PurchPrice]  REAL           NOT NULL,
    [ProductId]   INT            NOT NULL,
    [DateCreated]       DATETIME       NOT NULL DEFAULT CURRENT_TIMESTAMP,
    [CreatedById]       NVARCHAR (128) NOT NULL,
	[DateModified]       DATETIME       NOT NULL,
    [ModifiedById]       NVARCHAR (128) NOT NULL,
	
	Constraint Pk_StocksId PRIMARY KEY ([StockId]),
	Constraint Fk_Stocks_CreatedBy FOREIGN KEY ([CreatedById]) REFERENCES AspNetUsers(Id),
	Constraint Fk_Stocks_ModifiedBy FOREIGN KEY ([ModifiedById]) REFERENCES AspNetUsers(Id),

);

GO

CREATE TABLE [dbo].[Products] (
    [ProductId] INT IDENTITY (1, 1) NOT NULL,
    [Title] NVARCHAR (128)  NOT NULL,
    [Description] NVARCHAR (512)  NULL,
    [ExperationPeriod] INT NOT NULL,
    [Image] VARBINARY (MAX) NULL,
	[Margin] FLOAT NOT NULL DEFAULT 0,
    [StockUnitId] INT NOT NULL,
    [ProductStateId] INT NOT NULL,
    [ProductTypeId] INT NOT NULL,
	[DateCreated] DATETIME NOT NULL,
    [CreatedById] NVARCHAR (128) NOT NULL,
	[DateModified] DATETIME NOT NULL,
    [ModifiedById] NVARCHAR (128) NOT NULL,

	Constraint Pk_ProductsId PRIMARY KEY ([ProductId]),
	Constraint Fk_Products_CreatedBy FOREIGN KEY ([CreatedById]) REFERENCES AspNetUsers(Id),
	Constraint Fk_Products_ModifiedBy FOREIGN KEY ([ModifiedById]) REFERENCES AspNetUsers(Id),

	Constraint Fk_Products_StockUnitId FOREIGN KEY ([StockUnitId]) REFERENCES Stocks(StockId),
	Constraint Fk_Products_ProductStateId FOREIGN KEY ([ProductStateId]) REFERENCES ProductStates(ProductStateId),
	Constraint Fk_Products_ProductTypeId FOREIGN KEY ([ProductTypeId]) REFERENCES ProductTypes(ProductTypeId)
);

ALTER TABLE Stocks
Add Constraint Fk_Stocks_ProductId FOREIGN KEY ([ProductId]) REFERENCES Products([ProductId])

GO

CREATE TABLE [dbo].[Invoices] (
	[InvoiceId] INT IDENTITY (1, 1) NOT NULL,
	[DateCreated] DATETIME NOT NULL,
    [CreatedById] NVARCHAR (128) NOT NULL,
	[DateModified] DATETIME NOT NULL,
    [ModifiedById] NVARCHAR (128) NOT NULL,
	
	Constraint Pk_InvoicesId PRIMARY KEY ([InvoiceId]),
	Constraint Fk_Invoices_CreatedBy FOREIGN KEY ([CreatedById]) REFERENCES AspNetUsers(Id),
	Constraint Fk_Invoices_ModifiedBy FOREIGN KEY ([ModifiedById]) REFERENCES AspNetUsers(Id)
);

GO

CREATE TABLE [dbo].[InvoicePositions] (
	[InvoiceId]      INT NOT NULL,
	[PosNr]      INT NOT NULL,
	[Amount]       FLOAT     NOT NULL,
	[Price]		   FLOAT NOT NULL,
	[ProductId]        INT NOT NULL,
	[ProductTitle]      NVARCHAR (128)  NOT NULL,
	[DateCreated]       DATETIME       NOT NULL,
    [CreatedById]       NVARCHAR (128) NOT NULL,
	[DateModified]       DATETIME       NOT NULL,
    [ModifiedById]       NVARCHAR (128) NOT NULL,
	
	Constraint Pk_InvoicePositionsId PRIMARY KEY ([InvoiceId], [PosNr]),
	Constraint Fk_InvoicePositions_InvoiceId FOREIGN KEY ([InvoiceId]) REFERENCES Invoices([InvoiceId]),
	Constraint Fk_InvoicePositions_CreatedBy FOREIGN KEY ([CreatedById]) REFERENCES AspNetUsers(Id),
	Constraint Fk_InvoicePositions_ModifiedBy FOREIGN KEY ([ModifiedById]) REFERENCES AspNetUsers(Id),

	Constraint Fk_InvoicePositions_ProductId FOREIGN KEY ([ProductId]) REFERENCES Products([ProductId])
);

GO

CREATE TABLE [dbo].[Orders] (
    [OrderId]      INT            IDENTITY (1, 1) NOT NULL,
	[Notes]			NVARCHAR (512)  NULL,
    [Amount]       FLOAT     NOT NULL,
	[Price]		   FLOAT NOT NULL,
    [OrderTime]    DATETIME       NOT NULL,
	[InvoiceId]    INT            NOT NULL,
	[InvoicePosId]    INT            NOT NULL,
    [ProductId]    INT            NOT NULL,
    [UnitId]       INT            NOT NULL,
    [PlaceId]      INT            NOT NULL,
    [OrderStateId] INT            NOT NULL,
	[DateCreated]       DATETIME       NOT NULL,
    [CreatedById]       NVARCHAR (128) NOT NULL,
	[DateModified]       DATETIME       NOT NULL,
    [ModifiedById]       NVARCHAR (128) NOT NULL,
	
	Constraint Pk_OrdersId PRIMARY KEY ([OrderId]),
	Constraint Fk_Orders_CreatedBy FOREIGN KEY ([CreatedById]) REFERENCES AspNetUsers(Id),
	Constraint Fk_Orders_ModifiedBy FOREIGN KEY ([ModifiedById]) REFERENCES AspNetUsers(Id),

	Constraint Fk_Orders_InvoicePosId FOREIGN KEY ([InvoiceId], [InvoicePosId]) REFERENCES InvoicePositions ([InvoiceId], [PosNr]),
	Constraint Fk_Orders_UnitId FOREIGN KEY ([UnitId]) REFERENCES Units([UnitId]),
	Constraint Fk_Orders_PlaceId FOREIGN KEY ([PlaceId]) REFERENCES Places([PlaceId]),
	Constraint Fk_Orders_OrderStateId FOREIGN KEY ([OrderStateId]) REFERENCES OrderStates([OrderStateId]),
);

GO 

CREATE TABLE ProductServingUnits (
	[ProductId] INT NOT NULL,
	[UnitId] INT NOT NULL,

	Constraint Pk_ProductServingUnits PRIMARY KEY Clustered ([ProductId],[UnitId]),
	Constraint fk_ProductServingUnits_Product FOREIGN KEY ([ProductId]) REFERENCES Products([ProductId]),
	Constraint fk_ProductServingUnits_Unit FOREIGN KEY ([UnitId]) REFERENCES Units([UnitId])
);








