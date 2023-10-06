using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags] public enum DamageType
{ 
    None = 0,
    PHYSICAL = 1 << 0,
    MAGIC = 1 << 1,
    FIRE = 1 << 2,
    ICE = 1 << 3,
    POISON = 1 << 4,
    FOCUS = 1 << 5,    //crit damage
}
