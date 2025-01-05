USE [Bank]
GO

-- 01. Create Table Logs
CREATE TABLE [Logs]
(
	[LogId] INT PRIMARY KEY IDENTITY,
	[AccountId] INT FOREIGN KEY
		REFERENCES [Accounts]([Id]),
	[OldSum] MONEY NOT NULL,
	[NewSum] MONEY NOT NULL
)

CREATE TRIGGER [tr_LogAccChange]
    ON [Accounts]
 AFTER UPDATE AS
	   INSERT INTO [Logs]([AccountId], [NewSum], [OldSum])
	   SELECT [i].[Id], [i].[Balance], [d].[Balance]
	     FROM inserted AS [i]
		 JOIN deleted AS [d] ON [i].[Id] = [d].[Id]
		WHERE [i].[Balance] <> [d].[Balance]

-- 02. Create Table Emails
CREATE TABLE [NotificationEmails]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Recipient] INT NOT NULL,
	[Subject] VARCHAR(200) NOT NULL,
	[Body] VARCHAR(1000) NOT NULL
)

CREATE TRIGGER [tr_EmailNotification]
	ON [Logs]
 AFTER INSERT AS
	   INSERT INTO [NotificationEmails]([Recipient], [Subject], [Body])
	   SELECT [i].[AccountId],
			  CONCAT_WS(' ', 'Balance change for account:', [i].[AccountId]),
			  CONCAT_WS(' ', 'On', GETDATE(), 'your balance was changed from', [i].[OldSum], 'to', [i].[NewSum])
	     FROM inserted AS [i]

-- 03. Deposit Money
CREATE PROCEDURE [usp_DepositMoney](@accountId INT, @moneyAmount DECIMAL(18,4)) AS
 BEGIN
	   IF @moneyAmount > 0
			UPDATE [Accounts]
			   SET [Balance] = FORMAT(Balance + @moneyAmount, 'N4')
			 WHERE [Id] = @accountId
   END

-- 04. Withdraw Money Procedure
CREATE PROCEDURE [usp_WithdrawMoney](@accountId INT, @moneyAmount DECIMAL(18,4)) AS
 BEGIN
	   IF @moneyAmount > 0
			UPDATE [Accounts]
			   SET [Balance] = FORMAT(Balance - @moneyAmount, 'N4')
			 WHERE [Id] = @accountId
   END

-- 05. Money Transfer
CREATE PROCEDURE [usp_TransferMoney](@senderId INT, @receiverId INT, @amount DECIMAL(18,4)) AS
 BEGIN
        BEGIN TRANSACTION;

        -- Withdraw money from sender's account
        EXEC [usp_WithdrawMoney] @senderId, @amount;

        -- Check if the sender's account has sufficient funds
        IF (SELECT [Balance] FROM [Accounts] WHERE [Id] = @senderId) >= 0
		BEGIN
            EXEC [usp_DepositMoney] @receiverId, @amount;            
            COMMIT TRANSACTION
		END

        ELSE
		BEGIN
            ROLLBACK TRANSACTION
		END
   END

--------------
USE [Diablo]
GO
-- 06. Trigger
	CREATE TRIGGER [tr_ItemLevelPurchase]
		ON [Items]
INSTEAD OF INSERT AS
	 BEGIN
		   INSERT INTO [UserGameItems] ([UserGameId], [ItemId])
		   SELECT [i].[UserGameId], [i].[ItemId]
		   FROM [inserted] AS [i]
		   JOIN [UsersGames] AS [ug] ON [i].[UserGameId] = [ug].[Id]
		   JOIN [Items] AS [it] ON [i].[ItemId] = [it].[Id]
		   WHERE [ug].[Level] >= [it].[MinLevel]
	   END

UPDATE [UsersGames]
   SET [Cash] += 50000
 WHERE [UserId] IN 
(
    SELECT [Id] 
	  FROM [Users] 
	 WHERE [Username] IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
)	AND [GameId] = @GameID

DECLARE @GameID INT = (SELECT [Id] FROM [Games] WHERE [Name] = 'Bali');

INSERT INTO [UserGameItems] ([UserGameId], [ItemId])
SELECT [ug].[Id], [i].[Id]
FROM [UsersGames] AS [ug]
JOIN [Users] AS [u] ON [ug].[UserId] = [u].[Id]
JOIN [Items] AS [i] ON ([i].[Id] BETWEEN [251] AND [299] OR [i].[Id] BETWEEN 501 AND 539)
WHERE [u].[Username] IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
  AND [ug].[GameId] = @GameID
  AND [ug].[Level] >= [i].[MinLevel]
  AND [ug].[Cash] >= [i].[Price]

-- Update the cash after inserting items
UPDATE [UsersGames]
SET [Cash] = [Cash] - (
    SELECT SUM([i].[Price])
      FROM [UserGameItems] AS [ugi]
      JOIN [Items] AS [i] ON [ugi].[ItemId] = [i].[Id]
     WHERE [ugi].[UserGameId] = [ug].[Id]
)
 FROM [UsersGames] AS [ug]
 JOIN [Users] AS [u] ON [ug].[UserId] = [u].[Id]
WHERE [u].[Username] IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
  AND [ug].[GameId] = @GameID

  SELECT [u].[Username], [g].[Name] AS [GameName],
	     [ug].[Cash],
	     [i].[Name] AS [ItemName]
	FROM [Users] AS [u]
	JOIN [UsersGames] AS [ug] ON [u].[Id] = [ug].[UserId]
	JOIN [Games] AS [g] ON [ug].[GameId] = [g].[Id]
	JOIN [UserGameItems] AS [ugi] ON [ug].[Id] = [ugi].[UserGameId]
	JOIN [Items] AS [i] ON [ugi].[ItemId] = [i].[Id]
   WHERE [u].[Username] IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
	 AND [g].[Name] = 'Bali'
ORDER BY [u].[Username], [i].[Name]