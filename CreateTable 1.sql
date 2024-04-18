set echo ON

DROP TABLE salary;
DROP TABLE employee;
DROP TABLE position;
DROP TABLE department;

CREATE TABLE department (
    department_id NUMBER(3) PRIMARY KEY,
    dept_name VARCHAR2(30) NOT NULL
);

CREATE TABLE position (
    position_id NUMBER(5) CONSTRAINT sys_position_position_id_pk PRIMARY KEY,
    position_title VARCHAR2(30) CONSTRAINT sys_position_position_title_nn NOT NULL,
    department_id NUMBER(3) CONSTRAINT sys_position_department_id_fk REFERENCES department (department_id)
);

CREATE TABLE employee (
	employee_id NUMBER(5) CONSTRAINT sys_employee_employee_id_pk PRIMARY KEY,
	first_name VARCHAR2(50) CONSTRAINT sys_employee_first_name_nn NOT NULL,
	last_name VARCHAR2(50) CONSTRAINT sys_employee_last_name_nn NOT NULL,
    department_id NUMBER(3), 
    position_id NUMBER(5),
    base_salary NUMBER(8,2),
    bonuses NUMBER(8, 2),
        CONSTRAINT sys_employee_department_id_fk  FOREIGN KEY (department_id)  REFERENCES department (department_id),
        CONSTRAINT sys_employee_position_id_fk FOREIGN KEY (position_id) REFERENCES position (position_id)
);

