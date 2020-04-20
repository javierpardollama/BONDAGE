DELETE FROM Kind;
delete from sqlite_sequence where name='Kind';
INSERT INTO Kind (LASTMODIFIED, NAME) VALUES(date('now'),"Start");
INSERT INTO Kind (LASTMODIFIED,NAME) VALUES(date('now'),"Pause");
INSERT INTO Kind (LASTMODIFIED,NAME) VALUES(date('now'),"Resume");
INSERT INTO Kind (LASTMODIFIED,NAME) VALUES(date('now'),"Stop");
