Для выполнения данного задания была построена база TestWork по следующим sql-запросах 


CREATE DATABASE IF NOT EXISTS TestWork DEFAULT CHARSET utf8 COLLATE utf8_general_ci;

USE TestWork;
CREATE TABLE user(
id INT NOT NULL AUTO_INCREMENT, 
name VARCHAR(255) DEFAULT '',
gender BOOL,
date_of_bith DATETIME,
PRIMARY KEY(id)
);

CREATE TABLE  Product(
id INT NOT NULL AUTO_INCREMENT,
name VARCHAR(45) DEFAULT '',
description VARCHAR(45) DEFAULT '',
PRIMARY KEY (id)
);

CREATE TABLE Orders (
id INT NOT NULL AUTO_INCREMENT, 
created_on DATETIME,
modified_on DATETIME,
user_id INT,
PRIMARY KEY (id),
CONSTRAINT fk_order_user1_idx FOREIGN KEY (user_id) REFERENCES user (id)
);

CREATE TABLE Order_line (
id INT NOT NULL AUTO_INCREMENT, 
price DECIMAL,
quantity INT,
product_id INT,
order_id INT,
PRIMARY KEY (id),
CONSTRAINT fk_order_line_product1_idx FOREIGN KEY (product_id) REFERENCES product (id),
CONSTRAINT fk_order_line_order1_idx FOREIGN KEY (order_id) REFERENCES orders (id)
);

INSERT INTO user (NAME, gender, date_of_bith)  
VALUES ( 'Петров Олег', 1, '1987-12-31 00:00:00'),
('Иванов Вася', 1, '1983-10-12 00:00:00'),
('Харитон Петя', 1, '1993-06-02 00:00:00');

INSERT INTO Product (NAME, description)  
VALUES 
( 'Product 1', 'Description product 1'),
( 'Product 2', 'Description product 2'),
( 'Product 3', 'Description product 3'),
( 'Product 4', 'Description product 4'),
( 'Product 5', 'Description product 5'),
( 'Product 6', 'Description product 6'),
( 'Product 7', 'Description product 7'),
( 'Product 8', 'Description product 8'), 
( 'Product 9', 'Description product 9'),
( 'Product 10', 'Description product 10');

INSERT INTO orders (created_on, modified_on, user_id)
VALUES ((SELECT DATE_SUB(NOW(), INTERVAL 1 DAY)), (SELECT DATE_SUB(NOW(), INTERVAL 1 DAY)), (SELECT id FROM user WHERE NAME='Петров Олег')),
((SELECT DATE_SUB(NOW(), INTERVAL 2 DAY)), (SELECT DATE_SUB(NOW(), INTERVAL 2 DAY)), (SELECT id FROM user WHERE NAME='Иванов Вася')),
((SELECT DATE_SUB(NOW(), INTERVAL 2 DAY)), (SELECT DATE_SUB(NOW(), INTERVAL 2 DAY)), (SELECT id FROM user WHERE NAME='Харитон Петя'));


INSERT INTO Order_line (price, quantity, product_id, order_id)
VALUES (1000, 2, (SELECT id FROM product WHERE NAME = 'Product 1'), 1),
(980, 1, (SELECT id FROM product WHERE NAME = 'Product 2'), 1),
(500, 1, (SELECT id FROM product WHERE NAME = 'Product 3'), 1),
(600, 2, (SELECT id FROM product WHERE NAME = 'Product 4'), 2),
(300, 3, (SELECT id FROM product WHERE NAME = 'Product 5'), 2),
(700, 1, (SELECT id FROM product WHERE NAME = 'Product 6'), 2),
(200, 4, (SELECT id FROM product WHERE NAME = 'Product 7'), 3),
(1200, 1, (SELECT id FROM product WHERE NAME = 'Product 8'), 3),
(1100, 1, (SELECT id FROM product WHERE NAME = 'Product 9'), 3),
(1250, 1, (SELECT id FROM product WHERE NAME = 'Product 10'), 3);
