This application was created for a test task for a vacancy in a DBA company.

A prepared MySQL remote database located on Reg.ru hosting is used.

Data Base structure;
```sql
CREATE TABLE IF NOT EXISTS PhoneNumber (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Number VARCHAR(255),
    Type VARCHAR(255),
    AbonentID INT
);


CREATE TABLE IF NOT EXISTS Abonent (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255),
    LastName VARCHAR(255),
    SurName VARCHAR(255),
    AddressId INT
);


ALTER TABLE PhoneNumber
ADD CONSTRAINT FK_PhoneNumber_Abonent FOREIGN KEY (AbonentId) REFERENCES Abonent(Id);



CREATE TABLE IF NOT EXISTS Streets (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    StreetName VARCHAR(255)
);


CREATE TABLE IF NOT EXISTS Address (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    HomeNumber VARCHAR(255),
    StreetId INT
);


ALTER TABLE Address
ADD CONSTRAINT FK_Address_Street FOREIGN KEY (StreetId) REFERENCES Streets(Id);
```
![Abonents](https://github.com/MichalSvetliy69/ForDBA_TestWork/blob/master/Images/Abonents.PNG)

![Addresses](https://github.com/MichalSvetliy69/ForDBA_TestWork/blob/master/Images/Addresses.PNG)

![PhoneNumbers](https://github.com/MichalSvetliy69/ForDBA_TestWork/blob/master/Images/PhoneNumbers.PNG)

![Streets](https://github.com/MichalSvetliy69/ForDBA_TestWork/blob/master/Images/Streets.PNG)


