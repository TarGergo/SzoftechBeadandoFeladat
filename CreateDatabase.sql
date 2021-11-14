USE master
GO

if exists (select * from sysdatabases where name='ProductDatabase')
		drop database ProductDatabase

create database ProductDatabase
