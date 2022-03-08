Los scripts de la base de datos y los jsons de Postman se encuentran en la carpeta Doc.

Requisitos:

1. Instalar MySQL Server 8.0
2. Correr el script db_script.sql para crear la base de datos ticket_db y la tabla ticket
3. Correr el script user_script.sql para crear el usuario con los permisos suficientes para realizar consultas desde .Net con Mysql
4. Configurar el string connection en el appsettings.json:
	server=192.168.1.8;port=3306;user=monty2;password=some_pass;database=ticket_db;Convert Zero Datetime=True
	
	*En el parametro server debe ir la IPV4 del host.
		
	
5. Ir a la carpeta de la solucion .Net y correr los siguientes comandos para hacer build e iniciar el contenedor.

docker build -t dockerfile .
docker run -dp 7831:80 dockerfile

**El puerto 7831 del contenedor puede cambiarse, y en caso de hacerlo se debe ajustar la url del Postman eviroment para que apunte al nuevo puerto.

**El CRUD queda documentado en la Postman collection TicketSystem API



