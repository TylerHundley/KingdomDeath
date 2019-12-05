using KingdomDeath.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KingdomDeath.Core.Services
{
  public class StaticGearService : IGearService
  {
    public async Task<IEnumerable<Gear>> Get()
    {
      var allGear = new List<Gear>
      {
        new Gear
        {
          Name = "Bone Axe",
          Recipe = new Recipe
          {
            Basic = new Dictionary<ResourceType, int> {{ResourceType.Bone, 2}}
          }
        },
        new Gear
        {
          Name = "Hide Shield",
          Recipe = new Recipe
          {
            Basic = new Dictionary<ResourceType, int> {{ResourceType.Bone, 1}, { ResourceType.Hide, 1 } }
          }
        },
        new Gear
        {
          Name = "Unicorn Spear",
          Recipe = new Recipe
          {
            Basic = new Dictionary<ResourceType, int> {{ResourceType.Bone, 2}, {ResourceType.Organ, 1 } },
            Unique = new Dictionary<Resource, int> {{ new Resource { Name = "Unicorn Fur", Type = ResourceType.Bone | ResourceType.Hide, } , 1} }
          }
        }
      };

      return await Task.FromResult(allGear);
    }
  }
}
