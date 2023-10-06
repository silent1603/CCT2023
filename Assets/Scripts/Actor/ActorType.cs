using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActorType 
{
    AI = 0,
    PLAYER = 1 << 0,
    ENEMY = 1 << 1,
    BOSS = 1 << 2,
    ITEM = 1 << 3
}
