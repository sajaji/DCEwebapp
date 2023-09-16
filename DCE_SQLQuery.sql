-- Create SQL Table Named Customer
CREATE TABLE Customer (
    UserId UNIQUEIDENTIFIER PRIMARY KEY,
    Username NVARCHAR(30),
    Email NVARCHAR(20),
    FirstName NVARCHAR(20),
    LastName NVARCHAR(20),
    CreatedOn DATETIME,
    IsActive BIT
);

-- Create SQL Table Named Orders
CREATE TABLE Orders (
    OrderId UNIQUEIDENTIFIER PRIMARY KEY,
    ProductId UNIQUEIDENTIFIER,
    OrderStatus INT,
    OrderType INT,
    OrderBy UNIQUEIDENTIFIER,
    OrderedOn DATETIME,
    ShippedOn DATETIME,
    IsActive BIT,
    FOREIGN KEY (ProductId) REFERENCES Product(ProductId)
);

-- Create SQL Table Named Product
CREATE TABLE Product (
    ProductId UNIQUEIDENTIFIER PRIMARY KEY,
    ProductName NVARCHAR(50),
    UnitPrice DECIMAL,
    SupplierId UNIQUEIDENTIFIER,
    CreatedOn DATETIME,
    IsActive BIT,
    FOREIGN KEY (SupplierId) REFERENCES Supplier(SupplierId)
);

-- Create SQL Table Named Supplier
CREATE TABLE Supplier (
    SupplierId UNIQUEIDENTIFIER PRIMARY KEY,
    SupplierName NVARCHAR(50),
    CreatedOn DATETIME,
    IsActive BIT
);

-- Create Stored Procedure for Active Orders by Customer
CREATE PROCEDURE GetActiveOrdersByCustomer
    @CustomerId UNIQUEIDENTIFIER
AS
BEGIN
    SELECT O.OrderId, O.ProductId, O.OrderStatus, O.OrderType, O.OrderedOn, O.ShippedOn, O.IsActive,
           P.ProductName, P.UnitPrice,
           S.SupplierName,
           C.UserId, C.Username, C.Email, C.FirstName, C.LastName, C.CreatedOn
    FROM Orders AS O
    INNER JOIN Product AS P ON O.ProductId = P.ProductId
    INNER JOIN Supplier AS S ON P.SupplierId = S.SupplierId
    INNER JOIN Customer AS C ON O.OrderBy = C.UserId
    WHERE C.UserId = @CustomerId AND O.IsActive = 1
END;
