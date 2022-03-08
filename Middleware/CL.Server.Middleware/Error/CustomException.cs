using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Server.Middleware.Error
{
  public class CustomException : Exception
  {
    public CustomException(string msg)
    {
      CustomMessage = msg;
    }
    public string CustomMessage { get; set; }
  }
}
