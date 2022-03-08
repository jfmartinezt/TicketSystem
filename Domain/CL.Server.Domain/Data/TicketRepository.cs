using CL.Server.Middleware.Contracts.Ticket;
using CL.Server.Middleware.Model.Context;
using CL.Server.Middleware.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CL.Domain.Ticket.Data
{
  internal class TicketRepository : TCBaseRepository
  {
    internal IEnumerable<TicketData> GetAll(
      long id,
      string user,
      string status,
      DateTime? fromCreation,
      DateTime? toCreation,
      DateTime? fromModification,
      DateTime? toModification,
      int amountPerPage,
      int page)
    {
      using var context = GetContext();

      var query = context.Ticket.Where(t => t.idTicket == t.idTicket);

      if (id > 0)
      {
        query = query.Where(t => t.idTicket == id);
      }

      if(!string.IsNullOrEmpty(user))
      {
        query = query.Where(t => t.user == user);
      }

      if(!string.IsNullOrEmpty(status))
      {
        query = query.Where(t => t.status == status);
      }

      if (fromCreation.HasValue && toCreation.HasValue)
      {
        query = query.Where(t => t.creation >= fromCreation && t.creation <= toCreation);
      }

      if (fromModification.HasValue && toModification.HasValue)
      {
        query = query.Where(t => t.creation >= fromModification && t.creation <= toModification);
      }

      return query
        .Skip(amountPerPage * page)
        .Take(amountPerPage)
        .ToList()
        .ConvertAll(t => EntityToContract(t));
    }

    internal TicketData GetById(long id)
    {
      using var context = GetContext();

      return context.Ticket
        .Where(t => t.idTicket == id)
        .Select(e => EntityToContract(e))
        .FirstOrDefault();
    }

    internal long Insert(TicketData ticket)
    {
      using var context = GetContext();

      ticket ticketEntity = new ticket() 
      {
        user = ticket.User,
        status = ticket.Status,
        creation = DateTime.Now,
        modification = DateTime.Now
      };

      context.Ticket.Add(ticketEntity);
      context.SaveChanges();

      return ticketEntity.idTicket;
    }

    internal void Update(TicketData ticket)
    {
      using var context = GetContext();

      ticket ticketEntity = context.Ticket.FirstOrDefault(t => t.idTicket == ticket.Id);
      if (ticketEntity != null)
      {
        ticketEntity.user = ticket.User;
        ticketEntity.status = ticket.Status;
        context.SaveChanges();
      }
    }

    internal void Delete(long id)
    {
      using var context = GetContext();

      ticket ticketEntity = context.Ticket.FirstOrDefault(t => t.idTicket == id);
      if (ticketEntity != null)
      {
        context.Ticket.Remove(ticketEntity);
        context.SaveChanges();
      }
    }

    private static TicketData EntityToContract(ticket ticket)
    {
      return new TicketData
      {
         Id = ticket.idTicket,
         Status = ticket.status,
         User = ticket.user,
         Creation = ticket.creation,
         Modification = ticket.modification
      };
    }
  }
}
