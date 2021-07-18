using EuropeLeagues.API.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropeLeagues.API.Authentication
{
    public interface IJwtAuthHandler
    {
        User AuthenticateUser(User user);
        string GenerateJwtToken(User user);
    }
}
