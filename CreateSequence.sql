-- Create sequence that starts with 14 since the max id is 13

-- Drops the existing sequence 
DROP SEQUENCE employee_seq;

-- Create new sequence starting at 14
CREATE SEQUENCE employee_seq START WITH 14 INCREMENT BY 1;

-- Trigger for system to use the sequence's next value for every new insert.
CREATE OR REPLACE TRIGGER employee_bir
BEFORE INSERT ON employee
FOR EACH ROW 
BEGIN 
SELECT employee_seq.NEXTVAL INTO :new.employee_id FROM dual;
END;
/

