CREATE DATABASE QUANLYSINHVIEN
GO
USE QUANLYSINHVIEN
GO

CREATE TABLE LopSH
(
	ID_Lop INT primary key IDENTITY(1,1),
	NameLop VARCHAR(20)
)

CREATE TABLE SV
(
	MSSV VARCHAR(20) PRIMARY KEY,
	NameSV VARCHAR(20),
	Gender bit,
	NS Date,
	ID_Lop INT
	FOREIGN KEY (ID_Lop) references LopSH(ID_Lop)
)

INSERT INTO LopSH(NameLop) VALUES('19DT1')
INSERT INTO LopSH(NameLop) VALUES('19DT2')
INSERT INTO LopSH(NameLop) VALUES('19DT3')
INSERT INTO LopSH(NameLop) VALUES('19DT4')

INSERT INTO SV(MSSV,NameSV,Gender,NS,ID_Lop) VALUES('001','NVA',1,GETDATE(),1)
INSERT INTO SV(MSSV,NameSV,Gender,NS,ID_Lop) VALUES('002','NVS',1,GETDATE(),1)
INSERT INTO SV(MSSV,NameSV,Gender,NS,ID_Lop) VALUES('003','NVD',1,GETDATE(),2)
INSERT INTO SV(MSSV,NameSV,Gender,NS,ID_Lop) VALUES('004','NVF',1,GETDATE(),2)
INSERT INTO SV(MSSV,NameSV,Gender,NS,ID_Lop) VALUES('005','NVG',1,GETDATE(),3)
INSERT INTO SV(MSSV,NameSV,Gender,NS,ID_Lop) VALUES('006','NVH',1,GETDATE(),4)
			