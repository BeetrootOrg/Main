UPDATE UsersLoginHistoryDB.dbo.UsersLoginHistory
	SET IpAddr = '192.168.0.5'
	WHERE UserName = 'Petrov';

UPDATE UsersLoginHistoryDB.dbo.UsersLoginHistory
	SET LogInTime = '2022-01-25 11:45:37', LogOutTime = NULL
	WHERE UserName = 'Petrov';

UPDATE UsersLoginHistoryDB.dbo.UsersLoginHistory
	SET LogOutTime = '2022-01-25 12:45:37'
	WHERE UserName = 'Petrov';

