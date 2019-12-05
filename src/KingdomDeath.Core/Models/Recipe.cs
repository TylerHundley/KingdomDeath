using System;
using System.Collections.Generic;
using System.Text;

namespace KingdomDeath.Core.Models
{
  public class Recipe
  {
    public Dictionary<ResourceType, int> Basic { get; set; }
    public Dictionary<Resource, int> Unique { get; set; }
  }
}
