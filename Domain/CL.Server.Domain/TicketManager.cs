using CL.Domain.Ticket.Data;
using CL.Server.Middleware.Contracts.Ticket;
using CL.Server.Middleware.Error;
using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Server.Domain
{
  public class TicketManager
  {
    private readonly List<string> status =  new List<string>(){ "OPEN", "CLOSED" };

    private readonly TicketRepository ticketRepository;
    public TicketManager()
    {
      ticketRepository = new TicketRepository();
    }

    /// <summary>
    /// Gets all tickets aplying filters
    /// </summary>
    /// <param name="id"></param>
    /// <param name="user"></param>
    /// <param name="status"></param>
    /// <param name="fromCreation"></param>
    /// <param name="toCreation"></param>
    /// <param name="fromModification"></param>
    /// <param name="toModification"></param>
    /// <param name="amountPerPage"></param>
    /// <param name="page"></param>
    /// <returns></returns>
    public IEnumerable<TicketData> GetAll(
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
      if (fromCreation.HasValue && toCreation.HasValue && fromCreation.Value > toCreation.Value)
      {
        throw new CustomException("Invalid creation time range");
      }

      if (fromModification.HasValue && toModification.HasValue && fromModification.Value > toModification.Value)
      {
        throw new CustomException("Invalid modification time range");
      }

      return ticketRepository.GetAll(id, user, status, fromCreation, toCreation, fromModification, toModification, amountPerPage, page);
    }

    /// <summary>
    /// Gets a ticket by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public TicketData GetById(long id)
    {
      return ticketRepository.GetById(id);
    }

    /// <summary>
    /// Adds a new ticket
    /// </summary>
    /// <param name="ticket"></param>
    /// <returns></returns>
    public long Insert(TicketData ticket)
    {
      if (string.IsNullOrEmpty(ticket.User))
      {
        throw new CustomException("User can not be empty.");
      }

      if (string.IsNullOrEmpty(ticket.Status))
      {
        throw new CustomException("Status can not be empty.");
      }

      if (!status.Contains(ticket.Status))
      {
        throw new CustomException($"Status {ticket.Status} is not a valid state.");
      }

      return ticketRepository.Insert(ticket);
    }

    /// <summary>
    /// Updates a ticket
    /// </summary>
    /// <param name="ticket"></param>
    public void Update(TicketData updateData)
    {
      TicketData ticket = GetById(updateData.Id);
      if (ticket == null)
      {
        throw new CustomException($"Ticket with id {updateData.Id} was not found.");
      }

      if (string.IsNullOrEmpty(ticket.User))
      {
        throw new CustomException("User can not be empty.");
      }

      if (string.IsNullOrEmpty(ticket.Status))
      {
        throw new CustomException("Status can not be empty.");
      }

      if (!status.Contains(ticket.Status))
      {
        throw new CustomException($"Status {ticket.Status} is not a valid state.");
      }

      ticketRepository.Update(updateData);
    }

    /// <summary>
    /// Deletes a ticket
    /// </summary>
    /// <param name="ticket"></param>
    public void Delete(TicketData deleteData)
    {
      TicketData ticket = GetById(deleteData.Id);
      if (ticket == null)
      {
        throw new CustomException($"Ticket with id {deleteData.Id} was not found.");
      }

      ticketRepository.Delete(ticket.Id);
    }
  }
}
