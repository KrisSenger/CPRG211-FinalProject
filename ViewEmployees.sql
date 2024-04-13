set echo ON

set linesize 200
set pagesize 200

COLUMN first_name FORMAT a15
COLUMN last_name FORMAT a15
COLUMN dept_name FORMAT a12
COLUMN dept_name FORMAT a25
COLUMN base_salary FORMAT $999,990.00
COLUMN bonuses FORMAT $999,990.00
COLUMN "Total Comp" FORMAT $999,990.00

SELECT employee_id, 
       first_name, 
       last_name, 
       base_salary, 
       bonuses, 
       SUM(base_salary + bonuses) AS "Total Comp", 
       department_id, 
       dept_name, 
       position_id, 
       position_title 
  FROM employee NATURAL JOIN department
                NATURAL JOIN position
 GROUP BY employee_id, first_name, last_name, base_salary, bonuses, department_id, dept_name, position_id, position_title
 ORDER BY employee_id
 ;