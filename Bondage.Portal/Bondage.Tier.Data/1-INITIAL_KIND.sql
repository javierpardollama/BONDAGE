DELETE FROM Kind;
delete from sqlite_sequence where name='Kind';
INSERT INTO Kind (LASTMODIFIED, NAME, DELETED) VALUES(date('now'),"Start", 0 );
INSERT INTO Kind (LASTMODIFIED,NAME, DELETED) VALUES(date('now'),"Pause", 0);
INSERT INTO Kind (LASTMODIFIED,NAME, DELETED) VALUES(date('now'),"Resume", 0);
INSERT INTO Kind (LASTMODIFIED,NAME, DELETED) VALUES(date('now'),"Stop", 0);
