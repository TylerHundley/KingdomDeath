using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KingdomDeath.Core.Models;

namespace KingdomDeath.Core.Services
{
  public class StaticInventoryService : IInventoryService
  {
    public async Task<IEnumerable<Resource>> Get()
    {
      Resource monsterBone = new Resource { Name = "Monster Bone", Type = ResourceType.Bone, };
      Resource monsterHide = new Resource { Name = "Monster Hide", Type = ResourceType.Hide, };
      Resource monsterOrgan = new Resource { Name = "Monster Organ", Type = ResourceType.Organ, };
      Resource monsterThing = new Resource { Name = "Monster Thing", Type = ResourceType.Bone | ResourceType.Organ, };
      Resource unicornFur = new Resource { Name = "Unicorn Fur", Type = ResourceType.Bone | ResourceType.Hide, };

      var inventory = new List<Resource> { monsterBone, monsterBone, monsterBone, monsterOrgan, monsterHide, monsterThing, unicornFur };

      return await Task.FromResult(inventory);
    }
  }
}
