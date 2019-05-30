CREATE TABLE [dbo].[users] (
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

