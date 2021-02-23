DELETE FROM Kind;
delete from sqlite_sequence where name='Kind';
INSERT INTO Kind (LASTMODIFIED, NAME, DELETED, IMAGEURI) VALUES(date('now'),"Start", 0,"iconos/Start_500px.png" );
INSERT INTO Kind (LASTMODIFIED,NAME, DELETED, IMAGEURI) VALUES(date('now'),"Pause", 0, "iconos/Pause_500px.png");
INSERT INTO Kind (LASTMODIFIED,NAME, DELETED, IMAGEURI) VALUES(date('now'),"Resume", 0,"iconos/Resume_500px.png");
INSERT INTO Kind (LASTMODIFIED,NAME, DELETED, IMAGEURI) VALUES(date('now'),"Stop", 0,"iconos/Stop_500px.png");
