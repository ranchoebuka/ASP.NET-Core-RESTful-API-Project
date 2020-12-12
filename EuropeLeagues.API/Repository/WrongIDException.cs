using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropeLeagues.API.Repository
{
    public class WrongIDException: Exception
    {
        public WrongIDException(string message):base(message)
        {
        }
    }
}
