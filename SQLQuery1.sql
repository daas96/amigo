CREATE TABLE [dbo].[travel] (
    [Id]              INT          NOT NULL,
    [driver]          VARCHAR (50) NOT NULL,
    [departure]       VARCHAR (50) NOT NULL,
    [arrival]         VARCHAR (50) NOT NULL,
    [date]            DATE         NOT NULL,
    [hour]            INT          NOT NULL,
    [smoke]           BIT          DEFAULT ((0)) NULL,
    [animal]          BIT          DEFAULT ((0)) NULL,
    [luggage]         BIT          DEFAULT ((0)) NULL,
    [nbpassengers]    INT          NOT NULL,
    [nbpassengersmax] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[user] (
    [Id]        INT          NOT NULL,
    [firstname] VARCHAR (50) NOT NULL,
    [lastname]  VARCHAR (50) NOT NULL,
    [email]     VARCHAR (50) NOT NULL,
    [password]  VARCHAR (50) NOT NULL,
    [phone]     INT          NOT NULL,
    [car]       VARCHAR (50) NULL,
    [smoke]     BIT          DEFAULT ((0)) NULL,
    [animal]    BIT          DEFAULT ((0)) NULL,
    [luggage]   BIT          DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


INSERT INTO travel(Id,driver,departure,arrival,hour,date,smoke,animal,luggage,nbpassengers,nbpassengersmax)
VALUES(1,'saad','chicout','mont',2,'2019-08-01',0,0,0,2,5);