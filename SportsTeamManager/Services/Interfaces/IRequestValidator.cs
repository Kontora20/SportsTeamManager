using SportsTeamManager.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsTeamManager.Services.Interfaces
{
    public interface IRequestValidator
    {
        bool IsCreatePlayerValid(int teamdId, CreatePlayer payload, out string errorDescription);
    }
}
