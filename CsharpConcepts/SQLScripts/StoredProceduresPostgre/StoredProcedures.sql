-- Sample Table
CREATE TABLE EMPLOYEE (
  empId INTEGER PRIMARY KEY,
  name TEXT NOT NULL,
  dept TEXT NOT NULL,
  salary bigint NOT NULL
);

-- stored procedure to insert row into Employee table

CREATE or Replace procedure sp_Add_Employee(empId INTEGER, name TEXT, dept TEXT,salary bigint)
language plpgsql
as $$
begin
insert into EMPLOYEE(empId,name,dept,salary) values(empId, name, dept, salary);
end;
$$;

CREATE or Replace procedure sp_update_employee_dept(empid INTEGER, dept TEXT)
language plpgsql
as $$
begin
update EMPLOYEE set dept = dept where empId = empid;
end;
$$;