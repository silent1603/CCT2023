using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseSkill 
{
    public int Id;
    public string[] parentNodeId;
    public SkillType skillType;
    public DamageType damageType;
    public ActorType actorTargetType;
    public EffectType effectType;
    
    public string name;
    public string content;

    public Sprite icon;

    public Dictionary<string, int> skillIds;
    SkillOperation Operation;    
}
