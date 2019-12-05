using System;
using System.Collections.Generic;
using System.Text;

namespace KingdomDeath.Core.Models
{
  [Flags]
  public enum ResourceType
  {
    None = 0,
    Bone = 1,
    Hide = 2,
    Organ = 4,
    Scrap = 8
  }
}
