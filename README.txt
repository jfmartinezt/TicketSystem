Tecnologias y medologias aplicadas: C# .Net Core Api REST, SOLID, MySQL, Entity Framework, Docker, Repository Pattern, Middleware Exception Handling, file logging.


*Los scripts de la base de datos y los jsons de Postman se encuentran en la carpeta Doc.

Requisitos:

1. .Net Framework Runtime 5.0
2. MySQL Server 8.0
3. Docker

Pasos para Windows:

1. Correr el script db_script.sql para crear la base de datos ticket_db y la tabla ticket
2. Correr el script user_script.sql para crear el usuario con los permisos suficientes para realizar consultas desde .Net con Mysql
3. En el appsettings.json de la solucion configurar el string connection:
	server=192.168.1.8;port=3306;user=monty2;password=some_pass;database=ticket_db;Convert Zero Datetime=True
	
	*En el parametro server debe ir la IPV4 del host.
		
	
5. Ir a la carpeta de la solucion .Net y correr los siguientes comandos para hacer build e iniciar el contenedor.

docker build -t dockerfile .
docker run -dp 7831:80 dockerfile

**El puerto 7831 del contenedor puede cambiarse, y en caso de hacerlo se debe ajustar el campo url del Postman enviroment para que apunte al nuevo puerto.

**El CRUD queda documentado en la Postman collection TicketSystem API. La request Get tickets contiene una descripcion de cada uno de los campos que aplica para todas las request.



