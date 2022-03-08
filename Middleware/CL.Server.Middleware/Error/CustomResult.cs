using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Server.Middleware.Error
{
  public class CustomResult
  {
    public string Category { get; set; }
    public string Message { get; set; }
    public DateTime TimeStamp { get; set; }   
  }
}
