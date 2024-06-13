--CouponsV2 DATABASE

--1) Strong Table
CREATE TABLE MarketplaceUser(
    id int PRIMARY KEY AUTO_INCREMENT,
    username VARCHAR(125) NOT NULL,
    password VARCHAR(125) NOT NULL,
    email VARCHAR(125) NOT NULL UNIQUE
);

--2) Strong Table
CREATE TABLE MarketingUser(
    id int PRIMARY KEY AUTO_INCREMENT,
    username VARCHAR(125) NOT NULL,
    password VARCHAR(125) NOT NULL,
    email VARCHAR(125) NOT NULL UNIQUE
);

--3) Strong Table 1:1 with UserRole

CREATE TABLE Role(
    id int PRIMARY KEY AUTO_INCREMENT NOT NULL,
    name VARCHAR(125) NOT NULL UNIQUE
)

--4)Weak Table -> M:1 (Muchos a uno) with Role and MarketingUser

CREATE TABLE UserRole(
    id int PRIMARY KEY AUTO_INCREMENT NOT NULL,
    user_id int NOT NULL,
    role_id int NOT NULL,
    Foreign Key (user_id) REFERENCES MarketingUser(id),
    Foreign Key (user_id) REFERENCES MarketingUser(id)
)


--5)Strong and weak Table -> 1:1 (uno a uno) 

CREATE TABLE Coupon(
    id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    description TEXT NOT NULL,
    start_date DATETIME NOT NULL,
    end_date DATETIME NOT NULL,
    discount_type ENUM('Fixed,Percentage') NOT NULL,
    discount_value DECIMAL(10,0) NOT NULL,
    usage_limit int NOT NULL,
    min_purchase_amount DECIMAL(10,0) NOT NULL,
    max_purchase_amount DECIMAL(10,0) NOT NULL,
    status ENUM('Active','Inactive','Used','Expired','SoldOut') DEFAULT ('Active') NOT NUll,
    created_by int NOT NULL,
    FOREIGN KEY (created_by) REFERENCES MarketplaceUser(id)
);


ALTER TABLE Coupon
RENAME COLUMN statuts TO status;


--6) Weak Table -> 1:1 with Coupon

CREATE TABLE CouponHistory(
    id int PRIMARY KEY AUTO_INCREMENT,
    coupon_id int NOT NULL,
    change_date DATETIME,
    field_changed VARCHAR(100),
    old_value VARCHAR(200),
    new_value VARCHAR(100),
    FOREIGN KEY (coupon_id) REFERENCES Coupon (id)
)

DROP TABLE CouponHistory;

--7) WEAK Table -> M:1 with MarketplaceUser and Coupon
CREATE TABLE CouponUsage(
    id int PRIMARY KEY AUTO_INCREMENT,
    coupon_id int,
    user_id int,
    usage_date DATETIME,
    transaction_amount int,
    FOREIGN KEY (coupon_id) REFERENCES Coupon(id),
    FOREIGN KEY (user_id) REFERENCES MarketplaceUser(id)
);

DROP TABLE CouponUsage;


--8) STRONG - WEAK Table -> 1:M with MarketPlace and PurchaseCoupon

CREATE TABLE Purchase(
    id INT PRIMARY KEY AUTO_INCREMENT,
    user_id INT NOT NULL,
    date DATETIME,
    amount DECIMAL(10,0) NOT NULL,
    FOREIGN KEY (user_id) REFERENCES MarketplaceUser(id)
);

--9) WEAK Table -> M:1 with Purchase and Coupon
CREATE TABLE PurchaseCoupon(
    id INT PRIMARY KEY AUTO_INCREMENT,
    purchase_id INT NOT NULL,
    coupon_id INT NOT NULL,
    FOREIGN KEY (purchase_id) REFERENCES Purchase(id),
    FOREIGN KEY (coupon_id) REFERENCES Coupon(id)
);


 