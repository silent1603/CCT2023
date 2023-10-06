using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags] public enum AttackType
{
    NONE = 0,
    RANGE = 1 << 1,
    MELEE = 1 << 2
}
