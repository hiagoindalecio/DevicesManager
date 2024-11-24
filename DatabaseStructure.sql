DROP DATABASE IF EXISTS devicesDB;

CREATE DATABASE devicesDB
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LOCALE_PROVIDER = 'libc'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

CREATE TABLE devices (
	did SERIAL NOT NULL,
    dname varchar(40) NOT NULL,
	dbrand varchar(40) NOT NULL,
    dcreation_date TIMESTAMP DEFAULT NOW(),
    CONSTRAINT device_PK PRIMARY KEY(did)
);

insert into devices (dname, dbrand) values('Smatphone', 'Xiaomi')