DROP DATABASE IF EXISTS devicesDB;

CREATE DATABASE devicesDB
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LOCALE_PROVIDER = 'libc'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

CREATE TABLE devices (
	id SERIAL NOT NULL,
    name varchar(40) NOT NULL,
	brand varchar(40) NOT NULL,
    creation_date TIMESTAMP DEFAULT (NOW() AT TIME ZONE 'utc'),
    CONSTRAINT device_PK PRIMARY KEY(id)
);

insert into devices (name, brand) values('Smatphone', 'Xiaomi')