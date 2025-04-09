CREATE DATABASE IF NOT EXISTS `GodRift`;
USE `GodRift`;

CREATE TABLE [dbo].[Users] (
    [UserId]         BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (100) NOT NULL,
    [Email]        VARCHAR (150) NOT NULL,
    [HashPassword] VARCHAR (255) NOT NULL,
    [CreatedAt]    DATETIME      DEFAULT (getdate()) NULL,
    PRIMARY KEY CLUSTERED ([User] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC)
);


CREATE TABLE [dbo].[Players] (
    [PlayerId]    BIGINT        IDENTITY (1, 1) NOT NULL,
    [Nick]        VARCHAR (100) NOT NULL,
    [Tag]         VARCHAR (10)  NULL,
    [Server]      VARCHAR (50)  NULL,
    [Rank]        VARCHAR (50)  NULL,
    [MatchesWon]  INT           DEFAULT ((0)) NULL,
    [MatchesLost] INT           DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([PlayerId] ASC)
);

CREATE TABLE [dbo].[Champions] (
    [ChampionId]   INT           IDENTITY (1, 1) NOT NULL,
    [ChampionName] VARCHAR (100) NOT NULL,
    [Description]  TEXT          NULL,
    [Difficulty]   VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([ChampionId] ASC)
);

CREATE TABLE [dbo].[Items] (
    [ItemId]      INT           IDENTITY (1, 1) NOT NULL,
    [ItemName]    VARCHAR (100) NOT NULL,
    [Description] TEXT          NULL,
    [Price]       INT           NULL,
    [Type]        VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([ItemId] ASC)
);

CREATE TABLE [dbo].[Builds] (
    [BuildId]    BIGINT        IDENTITY (1, 1) NOT NULL,
    [Name]       VARCHAR (100) NULL,
    [ChampionId] INT           NULL,
    PRIMARY KEY CLUSTERED ([BuildId] ASC),
    FOREIGN KEY ([ChampionId]) REFERENCES [dbo].[Champions] ([ChampionId])
);


CREATE TABLE [dbo].[Lanes] (
    [LaneId]   INT          IDENTITY (1, 1) NOT NULL,
    [LaneName] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([LaneId] ASC),
    UNIQUE NONCLUSTERED ([LaneName] ASC)
);

CREATE TABLE [dbo].[ChampionsOnLane] (
    [ChampionId] INT        NOT NULL,
    [LaneId]     INT        NOT NULL,
    [PickRate]   FLOAT (53) NULL,
    [BanRate]    FLOAT (53) NULL,
    PRIMARY KEY CLUSTERED ([ChampionId] ASC, [LaneId] ASC),
    FOREIGN KEY ([ChampionId]) REFERENCES [dbo].[Champions] ([ChampionId]),
    FOREIGN KEY ([LaneId]) REFERENCES [dbo].[Lanes] ([LaneId])
);

CREATE TABLE [dbo].[Matches] (
    [MatchId]   BIGINT       IDENTITY (1, 1) NOT NULL,
    [MatchDate] DATETIME     NOT NULL,
    [GameMode]  VARCHAR (50) NULL,
    [Duration]  INT          NULL,
    PRIMARY KEY CLUSTERED ([MatchId] ASC)
);

CREATE TABLE [dbo].[MatchPlayer] (
    [PlayersMatchId] BIGINT       IDENTITY (1, 1) NOT NULL,
    [MatchId]        BIGINT       NULL,
    [PlayerId]       INT          NULL,
    [ChampionId]     INT          NULL,
    [Result]         VARCHAR (10) NULL,
    [Lane]           VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([PlayersMatchId] ASC),
    FOREIGN KEY ([ChampionId]) REFERENCES [dbo].[Champions] ([ChampionId]),
    FOREIGN KEY ([MatchId]) REFERENCES [dbo].[Matches] ([MatchID]),
    FOREIGN KEY ([PlayerId]) REFERENCES [dbo].[Players] ([PlayerId])
);

CREATE TABLE [dbo].[PlayersMatchItems] (
    [PlayersMatchId] BIGINT       NOT NULL,
    [ItemId]         INT          NOT NULL,
    [Slot]           INT          NULL,
    [SlotCategory]   VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([PlayersMatchId] ASC, [ItemId] ASC),
    FOREIGN KEY ([ItemId]) REFERENCES [dbo].[Items] ([ItemId]),
    FOREIGN KEY ([PlayersMatchId]) REFERENCES [dbo].[MatchPlayer] ([PlayersMatchId])
);

