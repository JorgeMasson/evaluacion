create database if not exists db_test;

use db_test;

create table Employees(
	EmployeeID int(8) unsigned zerofill primary key,
    LastName varchar(30),
    FirstName varchar(30) not null,
    DateOfBirth int(8) unsigned zerofill
);



