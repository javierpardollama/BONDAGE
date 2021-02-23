DELETE FROM Kind;
delete from sqlite_sequence where name='Kind';
INSERT INTO Kind (LASTMODIFIED, NAME, DELETED, IMAGEURI) VALUES(date('now'),"Start", 0,"kind/Start_500px.png" );
INSERT INTO Kind (LASTMODIFIED,NAME, DELETED, IMAGEURI) VALUES(date('now'),"Pause", 0, "kind/Pause_500px.png");
INSERT INTO Kind (LASTMODIFIED,NAME, DELETED, IMAGEURI) VALUES(date('now'),"Resume", 0,"kind/Resume_500px.png");
INSERT INTO Kind (LASTMODIFIED,NAME, DELETED, IMAGEURI) VALUES(date('now'),"Stop", 0,"kind/Stop_500px.png");
