using KingdomDeath.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingdomDeath.Core.Extensions
{
  public static class Crafting
  {
    public static bool HasUnique(this IEnumerable<Resource> inventory, IDictionary<Resource, int> requiredUnique, out IEnumerable<Resource> remaining)
    {
      var inv = inventory.ToList();
      remaining = inv;

      if (requiredUnique.IsNullOrEmpty())
      {
        return true;
      }

      foreach (var resource in requiredUnique)
      {
        for (int i = 0; i < resource.Value; i++)
        {
          if (!inv.Contains(resource.Key))
          {
            return false;
          }
          inv.Remove(resource.Key);
        }
      }

      return true;
    }

    public static bool HasGeneric(this IEnumerable<Resource> inventory, IDictionary<ResourceType, int> requiredGeneric)
    {

      if (requiredGeneric.IsNullOrEmpty())
      {
        return true;
      }

      var inv = inventory.ToList();
      
      if (!inv.Any())
      {
        return false;
      }

      var keyToCheck = requiredGeneric.First().Key;
      var res = requiredGeneric.ToDictionary(e => e.Key, e => e.Value);

      res[keyToCheck] -= 1;
      if (res[keyToCheck] == 0)
      {
        res.Remove(keyToCheck);
      }

      foreach (var item in inv.Where(x => (x.Type & keyToCheck) == keyToCheck).ToList())
      {
        inv.Remove(item);
        if (inv.HasGeneric(res))
        {
          return true;
        }
        inv.Add(item);
      }
      return false;
    }

    public static bool CanCraft(this IEnumerable<Resource> inventory, Recipe recipe)
    {
      return inventory.HasUnique(recipe.Unique, out var remaining) && remaining.HasGeneric(recipe.Basic);
    }

    public static bool IsNullOrEmpty<T>(this IEnumerable<T> input)
    {
      return !(input?.Any() ?? false);
    }
  }
}
