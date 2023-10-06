using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Use<T> where T : BaseSkill
{
    public UseResult Cast() 
    {
        return UseResult.NONE;
    }
}

public enum UseResult
{
    NONE,
    SUCCESS,
    FAILED
}
