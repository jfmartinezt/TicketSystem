using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.Server.Middleware.Model.Entities
{
  public partial class ticket
  {
    public long idTicket { get; set; }
    public string status { get; set; }
    public string user { get; set; }
    public DateTime creation { get; set; }
    public DateTime modification { get; set; }
  }
}
