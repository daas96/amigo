CREATE TABLE [dbo].[travel] (
    [Id]              INT          NOT NULL,
	[driver]          INT NOT NULL,
    [drivername]      VARCHAR (50) NOT NULL,
    [departure]       VARCHAR (50) NOT NULL,
    [arrival]         VARCHAR (50) NOT NULL,
    [date]            DATETIME         NOT NULL,
    [hour]            INT          NOT NULL,
    [smoke]           BIT          DEFAULT ((0)) NULL,
    [animal]          BIT          DEFAULT ((0)) NULL,
    [luggage]         BIT          DEFAULT ((0)) NULL,
    [nbpassengers]    INT          NOT NULL,
    [nbpassengersmax] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

