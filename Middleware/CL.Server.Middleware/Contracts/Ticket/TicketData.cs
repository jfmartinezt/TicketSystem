using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Server.Middleware.Contracts.Ticket
{
  public class TicketData
  {
    public long Id { get; set; }
    public string Status { get; set; }
    public string User { get; set; }
    public DateTime Creation { get; set; }
    public DateTime Modification { get; set; }
  }
}
