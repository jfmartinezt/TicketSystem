CREATE DATABASE `ticket_db` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `ticket_db`;

-- ticket_db.ticket definition

CREATE TABLE `ticket` (
  `idTicket` bigint NOT NULL AUTO_INCREMENT COMMENT 'Ticket code',
  `status` varchar(15) NOT NULL COMMENT 'Ticket status',
  `user` varchar(25) NOT NULL COMMENT 'Ticket owner',
  `creation` datetime(3) NOT NULL COMMENT 'Ticket creation time',
  `modification` datetime(3) NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Ticket modification time',
  PRIMARY KEY (`idTicket`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;