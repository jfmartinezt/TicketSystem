CREATE USER 'monty2'@'localhost' IDENTIFIED BY 'some_pass';
GRANT ALL PRIVILEGES ON *.* TO 'monty2'@'localhost'  WITH GRANT OPTION;
CREATE USER 'monty2'@'%' IDENTIFIED BY 'some_pass';
GRANT ALL PRIVILEGES ON *.* TO 'monty2'@'%' WITH GRANT OPTION;
