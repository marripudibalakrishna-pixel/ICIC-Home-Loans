using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Interfaces
{
    public interface ILoggingFactory
    {
         Task<bool> projectlevellog(string username, string loglevel, string messagetemplate);

         Task<bool> projectlevelErrorlog(int statuscode, string message, string stacktrace, string innerexception);
    }
}
