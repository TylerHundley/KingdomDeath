using KingdomDeath.Core.Models;
using KingdomDeath.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace KingdomDeath.Core.Tests
{
  public class CraftingTests
  {
    private Resource monsterBone = new Resource { Name = "Monster Bone", Type = ResourceType.Bone, };
    private Resource monsterHide = new Resource { Name = "Monster Hide", Type = ResourceType.Hide, };
    private Resource monsterOrgan = new Resource { Name = "Monster Organ", Type = ResourceType.Organ, };
    private Resource monsterThing = new Resource { Name = "Monster Thing", Type = ResourceType.Bone | ResourceType.Organ, };
    private Resource unicornFur = new Resource { Name = "Unicorn Fur", Type = ResourceType.Bone | ResourceType.Hide, };



    [Fact]
    public void CanCraft_NotEnoughUnique_ReturnsFalse()
    {
      var recipe = new Recipe
      {
        Unique = new Dictionary<Resource, int> { { unicornFur, 1 } }
      };

      var inventory = new List<Resource>();

      Assert.False(inventory.CanCraft(recipe));
    }

    [Fact]
    public void CanCraft_NotEnoughBasic_ReturnsFalse()
    {
      var recipe = new Recipe
      {
        Basic = new Dictionary<ResourceType, int> { { ResourceType.Bone, 1 } }
      };

      var inventory = new List<Resource>();

      Assert.False(inventory.CanCraft(recipe));
    }

    [Fact]
    public void CanCraft_HaveAllIngredients_ReturnsTrue()
    {
      var recipe = new Recipe
      {
        Basic = new Dictionary<ResourceType, int> { { ResourceType.Bone, 1 } },
        Unique = new Dictionary<Resource, int> { { unicornFur, 1 } }
      };

      var inventory = new List<Resource> { monsterBone, unicornFur };

      Assert.True(inventory.CanCraft(recipe));
    }

    [Fact]
    public void CanCraft_HaveAllIngredients_ReturnsTrueRegardlessOfOrder()
    {
      var recipe = new Recipe
      {
        Basic = new Dictionary<ResourceType, int> { { ResourceType.Bone, 1 }, { ResourceType.Organ, 1 } }
      };

      var inventory = new List<Resource> { monsterThing, monsterBone };

      Assert.True(inventory.CanCraft(recipe));
    }
  }
}
