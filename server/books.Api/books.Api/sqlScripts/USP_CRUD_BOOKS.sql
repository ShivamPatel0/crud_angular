USE BooksDetails
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [USP_CRUD_BOOKS]
	@id int = 0,
	@book varchar(100) = null,
	@author varchar(100) = null,
	@type varchar(10) = null

AS
BEGIN
SET NOCOUNT ON;
	IF @type = 'insert'
	BEGIN
		INSERT INTO Books(
			book,
			author,
			isDeleted
		) 
		VALUES(
			@book,
			@author,
			0
		)
	END

	ELSE IF @type = 'update'
	BEGIN
		UPDATE Books
		SET book = @book,
		author = @author
		WHERE id = @id
	END

	ELSE IF @type = 'view'
	BEGIN
		SELECT id , book ,author from Books where isDeleted <> 1
	END

	ELSE IF @type = 'delete'
	BEGIN
		UPDATE Books
		set isDeleted = 1
		where id = @id
	END
END
GO
