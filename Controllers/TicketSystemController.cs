using CL.Domain.Ticket.Data;
using CL.Server.Domain;
using CL.Server.Middleware.Contracts.Ticket;
using CL.Server.Middleware.Model.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace ticket.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TicketSystemController : ControllerBase
  {
    private readonly ILogger<TicketSystemController> _logger;
    private readonly TicketManager ticketManager;

    public TicketSystemController(ILogger<TicketSystemController> logger)
    {
      _logger = logger;
      ticketManager = new TicketManager();
    }

    [Route("tickets-info")]
    [HttpGet]
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
      return ticketManager.GetAll(id, user,status, fromCreation, toCreation, fromModification, toModification, amountPerPage, page);
    }

    [Route("ticket-info")]
    [HttpGet]
    public TicketData GetById(long id)
    {
      return ticketManager.GetById(id);
    }

    [Route("ticket-add")]
    [HttpPost]
    public long Insert(TicketData ticket)
    {
      return ticketManager.Insert(ticket);
    }

    [Route("ticket-upd")]
    [HttpPut]
    public void Update(TicketData ticket)
    {
      ticketManager.Update(ticket);
    }

    [Route("ticket-del")]
    [HttpDelete]
    public void Delete(TicketData ticket)
    {
      ticketManager.Delete(ticket);
    }
  }
}
