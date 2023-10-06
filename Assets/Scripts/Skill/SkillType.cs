using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags] public enum SkillType
{
    NONE  = 0,
    PASSIVE = 1 << 0,
    ACTIVE = 1 << 1
}
