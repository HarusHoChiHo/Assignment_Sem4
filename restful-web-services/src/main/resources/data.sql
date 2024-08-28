insert into user_details(id, name, birth_date) values(10001, 'Jack', current_date());
insert into user_details(id, name, birth_date) values(10002, 'Ranga', current_date());
insert into user_details(id, name, birth_date) values(10003, 'Kate', current_date());

insert into post(id, description, user_id) values ( 20001, 'Learn AWS', 10001);
insert into post(id, description, user_id) values ( 20002, 'Learn Docker', 10002);
insert into post(id, description, user_id) values ( 20003, 'Learn DevOps', 10003);