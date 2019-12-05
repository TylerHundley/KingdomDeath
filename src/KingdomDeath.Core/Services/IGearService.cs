using KingdomDeath.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KingdomDeath.Core.Services
{
  public interface IGearService
  {
    Task<IEnumerable<Gear>> Get();
  }
}
