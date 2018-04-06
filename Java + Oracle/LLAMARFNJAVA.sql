CREATE OR REPLACE
FUNCTION dec2bin(num NUMBER) RETURN VARCHAR2 AS
LANGUAGE JAVA NAME 'FUNCIONESJAVA.DEC2BIN(int) return java.lang.String';
/
CREATE OR REPLACE
FUNCTION hex2dec(str VARCHAR2) RETURN NUMBER AS
LANGUAGE JAVA NAME 'FUNCIONESJAVA.HEX2DEC (java.lang.String) return java.lang.Integer';
/
CREATE OR REPLACE
FUNCTION dec2hex(num NUMBER) RETURN VARCHAR2 AS
LANGUAGE JAVA NAME 'FUNCIONESJAVA.DEC2HEX (int) return java.lang.String';
/
CREATE OR REPLACE
FUNCTION factorial(num NUMBER) RETURN NUMBER AS
LANGUAGE JAVA NAME 'FUNCIONESJAVA.Factorial (int) return java.lang.Integer';
/
CREATE OR REPLACE
FUNCTION cel2fah(temperature FLOAT) RETURN FLOAT AS
LANGUAGE JAVA NAME 'FUNCIONESJAVA.cel2fah(float) return float';
/
CREATE OR REPLACE
FUNCTION fah2cel(temperature float) RETURN FLOAT AS
LANGUAGE JAVA NAME 'FUNCIONESJAVA.fah2cel(float) return float';
/
CREATE OR REPLACE
FUNCTION bin2dec(str VARCHAR2) RETURN NUMBER AS
LANGUAGE JAVA NAME 'FUNCIONESJAVA.BIN2DEC (java.lang.String) return java.lang.Integer';
/
CREATE OR REPLACE
FUNCTION trimString(str VARCHAR2, remove VARCHAR2) RETURN VARCHAR2 AS
LANGUAGE JAVA NAME 'FUNCIONESJAVA.Trim(java.lang.String, java.lang.String) return java.lang.String';
/
CREATE OR REPLACE
FUNCTION compare(str1 VARCHAR2, str2 VARCHAR2) RETURN NUMBER AS
LANGUAGE JAVA NAME 'FUNCIONESJAVA.CompareString(java.lang.String, java.lang.String) return int';
/
CREATE OR REPLACE
FUNCTION repeat(str VARCHAR2, amount NUMBER) RETURN VARCHAR2 AS
LANGUAGE JAVA NAME 'FUNCIONESJAVA.Repeat(java.lang.String, int) return java.lang.String';
/
CREATE OR REPLACE
FUNCTION Ping(hostname VARCHAR2) RETURN NUMBER AS
LANGUAGE JAVA NAME 'FUNCIONESJAVA.ping(java.lang.String) return int';
/
CREATE OR REPLACE
FUNCTION PMT(interest_rate FLOAT, amount_of_payments FLOAT, loan_amount FLOAT) RETURN FLOAT AS
LANGUAGE JAVA NAME 'FUNCIONESJAVA.PMT(double,int,double) return float';
/

select compare('hola','a') from DUAL;
select cel2fah(22) from DUAL;
select fah2cel(22) from DUAL;
select bin2dec('0101') from DUAL;
select dec2bin(7) from DUAL;
select hex2dec('c') from DUAL;
select dec2hex(12) from DUAL;
select factorial(5) from DUAL;
select trimString('ahola','a') from DUAL;
select repeat('hola',3) from DUAL;
select Ping('127.0.0.1') from DUAL;
select PMT(22, 4, 2000) from DUAL;




