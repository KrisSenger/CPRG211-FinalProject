set echo ON

DELETE FROM employee
DELETE FROM position
DELETE FROM department

INSERT INTO department VALUES (001, 'Accounting');
INSERT INTO department VALUES (002, 'HR');
INSERT INTO department VALUES (003, 'Legal');
INSERT INTO department VALUES (004, 'Sales');
INSERT INTO department VALUES (005, 'IT');
INSERT INTO department VALUES (006, 'Marketing');

INSERT INTO position VALUES (1, 'Accountant', 001);
INSERT INTO position VALUES (2, 'Accounts Payable Clerk', 001);
INSERT INTO position VALUES (3, 'Accounts Receivable Clerk', 001);
INSERT INTO position VALUES (4, 'HR Manager', 002);
INSERT INTO position VALUES (5, 'HR Assistant', 002);
INSERT INTO position VALUES (6, 'Legal Counsel', 003);
INSERT INTO position VALUES (7, 'Legal Assistant', 003);
INSERT INTO position VALUES (8, 'Sales Manager', 004);
INSERT INTO position VALUES (9, 'Sales Representative', 004);
INSERT INTO position VALUES (10, 'IT Manager', 005);
INSERT INTO position VALUES (11, 'IT Specialist', 005);
INSERT INTO position VALUES (12, 'Marketing Manager', 006);
INSERT INTO position VALUES (13, 'Marketing Coordinator', 006);

INSERT INTO employee VALUES (00001, 'Roger', 'Rabbit', 001, 2, 60000, 5000);
INSERT INTO employee VALUES (00002, 'Hank', 'Hill', 002, 4, 89000, 7000);
INSERT INTO employee VALUES (00003, 'Lionel', 'Hutz', 003, 6, 110000, 10000);
INSERT INTO employee VALUES (00004, 'Bender', 'Rodriguez', 004, 9, 55000, 4000);
INSERT INTO employee VALUES (00005, 'Lila', 'Schobert', 005, 11, 72500, 6000);
INSERT INTO employee VALUES (00006, 'Mario', 'Lemieux', 006, 13, 40000, 3000);
INSERT INTO employee VALUES (00007, 'Oscar', 'Grouch', 001, 1, 90000, 8000);
INSERT INTO employee VALUES (00008, 'Ben', 'Affleck', 002, 5, 47000, 3500);
INSERT INTO employee VALUES (00009, 'Christina', 'Ferguson', 003, 7, 75000, 5500);
INSERT INTO employee VALUES (00010, 'Matthew', 'Damon', 004, 8, 92000, 3000);
INSERT INTO employee VALUES (00011, 'Clark', 'Gable', 005, 10, 83000, 7000);
INSERT INTO employee VALUES (00012, 'Jessica', 'Rabbit', 006, 12, 67000, 5000);
INSERT INTO employee VALUES (00013, 'Judy', 'Jetson', 001, 3, 58000, 5000);

