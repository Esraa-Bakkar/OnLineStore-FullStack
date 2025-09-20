create database Online_store
use Online_store;
create table _User(
 U_ID INT IDENTITY(1,1) PRIMARY KEY ,
U_name varchar(100),
Admin bit , 
address varchar(20), 
email varchar(20),
phone varchar(11));

CREATE TABLE catagory (
    C_ID INT IDENTITY(1,1) PRIMARY KEY, 
    Description VARCHAR(200),
    C_name VARCHAR(50)
);


create table cart (T_ID int , 
date date ,
U_ID int ,
primary key (T_ID ), 
FOREIGN KEY (U_ID ) REFERENCES _User (U_ID));

create table product(P_ID int , 
P_name varchar(20), 
price decimal ,
imge_path varchar(50),
stock int , 
C_ID int ,
primary key (P_ID ),
Foreign key (C_ID) REFERENCES catagory(C_ID));

create table _Order (O_ID int , 
U_ID int , 
Total_Price Decimal , 
paid Bit , 
date  date , 
status varchar , 
T_ID int ,
Primary key (O_ID),
FOREIGN KEY (U_ID) REFERENCES _User (U_ID),
FOREIGN KEY (T_ID ) REFERENCES Cart (T_ID));

create table cart_item (Item_ID  int , 
P_ID int , 
T_ID int , 
quantity int , 
price Decimal , 
Primary key (P_ID),
FOREIGN KEY (P_ID ) REFERENCES Product (P_ID),
fOREIGN KEY (T_ID) REFERENCES Cart (T_ID));

create table Review (R_ID int , 
U_ID int , 
P_ID int ,
Rating decimal , 
comment varchar ,
Primary key (R_ID ),
foreign key (U_ID ) REFERENCES _User (U_ID),
foreign key (P_ID ) REFERENCES Product (P_ID));

ALTER TABLE Review
ALTER COLUMN comment varchar(200);


INSERT INTO _User VALUES
(1, 'Ahmed Ali', 0, 'Cairo', 'ahmed@example.com', '01012345678'),
(2, 'Sara Mahmoud', 0, 'Alex', 'sara@example.com', '01087654321'),
(3, 'Mohamed Nabil', 1, 'Giza', 'mohamed@example.com', '01011112222'),
(4, 'Laila Saeed', 0, 'Mansoura', 'laila@example.com', '01033334444'),
(5, 'Omar Yasser', 0, 'Tanta', 'omar@example.com', '01055556666'),
(6, 'Nour Adel', 1, 'Zagazig', 'nour@example.com', '01077778888'),
(7, 'Hassan Tarek', 0, 'Aswan', 'hassan@example.com', '01099990000'),
(8, 'Fatma Hany', 0, 'Luxor', 'fatma@example.com', '01022223333'),
(9, 'Yasmine Samir', 0, 'Ismailia', 'yasmine@example.com', '01044445555'),
(10, 'Tamer Khaled', 0, 'Suez', 'tamer@example.com', '01066667777');


INSERT INTO catagory VALUES
(1, 'Electronic devices', 'Electronics'),
(2, 'Men and Women clothing', 'Clothing'),
(3, 'All kinds of books', 'Books'),
(4, 'Home appliances', 'Home'),
(5, 'Sports equipment', 'Sports'),
(6, 'Toys and games', 'Toys'),
(7, 'Beauty products', 'Beauty'),
(8, 'Pet supplies', 'Pets'),
(9, 'Groceries and food', 'Grocery'),
(10, 'Automotive parts', 'Auto');


INSERT INTO product VALUES
(1, 'Smartphone', 7500.00, 'images/smartphone.jpg', 50, 1),
(2, 'Laptop', 15000.00, 'images/laptop.jpg', 30, 1),
(3, 'T-Shirt', 150.00, 'images/tshirt.jpg', 100, 2),
(4, 'Novel', 80.00, 'images/novel.jpg', 200, 3),
(5, 'Microwave', 1200.00, 'images/microwave.jpg', 40, 4),
(6, 'Football', 200.00, 'images/football.jpg', 60, 5),
(7, 'Doll', 90.00, 'images/doll.jpg', 80, 6),
(8, 'Lipstick', 70.00, 'images/lipstick.jpg', 70, 7),
(9, 'Dog Food', 250.00, 'images/dogfood.jpg', 90, 8),
(10, 'Car Oil', 300.00, 'images/caroil.jpg', 45, 10);


INSERT INTO cart VALUES
(1, '2025-08-01', 1),
(2, '2025-08-02', 2),
(3, '2025-08-03', 3),
(4, '2025-08-04', 4),
(5, '2025-08-05', 5),
(6, '2025-08-06', 6),
(7, '2025-08-07', 7),
(8, '2025-08-08', 8),
(9, '2025-08-09', 9),
(10, '2025-08-10', 10);


INSERT INTO _Order VALUES
(1, 1, 7650.00, 1, '2025-08-01', 'Shipped', 1),
(2, 2, 15500.00, 1, '2025-08-02', 'Delivered', 2),
(3, 3, 150.00, 0, '2025-08-03', 'Pending', 3),
(4, 4, 160.00, 1, '2025-08-04', 'Shipped', 4),
(5, 5, 1250.00, 1, '2025-08-05', 'Processing', 5),
(6, 6, 200.00, 0, '2025-08-06', 'Pending', 6),
(7, 7, 90.00, 1, '2025-08-07', 'Delivered', 7),
(8, 8, 70.00, 1, '2025-08-08', 'Shipped', 8),
(9, 9, 250.00, 0, '2025-08-09', 'Pending', 9),
(10, 10, 600.00, 1, '2025-08-10', 'Delivered', 10);


INSERT INTO cart_item VALUES
(1, 1, 1, 1, 7500.00),
(2, 2, 2, 1, 15000.00),
(3, 3, 3, 1, 150.00),
(4, 4, 4, 2, 80.00),
(5, 5, 5, 1, 1200.00),
(6, 6, 6, 1, 200.00),
(7, 7, 7, 1, 90.00),
(8, 8, 8, 1, 70.00),
(9, 9, 9, 1, 250.00),
(10, 10, 10, 2, 300.00);


INSERT INTO Review VALUES
(1, 1, 1, 4.5, 'Very good phone'),
(2, 2, 2, 4.8, 'Excellent laptop'),
(3, 3, 3, 3.0, 'Nice material'),
(4, 4, 4, 5.0, 'Loved the story'),
(5, 5, 5, 4.0, 'Works great'),
(6, 6, 6, 3.5, 'Okay quality'),
(7, 7, 7, 4.0, 'My kid loved it'),
(8, 8, 8, 4.2, 'Beautiful shade'),
(9, 9, 9, 4.3, 'My dog is happy'),
(10, 10, 10, 4.1, 'Good for my car');

select * from _User		



