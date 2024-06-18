-- CouponsV2 DATABASE

-- 1) Strong Table
CREATE TABLE MarketplaceUsers(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(125) NOT NULL UNIQUE,
    Password VARCHAR(125) NOT NULL,
    Email VARCHAR(125) NOT NULL UNIQUE
);


-- 2) Strong Table
CREATE TABLE MarketingUsers(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(125) NOT NULL UNIQUE,
    Password VARCHAR(125) NOT NULL,
    Email VARCHAR(125) NOT NULL UNIQUE
);

-- 3) Strong Table 1:1 with UserRole
CREATE TABLE Roles(
    Id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    Name VARCHAR(125) NOT NULL UNIQUE
);



-- 4) Weak Table -> M:1 (Muchos a uno) with Role and MarketingUser
CREATE TABLE UserRoles(
    Id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    User_Id INT NOT NULL,
    Role_Id INT NOT NULL,
    FOREIGN KEY (User_Id) REFERENCES MarketingUsers(Id),
    FOREIGN KEY (Role_Id) REFERENCES Roles(Id)
);

-- 5) Strong and weak Table -> 1:1 (uno a uno)
CREATE TABLE Coupons(
    Id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(255) NOT NULL,
    Description TEXT NOT NULL,
    Code VARCHAR(40) NOT NULL UNIQUE,
    Start_Date DATETIME NOT NULL,
    End_Date DATETIME NOT NULL,
    Discount_Type ENUM('Fixed','Percentage') NOT NULL,
    Discount_Value DECIMAL(10,0) NOT NULL,
    Usage_Limit INT NOT NULL,
    Min_Purchase_Amount DECIMAL(10,0) NOT NULL,
    Max_Purchase_Amount DECIMAL(10,0) NOT NULL,
    Status ENUM('Active','Inactive','Used','Expired','SoldOut') DEFAULT 'Active' NOT NULL,
    Created_By INT NOT NULL,
    Created_At DATETIME NOT NULL,
    Uses INT NOT NULL DEFAULT 0,
    FOREIGN KEY (Created_By) REFERENCES MarketingUsers(Id)
);


-- 6) Weak Table -> 1:1 with Coupon
CREATE TABLE CouponHistories(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Coupon_Id INT NOT NULL,
    Change_Date DATETIME,
    Field_Changed VARCHAR(100),
    Old_Value VARCHAR(200),
    New_Value VARCHAR(100),
    FOREIGN KEY (Coupon_Id) REFERENCES Coupons(Id)
);


-- 7) Weak Table -> M:1 with MarketplaceUser and Coupon
CREATE TABLE CouponUsages(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Coupon_Id INT,
    User_Id INT,
    Usage_Date DATETIME,
    Transaction_Amount INT,
    FOREIGN KEY (Coupon_Id) REFERENCES Coupons(Id),
    FOREIGN KEY (User_Id) REFERENCES MarketplaceUsers(Id)
);



-- 8) Strong - Weak Table -> 1:M with Marketplace and PurchaseCoupon
CREATE TABLE Purchases(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    User_Id INT NOT NULL,
    Date DATETIME,
    Amount DECIMAL(10,0) NOT NULL,
    FOREIGN KEY (User_Id) REFERENCES MarketplaceUsers(Id)
);


-- 9) Weak Table -> M:1 with Purchase and Coupon
CREATE TABLE PurchaseCoupons(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Purchase_Id INT NOT NULL,
    Coupon_Id INT NOT NULL,
    FOREIGN KEY (Purchase_Id) REFERENCES Purchases(Id),
    FOREIGN KEY (Coupon_Id) REFERENCES Coupons(Id)
);

 --------INSERTS----
-- 1) Insertar datos en la tabla MarketplaceUsers
INSERT INTO MarketplaceUsers (Username, Password, Email)
VALUES 
('User1', 'Password1', 'User1@example.com'),
('User2', 'Password2', 'User2@example.com'),
('User3', 'Password3', 'User3@example.com'),
('User4', 'Password4', 'User4@example.com'),
('User5', 'Password5', 'User5@example.com');

-- 2) Insertar datos en la tabla MarketingUsers
INSERT INTO MarketingUsers (Username, Password, Email) 
VALUES 
('MarketingUser1', 'Password123', 'MarketingUser1@example.com'),
('MarketingUser2', 'SecurePass', 'MarketingUser2@example.com'),
('MarketingUser3', 'MySecretPassword', 'MarketingUser3@example.com'),
('MarketingUser4', 'StrongPassword', 'MarketingUser4@example.com'),
('MarketingUser5', 'Password1234', 'MarketingUser5@example.com');

-- 3) Insertar datos en la tabla Roles
INSERT INTO Roles (Name) 
VALUES 
('Admin'),
('Manager'),
('Employee'),
('Assistant'),
('Intern');

-- 4) Insertar datos en la tabla UserRoles
INSERT INTO UserRoles (User_Id, Role_Id) 
VALUES 
(1, 1), -- Asignar el rol de Admin al usuario con ID 1
(2, 2), -- Asignar el rol de Manager al usuario con ID 2
(3, 3), -- Asignar el rol de Employee al usuario con ID 3
(4, 4), -- Asignar el rol de Assistant al usuario con ID 4
(5, 5); -- Asignar el rol de Intern al usuario con ID 5

-- 5) Insertar datos en la tabla Coupons
INSERT INTO Coupons (Name, Description, Code, Start_Date, End_Date, Discount_Type, Discount_Value, Usage_Limit, Min_Purchase_Amount, Max_Purchase_Amount, Status, Created_By, Created_At, Uses) 
VALUES 
('Summer Sale', '20% off on all summer items', 'SUMMER20', '2024-06-01 00:00:00', '2024-06-30 23:59:59', 'Percentage', 20, 100, 500, 5000, 'Active', 1, '2024-06-01 00:00:00', 0),
('Winter Discount', 'Fixed discount of $50 on winter items', 'WINTER50', '2024-12-01 00:00:00', '2024-12-31 23:59:59', 'Fixed', 50, 200, 1000, 10000, 'Inactive', 2, '2024-12-01 00:00:00', 0),
('New Year Offer', '25% off for the new year celebration', 'NEWYEAR25', '2024-12-31 00:00:00', '2025-01-01 23:59:59', 'Percentage', 25, 50, 300, 3000, 'Active', 3, '2024-12-31 00:00:00', 0),
('Flash Sale', 'Get $100 off on purchases over $1000', 'FLASH100', '2024-07-01 00:00:00', '2024-07-01 23:59:59', 'Fixed', 100, 500, 1000, 5000, 'Used', 4, '2024-07-01 00:00:00', 1),
('Spring Special', '15% off on all items for spring season', 'SPRING15', '2024-03-01 00:00:00', '2024-03-31 23:59:59', 'Percentage', 15, 100, 500, 5000, 'Expired', 5, '2024-03-01 00:00:00', 10);

-- 6) Insertar datos en la tabla CouponHistories
INSERT INTO CouponHistories (Coupon_Id, Change_Date, Field_Changed, Old_Value, New_Value) 
VALUES 
(1, '2024-06-15 12:00:00', 'Usage_Limit', '100', '50'), -- Cambiar el límite de uso del cupón ID 1 de 100 a 50
(2, '2024-05-20 09:00:00', 'Status', 'Active', 'Inactive'), -- Cambiar el estado del cupón ID 2 de Activo a Inactivo
(3, '2024-07-10 15:30:00', 'Min_Purchase_Amount', '2000', '2500'), -- Cambiar el monto mínimo de compra del cupón ID 3 de 2000 a 2500
(4, '2024-04-05 18:45:00', 'Max_Purchase_Amount', '1000', '1500'), -- Cambiar el monto máximo de compra del cupón ID 4 de 1000 a 1500
(5, '2024-08-20 10:00:00', 'Status', 'SoldOut', 'Active'); -- Cambiar el estado del cupón ID 5 de Agotado a Activo

-- 7) Insertar datos en la tabla CouponUsages
INSERT INTO CouponUsages (Coupon_Id, User_Id, Usage_Date, Transaction_Amount) 
VALUES 
(1, 1, '2024-06-05 08:30:00', 2000), -- Usuario ID 1 utiliza el cupón ID 1 el 5 de junio de 2024 con una transacción de 2000
(2, 2, '2024-05-10 13:45:00', 1500), -- Usuario ID 2 utiliza el cupón ID 2 el 10 de mayo de 2024 con una transacción de 1500
(3, 3, '2024-07-20 11:20:00', 3000), -- Usuario ID 3 utiliza el cupón ID 3 el 20 de julio de 2024 con una transacción de 3000
(4, 4, '2024-04-15 09:10:00', 1000), -- Usuario ID 4 utiliza el cupón ID 4 el 15 de abril de 2024 con una transacción de 1000
(5, 5, '2024-08-05 16:00:00', 2500); -- Usuario ID 5 utiliza el cupón ID 5 el 5 de agosto de 2024 con una transacción de 2500

-- 8) Insertar datos en la tabla Purchases
INSERT INTO Purchases (User_Id, Date, Amount) 
VALUES 
(1, '2024-06-01 10:00:00', 5000), -- Usuario ID 1 realiza una compra el 1 de junio de 2024 por un monto de 5000
(2, '2024-05-15 14:30:00', 3000), -- Usuario ID 2 realiza una compra el 15 de mayo de 2024 por un monto de 3000
(3, '2024-07-10 11:45:00', 4500), -- Usuario ID 3 realiza una compra el 10 de julio de 2024 por un monto de 4500
(4, '2024-04-05 09:20:00', 2000), -- Usuario ID 4 realiza una compra el 5 de abril de 2024 por un monto de 2000
(5, '2024-08-20 16:15:00', 6000); -- Usuario ID 5 realiza una compra el 20 de agosto de 2024 por un monto de 6000

-- 9) Insertar datos en la tabla PurchaseCoupons
INSERT INTO PurchaseCoupons (Purchase_Id, Coupon_Id) 
VALUES 
(1, 1), -- Cupón ID 1 asociado a la compra ID 1
(2, 2), -- Cupón ID 2 asociado a la compra ID 2
(3, 3), -- Cupón ID 3 asociado a la compra ID 3
(4, 4), -- Cupón ID 4 asociado a la compra ID 4
(5, 5); -- Cupón ID 5 asociado a la compra ID 5
