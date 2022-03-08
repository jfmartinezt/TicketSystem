using System;
using System.Collections.Generic;
using System.Text;

namespace CL.Server.Middleware.Model.Context
{
  public class TCBaseRepository
  {
    private static string dbconnectionString;

    public static  void Configure(string _dbconnectionString)
    {
      dbconnectionString = _dbconnectionString;
    }

    public static TCDBContext GetContext()
    {
      return new TCDBContext(dbconnectionString);
    }
  }
}
