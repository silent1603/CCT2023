using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags] public enum EffectType
{
    NONE = 0,
    BUFF = 1 << 0,
    DEBUFF = 1 << 1,
    CURSE = 1 << 2,
    SHIELD = 1 << 3,
    HEAL = 1 << 4,
    BIGGER_SIZE = 1 << 5,
    SMALLER_SIZE = 1 << 6,
    SLOWER_MOVEMENT = 1 << 7,
    FASTER_MOVEMENT  = 1 << 8,
    FREEZE = 1 << 9

}
